using Services;
using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
//using Etl.Services;

namespace MyNET.Pos
{
    public partial class ConnectToServer : Form
    {
        public static string language = "";
        public ConnectToServer()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtHost.Text == "")
            {
                MessageBox.Show(paragraph_ip_port_empty.Text);
                return;
            }

            int port = 0;
            if (int.TryParse(txtPort.Text, out port))
            {
                //test conncetion to server
                try
                {
                    if (Services.NetworkService.CheckHostPort(txtHost.Text, port))
                    {
                        var config = Globals.GetConfig();
                        config.LocalServerHost = txtHost.Text;
                        config.LocalServerPort = port;
                        config.DeviceId = (string.IsNullOrEmpty(config.DeviceId)) ? Guid.NewGuid().ToString() : config.DeviceId;
                        Globals.DeviceId = config.DeviceId;
                        Globals.SaveConfig(config);

                        Services.Connection.SetLocalServerProperties(txtHost.Text, port);

                        Globals.NextStep = "SelectStation";
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(paragraph_connection_failed.Text);
                    }
                }
                catch (Exception ex)
                {
                    MyNET.TrackError.ReportError(ex.Message);
                    MessageBox.Show(paragraph_error_while_connected.Text);
                }
            }
            else
            {

                MessageBox.Show(paragraph_port_requirement.Text);
            }


        }

        private void ScanIp_Load(object sender, EventArgs e)
        {

            //test conncetion to server
            try
            {
                var config = Globals.GetConfig();

                int port = config.LocalServerPort;
                string host = txtHost.Text = config.LocalServerHost;
                txtPort.Text = port.ToString();
                Globals.DeviceId = config.DeviceId;

                if (txtHost.Text == "")
                {
                    return;
                }

                if (Services.NetworkService.CheckHostPort(host, port))
                {
                    config.LocalServerHost = txtHost.Text;
                    config.LocalServerPort = port;
                    config.DeviceId = (string.IsNullOrEmpty(config.DeviceId)) ? Guid.NewGuid().ToString() : config.DeviceId;
                    Globals.DeviceId = config.DeviceId;
                    Globals.SaveConfig(config);
                    Services.Connection.SetLocalServerProperties(txtHost.Text, port);
                    var s = Services.Settings.Get();

                    Globals.NextStep = "SelectStation";
                    this.Close();
                }
                else if (Services.NetworkService.CheckHostPort(GetLocalIPAddress(), port))
                {
                    config.LocalServerHost = txtHost.Text;
                    config.LocalServerPort = port;
                    config.DeviceId = (string.IsNullOrEmpty(config.DeviceId)) ? Guid.NewGuid().ToString() : config.DeviceId;
                    Globals.DeviceId = config.DeviceId;
                    Globals.SaveConfig(config);
                    Services.Connection.SetLocalServerProperties(GetLocalIPAddress(), port);
                    var s = Services.Settings.Get();
                    Globals.NextStep = "SelectStation";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MyNET.TrackError.ReportError(ex.Message);
                MessageBox.Show("Error while connecting! See the log for details.");
            }
        }
        public static string GetLocalIPAddress()
        {
            string ipAddress = "";

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    Console.WriteLine(ni.Name);
                    IPInterfaceStatistics stat = ni.GetIPStatistics();
                    if (ni.OperationalStatus == OperationalStatus.Up)
                    {
                        if (stat.BytesReceived != 0 || stat.BytesSent != 0)
                        {
                            foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    ipAddress = ip.Address.ToString();
                                }
                            }
                        }
                    }
                }
            }
            return ipAddress;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Globals.NextStep = "Exit";

        }

        private async void word_scan_Click(object sender, EventArgs e)
        {
            var config = Globals.GetConfig();

            this.word_scan.Text = "";
            this.word_scan.Image = Properties.Resources.LoadingSpinner;
            this.word_scan.ImageAlign = ContentAlignment.MiddleCenter;

            int port = config.LocalServerPort;
            NetworkScanner scanner = new NetworkScanner(port, "/api/scan");
            string serverIP = await scanner.ScanNetworkForServer();

            if (serverIP != null)
            {
                Services.Connection.SetLocalServerIp(serverIP);
                config.LocalServerHost = Connection.Host;
                config.LocalServerPort = Connection.Port;
                config.DeviceId = (string.IsNullOrEmpty(config.DeviceId)) ? Guid.NewGuid().ToString() : config.DeviceId;
                Globals.DeviceId = config.DeviceId;
                Globals.SaveConfig(config);
                var s = Services.Settings.Get();

                this.word_scan.Text = "Skeno";
                this.word_scan.Image = null;
                this.word_scan.ImageAlign = ContentAlignment.MiddleCenter;

                Globals.NextStep = "SelectStation";

                this.Close();

            }
            else
            {
                this.word_scan.Text = "Skeno";
                this.word_scan.Image = null;
                this.word_scan.ImageAlign = ContentAlignment.MiddleCenter;

                config.LocalServerHost = "";
                Globals.SaveConfig(config);

                MessageBox.Show("Serveri nuk u gjet.");
            }
        }
    }
}
