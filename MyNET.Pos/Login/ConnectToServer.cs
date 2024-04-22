using System;
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
            if(int.TryParse(txtPort.Text, out port)){
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
                
                if (Services.NetworkService.CheckHostPort(host,port))
                {
                    Services.Connection.SetLocalServerProperties(txtHost.Text, port);
                    var s = Services.Settings.Get();

                    //if (s.Language == "Sq")
                    //{
                    //    var data = LoadJson.DataSq;
                    //    foreach (var item in data.dataWords)
                    //    {
                    //        foreach (Control c in splitContainer1.Panel1.Controls)
                    //        {
                    //            if (c.Name == item.name)
                    //            {
                    //                c.Text = item.translate;
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    var data = LoadJson.DataEn;
                    //    foreach (var item in data.dataWords)
                    //    {
                    //        foreach (Control c in splitContainer1.Panel1.Controls)
                    //        {
                    //            if (c.Name == item.name)
                    //            {
                    //                c.Text = item.translate;
                    //            }
                    //        }
                    //    }
                    //}
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Globals.NextStep = "Exit";
            this.Close();
        }

        private void word_scan_Click(object sender, EventArgs e)
        {

        }
    }
}
