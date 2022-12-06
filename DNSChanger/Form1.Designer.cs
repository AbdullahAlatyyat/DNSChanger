namespace DNSChanger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cbNetworkInterface = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSelectDNS = new System.Windows.Forms.ComboBox();
            this.tbAppliedDNS1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAppliedDNS2 = new System.Windows.Forms.TextBox();
            this.btnFlushDNS = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnApplyCustom = new System.Windows.Forms.Button();
            this.lblPredefinedDNS = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Network Interfaces";
            // 
            // cbNetworkInterface
            // 
            this.cbNetworkInterface.FormattingEnabled = true;
            this.cbNetworkInterface.Location = new System.Drawing.Point(15, 28);
            this.cbNetworkInterface.Name = "cbNetworkInterface";
            this.cbNetworkInterface.Size = new System.Drawing.Size(276, 24);
            this.cbNetworkInterface.TabIndex = 1;
            this.cbNetworkInterface.SelectedIndexChanged += new System.EventHandler(this.cbNetworkInterface_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Predefined DNS List";
            // 
            // cbSelectDNS
            // 
            this.cbSelectDNS.FormattingEnabled = true;
            this.cbSelectDNS.Location = new System.Drawing.Point(362, 28);
            this.cbSelectDNS.Name = "cbSelectDNS";
            this.cbSelectDNS.Size = new System.Drawing.Size(276, 24);
            this.cbSelectDNS.TabIndex = 3;
            this.cbSelectDNS.SelectedIndexChanged += new System.EventHandler(this.cbSelectDNS_SelectedIndexChanged);
            // 
            // tbAppliedDNS1
            // 
            this.tbAppliedDNS1.Location = new System.Drawing.Point(359, 126);
            this.tbAppliedDNS1.Name = "tbAppliedDNS1";
            this.tbAppliedDNS1.Size = new System.Drawing.Size(279, 22);
            this.tbAppliedDNS1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Applied DNS";
            // 
            // tbAppliedDNS2
            // 
            this.tbAppliedDNS2.Location = new System.Drawing.Point(359, 154);
            this.tbAppliedDNS2.Name = "tbAppliedDNS2";
            this.tbAppliedDNS2.Size = new System.Drawing.Size(279, 22);
            this.tbAppliedDNS2.TabIndex = 6;
            // 
            // btnFlushDNS
            // 
            this.btnFlushDNS.Location = new System.Drawing.Point(15, 126);
            this.btnFlushDNS.Name = "btnFlushDNS";
            this.btnFlushDNS.Size = new System.Drawing.Size(100, 50);
            this.btnFlushDNS.TabIndex = 8;
            this.btnFlushDNS.Text = "Flush DNS";
            this.btnFlushDNS.UseVisualStyleBackColor = true;
            this.btnFlushDNS.Click += new System.EventHandler(this.btnFlushDNS_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(667, 20);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 39);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnApplyCustom
            // 
            this.btnApplyCustom.Location = new System.Drawing.Point(667, 125);
            this.btnApplyCustom.Name = "btnApplyCustom";
            this.btnApplyCustom.Size = new System.Drawing.Size(75, 51);
            this.btnApplyCustom.TabIndex = 10;
            this.btnApplyCustom.Text = "Apply Custom";
            this.btnApplyCustom.UseVisualStyleBackColor = true;
            this.btnApplyCustom.Click += new System.EventHandler(this.btnApplyCustom_Click);
            // 
            // lblPredefinedDNS
            // 
            this.lblPredefinedDNS.AutoSize = true;
            this.lblPredefinedDNS.Location = new System.Drawing.Point(362, 59);
            this.lblPredefinedDNS.Name = "lblPredefinedDNS";
            this.lblPredefinedDNS.Size = new System.Drawing.Size(0, 16);
            this.lblPredefinedDNS.TabIndex = 12;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(191, 125);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(100, 50);
            this.btnAuto.TabIndex = 13;
            this.btnAuto.Text = "Set Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 188);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.lblPredefinedDNS);
            this.Controls.Add(this.btnApplyCustom);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnFlushDNS);
            this.Controls.Add(this.tbAppliedDNS2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAppliedDNS1);
            this.Controls.Add(this.cbSelectDNS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNetworkInterface);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNS Changer AACH";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNetworkInterface;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSelectDNS;
        private System.Windows.Forms.TextBox tbAppliedDNS1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAppliedDNS2;
        private System.Windows.Forms.Button btnFlushDNS;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnApplyCustom;
        private System.Windows.Forms.Label lblPredefinedDNS;
        private System.Windows.Forms.Button btnAuto;
    }
}

