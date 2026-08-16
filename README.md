# DNSChanger

A lightweight Windows desktop app for viewing and changing the DNS servers used by your network adapters.

## Features

- Lists all active network interfaces on the machine
- Shows the DNS servers currently applied to the selected interface
- Apply DNS servers from a built-in list of public/predefined DNS providers (Cloudflare, Google Public DNS, OpenDNS, Quad9, AdGuard, and more — see [`PredefinedDNSList.json`](DNSChanger/PredefinedDNSList.json))
- Apply custom DNS servers of your own choosing
- Reset an interface back to automatic (DHCP-assigned) DNS
- Flush the local DNS resolver cache

## Requirements

- Windows with .NET Framework 4.8
- Administrator privileges (the app requests elevation on launch, since changing network adapter settings requires it)

## Download

Grab the latest build from the [Releases](../../releases) page.

## Building from source

1. Open `DNSChanger.sln` in Visual Studio 2019/2022 (or run `msbuild`/`nuget restore` from the command line)
2. Restore NuGet packages (Newtonsoft.Json)
3. Build the `DNSChanger` project in `Release` configuration

## Usage

1. Launch `DNSChanger.exe` and accept the UAC prompt
2. Select a network interface from the dropdown
3. Either:
   - Pick a provider from the predefined DNS list and click **Apply**, or
   - Enter custom DNS server addresses and click **Apply**
4. Use **Reset** to revert the interface to automatic DNS, or **Flush DNS** to clear the local resolver cache
