using MyNET.Pos.Modules;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyNET.Pos
{
    public partial class frmSettings : Form
    {
        public static string path;
        public static bool flag = false;
        public frmSettings()
        {
            InitializeComponent();
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            Bitmap bm = null;
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            if (pData != null)
            {
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                bm = new Bitmap(mStream, false);
                mStream.Dispose();
            }
            return bm;
        }

        private void frmSettings_Load(object sender, EventArgs e)
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
            //        foreach (Control c in word_company_data.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //        foreach (Control c in word_others.Controls)
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
            //        foreach (Control c in word_company_data.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //        foreach (Control c in word_others.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //    }
            //}
            
            txtCompanyName.Text = globals.CompanyName;
            txtBusinessNumber.Text = globals.BusinessNumber;
            txtFiscalNumber.Text = globals.FiscalNumber;
            txtVatNumber.Text = globals.VatNumber;
            txtAddress.Text = globals.Address;
            txtCity.Text = globals.City;
            txtCountry.Text = globals.Country;
            txtPhoneNumber.Text = globals.PhoneNo;
             
            if(globals.Language == "Sq")
            {
                cmbLanguage.SelectedText = "Shqip";

            }
            else
            {
                cmbLanguage.SelectedText = "English";

            }
            if(globals.PagDirekte == 1)
            {
                checkBox1.Checked = true;
            }
            else
            { 
                checkBox1.Checked = false;

            } 
            if(globals.DiscountCol == 1)
            {
                checkboxDisc.Checked = true;
            }
            else
            {
                checkboxDisc.Checked = false;
            }
            if(globals.BarcMode == 1)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;

            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            var sett = Globals.Settings;

            //if (checkboxDisc.Checked)
            //{
            //    sett.UpdateF(txtFiscalPrinterPath.Text, 1, Globals.Settings.Id);

            //}
            //else
            //{
            //    sett.UpdateF(txtFiscalPrinterPath.Text, 0, Globals.Settings.Id);

            //}


            if (cmbLanguage.SelectedItem != null)
            {
                if (cmbLanguage.SelectedItem.ToString() == "Shqip")
                {
                    sett.UpdateL("Sq", Globals.Settings.Id);

                }
                else
                {
                    sett.UpdateL("En", Globals.Settings.Id);

                }
            }
           

            flag = true;

            this.Close();
        }
       
        private void ZgjedhFavorite_Click(object sender, EventArgs e)
        {
            FavoriteItems fav = new FavoriteItems();
            fav.ShowDialog();

        }

        private void btn_printerConfig_Click(object sender, EventArgs e)
        {
            PrinterConfig printer = new PrinterConfig();
            printer.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Globals.Settings;
            if (checkBox1.Checked)
            {
                sett.UpdateP(1,Globals.Settings.Id);
            }
            else 
            {
                sett.UpdateP(0,Globals.Settings.Id);

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Globals.Settings;
            if (checkBox2.Checked)
            {
                sett.BarcodeMode(1, Globals.Settings.Id);
            }
            else
            {
                sett.BarcodeMode(0, Globals.Settings.Id);

            }
        }

        private void checkboxDisc_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
