using ExtendedXmlSerializer.Configuration;
using MyNET.Shops;
using Newtonsoft.Json;
using RestSharp;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TremolZFP;

namespace MyNET.Pos.Modules
{
    public partial class PrinterConfig : Form
    {

        public bool flag = false;
        public string com;
        List<Services.Printer> printers = Services.Printer.Get();

        public PrinterConfig()
        {
            InitializeComponent();
        }

        private void btnFindPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                var sett = Settings.Get();
                var DefVersion = "";
                var clientPayed = frmPayment.Kesh;

                if (sett.PosPrinter == "0")
                {
                    DefVersion = sett.DefVersion;
                }
                if (sett.PosPrinter == "1")
                {
                    var pr = printers.Where(p => p.Id == Globals.DeviceId);

                    DefVersion = pr.First().DefVersion;
                }
                //Duhet me e bo check a eshte me ni printer ne server apo secili pos me printerat fiskal te vet

                string comPort = "";
                int baud = 1152000;
                if (COMcmb.SelectedItem != null)
                {
                    comPort = COMcmb.SelectedItem.ToString();

                    var fp = new FP((long)Convert.ToDouble(DefVersion)) { ServerAddress = "http://LocalHost:4444/" };
                    fp.ServerFindDevice(out comPort, out baud);

                    var unprinted = Services.SaleDetails.getUnprintedInvoice();

                    if (unprinted != null && unprinted.Count > 0)
                    {
                        var invoice = unprinted.GroupBy(x => new { x.SaleId })
 .Select(g => g.GroupBy(x => x.SaleId))
 .ToList();
                        foreach (var item in invoice)
                        {
                            foreach (var i in item)
                            {
                                var table = PosRestaurant.SaleDtoDataTable(i);
                                if (TremolPrint.CreateReceipt(table, clientPayed))
                                {
                                    foreach (DataRow row in table.Rows)
                                    {
                                        int rowvalue = Convert.ToInt32(row[1]);
                                        Services.SaleDetails.UpdatePrinted(rowvalue);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nuk ka asgje per tu sinkronizuar!");
                    }


                }
                else
                {
                    MessageBox.Show("Ju lutem zgjedhni COM portin per te vazhduar!");
                }


            }
            catch (SException sx)
            {
                //MessageBox.Show(sx.Message, "Error", MessageBoxButtons.OK);
                MessageBox.Show("Kontrolloni a eshte hapur serveri i printerit!", "Error", MessageBoxButtons.OK);
            }                
        }


        private void btnFindPrinterManual_Click(object sender, EventArgs e)
        {

            try
            {
                var settings = Settings.Get();

                if (COMcmb.SelectedItem != null)
                {

                    if (settings.PosPrinter == "1")
                    {
                        Printer.UpdateCOM(COMcmb.SelectedItem.ToString(), Globals.DeviceId);
                    }


                    var restClient = GetRestClient("http://LocalHost:4444/");
                    var request = new RestRequest($"/settings(com={COMcmb.SelectedItem},baud=,tcp=,ip=,port=,password=)", Method.GET);
                    var response = restClient.Execute(request);
                    if (response.IsSuccessful)
                    {

                        string comPort = "";
                        int baud = 115200;

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(response.Content);

                        string xml;
                        xml = response.Content;
                        Services.Res result;
                        XmlSerializer ser = new XmlSerializer(typeof(Services.Res));
                        using (StringReader reader = new StringReader(xml))
                        {
                            result = (Services.Res)ser.Deserialize(reader);
                            string UserID = Convert.ToString(Guid.NewGuid());

                            if (settings.PosPrinter == "1")
                            {
                                Printer.UpdateDefVersion(result.Settings.First().defVer, Globals.DeviceId);
                            }

                        }
                        if (COMcmb.SelectedItem != null)
                        {
                            comPort = COMcmb.SelectedItem.ToString();
                            try
                            {
                                var fp = new FP((long)Convert.ToDouble(result.Settings.First().defVer)) { ServerAddress = "http://LocalHost:4444/" };
                                fp.PaperFeed();
                            }
                            catch
                            {

                                MessageBox.Show($"Printeri nuk eshte ne portin {comPort}. Provoni portet tjera!");

                            }

                        }
                        else
                        {
                            MessageBox.Show("Ju lutem zgjedhni COM portin per te vazhduar!");

                        }

                    }
                    else
                    {
                        MessageBox.Show("Shikoni a eshte hap serveri i printerit!");

                    }
                }
                else
                {
                    MessageBox.Show("Ju lutem zgjedhni COM portin per te vazhduar!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private static RestClient GetRestClient(string connectionUrl)
        {
            var restClient = new RestClient(connectionUrl);
            //restClient.Authenticator = new HttpBasicAuthenticator("ClientUid", mEtlSettings.ClientUid);
            //todo: include client certificate
            //restClient.ClientCertificates.Add(certificate);
            return restClient;
        }

        private void btn_SavePrinterSettings_Click(object sender, EventArgs e)
        {
            var printer = new Printer();
            if (cmbPrinterType.SelectedItem.ToString() == "Printer Termal")
            {
                printer.UpdatePrintTermal("1", Globals.DeviceId);
            }
            else
            {
                printer.UpdatePrintTermal("0", Globals.DeviceId);

                if (cmbFiscalPrinterType.SelectedItem != null && txtPath.Text != "")
                {
                    flag = true;
                }
                printer.UpdateFiscalType(cmbFiscalPrinterType.Text, Globals.DeviceId);

                if (cmbFiscalPrinterType.SelectedItem.ToString() == "Datecs")
                {
                    printer.UpdatePath(txtPath.Text, Globals.DeviceId);

                    printer.UpdateDatecsType(cmbDatecsType.SelectedItem.ToString(), Globals.DeviceId);
                }
            }

            AutoClosingMessageBox.Show("Jane ruajtur me sukses te dhenat", "Sukses", 800);
            this.Close();


        }

        private void chk_BllokoParametrat_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_BllokoParametrat.Checked)
            {

                txtPath.ReadOnly = true;
                cmbFiscalPrinterType.Enabled = false;
            }
            else
            {

                txtPath.ReadOnly = false;
                cmbFiscalPrinterType.Enabled = true;
            }
        }

        private void PrinterConfig_Load(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            //if (globals.Language == "Sq")
            //{
            //    var data = LoadJson.DataSq;
            //    foreach (var item in data.dataWords)
            //    {
            //        foreach (Control c in this.Controls)
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
            //        foreach (Control c in this.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //    }
            //}

            var settings = Services.Settings.Get();
            cmbFiscalPrinterType.SelectedItem = settings.FiscalPrinterType != null ? settings.FiscalPrinterType : "Tremol";
            COMcmb.SelectedItem = settings == null ? "" : settings.COM;
            txtPath.Text = settings.FiscalPrinterPath;
            cmbDatecsType.SelectedItem = settings == null ? "" : settings.DatecsType;
            if (txtPath.Text == settings.FiscalPrinterPath && cmbFiscalPrinterType.SelectedItem.ToString() == "Datecs")
            {
                flag = true;
            }
        }


        private void PrinterConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag == false)
            {
                MessageBox.Show(paragraph_choose_printer_type.Text);
                e.Cancel = true;
            }
        }

        private void txtPath_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog flb = new FolderBrowserDialog();

            flb.ShowDialog();

            string sSelectedPath = flb.SelectedPath;
            txtPath.Text = sSelectedPath;
        }

        private void cmbFiscalPrinterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiscalPrinterType.SelectedItem.ToString() == "Tremol")
            {
                word_path.Visible = false;
                txtPath.Visible = false;
                COMcmb.Visible = true;
                txtBitrate.Visible = true;
                SyncFiscC.Visible = true;
                FindFiscalPrnt.Visible = true;
                word_choose_port.Visible = true;
                word_bitrate.Visible = true;
                cmbDatecsType.Enabled = false;

            }
            if (cmbFiscalPrinterType.SelectedItem.ToString() == "Datecs")
            {
                word_path.Visible = true;
                txtPath.Visible = true;
                COMcmb.Visible = false;
                txtBitrate.Visible = false;
                SyncFiscC.Visible = false;
                FindFiscalPrnt.Visible = false;
                word_choose_port.Visible = false;
                word_bitrate.Visible = false;
                cmbDatecsType.Enabled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThermalPrinter thermal = new ThermalPrinter();
            thermal.ShowDialog();
        }

        private void chkPrintCopy_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Services.Settings.Get();

            if (chkPrintCopy.Checked == true)
            {
                Settings.UpdatePrintCopy("1", sett.Id);
            }
            if (chkPrintCopy.Checked == false)
            {
                Settings.UpdatePrintCopy("0", sett.Id);

            }
        }

        private void cmbPrinterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrinterType.SelectedItem.ToString() == "Printer Fiskal" && cmbPrinterType.SelectedItem != null)
            {
                cmbFiscalPrinterType.Enabled = true;
                COMcmb.Enabled = true;
                FindFiscalPrnt.Enabled = true;
                chkPrintCopy.Enabled = true;
                SyncFiscC.Enabled = true;
                cmbFiscalPrinterType.Select();
            }
            else
            {

                cmbFiscalPrinterType.Enabled = false;
                COMcmb.Enabled = false;
                FindFiscalPrnt.Enabled = false;
                chkPrintCopy.Enabled = false;
                SyncFiscC.Enabled = false;
            }
        }
    }
}
