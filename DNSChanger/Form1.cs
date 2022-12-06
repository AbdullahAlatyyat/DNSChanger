using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;

namespace DNSChanger
{
    public partial class Form1 : Form
    {
        private static List<PredefinedDNS> predefinedDNS = new List<PredefinedDNS>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbNetworkInterface.Items.Add("Please Select Interface");
            cbNetworkInterface.SelectedIndex = 0;

            cbSelectDNS.Enabled = false;
            tbAppliedDNS1.Enabled = false;
            tbAppliedDNS2.Enabled = false;
            btnApply.Enabled = false;
            btnApplyCustom.Enabled = false;

            var currPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var jsonPath = Path.Combine(currPath, "PredefinedDNSList.json");
            predefinedDNS = JsonConvert.DeserializeObject<List<PredefinedDNS>>(File.ReadAllText(jsonPath));

            foreach (var item in predefinedDNS)
            {
                cbSelectDNS.Items.Add(item.DNSCountry + " " + item.DNSName);
            }

            var adapters = NetworkInterface.GetAllNetworkInterfaces().ToList();
            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                    !Enum.IsDefined(typeof(NetworkInterfaceType), adapter.NetworkInterfaceType))
                    continue;

                if (adapter.OperationalStatus == OperationalStatus.Up)
                    cbNetworkInterface.Items.Add(adapter.Name + " - Active");
                else
                    cbNetworkInterface.Items.Add(adapter.Name);

                if (adapter.OperationalStatus == OperationalStatus.Up && cbNetworkInterface.SelectedIndex == 0)
                    cbNetworkInterface.SelectedIndex = cbNetworkInterface.Items.Count - 1;
            }
        }

        public bool SetDNSInner(string dns1, string dns2, bool reset = false)
        {
            string param = "SetDNSServerSearchOrder";
            ManagementClass mcOBJ = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection mocOBJ = mcOBJ.GetInstances();
            foreach (ManagementObject moOBJ in mocOBJ)
            {
                if ((bool)moOBJ["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject newDNS = moOBJ.GetMethodParameters(param);
                        if (newDNS != null)
                        {
                            if (reset)
                            {
                                newDNS["DNSServerSearchOrder"] = null;
                            }
                            else
                            {
                                string[] s = { dns1, dns2 };
                                newDNS["DNSServerSearchOrder"] = s;
                            }
                            moOBJ.InvokeMethod(param, newDNS, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var selectedPredefinedDNS = predefinedDNS.Where(x => x.DNSCountry + " " + x.DNSName == cbSelectDNS.SelectedItem.ToString()).FirstOrDefault();
            if (selectedPredefinedDNS != null)
            {
                if (tbAppliedDNS1.Text == selectedPredefinedDNS.DNSAddress && tbAppliedDNS2.Text == selectedPredefinedDNS.DNSAddress2)
                    MessageBox.Show("This DNS is already applied");
                else
                    SetDNS(selectedPredefinedDNS.DNSAddress, selectedPredefinedDNS.DNSAddress2);
            }
        }

        private void btnApplyCustom_Click(object sender, EventArgs e)
        {
            var alreadySetDNS1 = "";
            var alreadySetDNS2 = "";

            var selectedInterface = getSelectedInterface();
            if (selectedInterface != null)
            {
                var props = selectedInterface.GetIPProperties();
                if (props != null)
                {
                    var dnsAddresses = props.DnsAddresses?.ToList();
                    if (dnsAddresses != null && dnsAddresses.Count > 0)
                    {
                        if (props.GatewayAddresses != null && props.GatewayAddresses.Count > 0)
                        {
                            var gatewayAddresses = props.GatewayAddresses.Select(w => w.Address.ToString()).ToList();
                            dnsAddresses = dnsAddresses.Where(x => !gatewayAddresses.Contains(x.ToString())).ToList();
                        }

                        if (dnsAddresses.Count >= 1)
                            alreadySetDNS1 = dnsAddresses[0].ToString();
                        if (dnsAddresses.Count >= 2)
                            alreadySetDNS2 = dnsAddresses[1].ToString();
                    }
                }
            }

            if (tbAppliedDNS1.Text == alreadySetDNS1 && tbAppliedDNS2.Text == alreadySetDNS2)
                MessageBox.Show("This DNS is already applied");
            else
                SetDNS(tbAppliedDNS1.Text, tbAppliedDNS2.Text);
        }

        private void cbNetworkInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNetworkInterface.SelectedIndex == 0)
            {
                cbSelectDNS.Enabled = false;
                tbAppliedDNS1.Enabled = false;
                tbAppliedDNS2.Enabled = false;
                btnApply.Enabled = false;
                btnApplyCustom.Enabled = false;
                tbAppliedDNS1.Text = String.Empty;
                tbAppliedDNS2.Text = String.Empty;
            }
            else
            {
                cbSelectDNS.Enabled = true;
                tbAppliedDNS1.Enabled = true;
                tbAppliedDNS2.Enabled = true;
                btnApply.Enabled = true;
                btnApplyCustom.Enabled = true;
                GetSelectedDNSFromSelectedInterface();
            }
        }

        private void GetSelectedDNSFromSelectedInterface()
        {
            var selectedInterface = getSelectedInterface();
            if (selectedInterface != null)
            {
                var props = selectedInterface.GetIPProperties();
                if (props != null)
                {
                    var dnsAddresses = props.DnsAddresses?.ToList();
                    if (dnsAddresses != null && dnsAddresses.Count > 0)
                    {
                        if (props.GatewayAddresses != null && props.GatewayAddresses.Count > 0)
                        {
                            var gatewayAddresses = props.GatewayAddresses.Select(w => w.Address.ToString()).ToList();
                            dnsAddresses = dnsAddresses.Where(x => !gatewayAddresses.Contains(x.ToString())).ToList();
                        }

                        if (dnsAddresses.Count >= 1)
                            tbAppliedDNS1.Text = dnsAddresses[0].ToString();
                        if (dnsAddresses.Count >= 2)
                            tbAppliedDNS2.Text = dnsAddresses[1].ToString();
                    }
                }
            }
            else
            {
                tbAppliedDNS1.Text = String.Empty;
                tbAppliedDNS2.Text = String.Empty;
            }
        }

        public void runCMD(string command)
        {
            Process DProcess = new Process();

            DProcess.StartInfo.FileName = "cmd.exe";

            DProcess.StartInfo.Arguments = " /c " + command;

            DProcess.StartInfo.UseShellExecute = false;

            DProcess.StartInfo.CreateNoWindow = true;

            DProcess.StartInfo.LoadUserProfile = true;

            DProcess.StartInfo.RedirectStandardError = true;

            DProcess.StartInfo.RedirectStandardInput = true;

            DProcess.StartInfo.RedirectStandardOutput = true;

            DProcess.Start();

            DProcess.WaitForExit();
        }

        public void SetDNS(string dns1, string dns2)
        {
            var selectedInterface = getSelectedInterface();
            if (selectedInterface != null)
            {
                var previousDNS1 = tbAppliedDNS1.Text;
                var previousDNS2 = tbAppliedDNS2.Text;

                var setResult = SetDNSInner(dns1, dns2);
                if (!setResult)
                {
                    MessageBox.Show("Fail Set DNS");
                    return;
                }

                GetSelectedDNSFromSelectedInterface();

                if (previousDNS1 != tbAppliedDNS1.Text && previousDNS2 != tbAppliedDNS2.Text)
                    MessageBox.Show("Success");
                else
                    MessageBox.Show("Fail Set DNS");
            }
        }

        public NetworkInterface getSelectedInterface()
        {
            var adapters = NetworkInterface.GetAllNetworkInterfaces().ToList();
            return adapters.Where(x => x.Name == cbNetworkInterface.Text.Replace(" - Active", "")).FirstOrDefault();
        }

        private void btnFlushDNS_Click(object sender, EventArgs e)
        {
            runCMD("ipconfig /flushdns");
            MessageBox.Show("Success");
        }

        private void cbSelectDNS_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPredefinedDNS = predefinedDNS.Where(x => x.DNSCountry + " " + x.DNSName == cbSelectDNS.SelectedItem.ToString()).FirstOrDefault();
            lblPredefinedDNS.Text = selectedPredefinedDNS.DNSAddress + " - " + selectedPredefinedDNS.DNSAddress2;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var selectedInterface = getSelectedInterface();
            if (selectedInterface != null)
            {
                var previousDNS1 = tbAppliedDNS1.Text;
                var previousDNS2 = tbAppliedDNS2.Text;

                SetDNSInner(null, null, true);
                GetSelectedDNSFromSelectedInterface();

                if (previousDNS1 != tbAppliedDNS1.Text && previousDNS2 != tbAppliedDNS2.Text)
                    MessageBox.Show("Success");
            }
        }
    }
}
