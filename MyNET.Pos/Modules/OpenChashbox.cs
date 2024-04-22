using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Services;
using System.Linq;
using System.Collections.Generic;
using MyNET.Shops;

namespace MyNET.Pos
{
    public partial class OpenChashbox : Form
    {
        public static decimal openAmountP;
        public static int dailyOpenId = Globals.User.Id;

        Services.DailyOpenCloseBalance dailyOpen = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);

        public static DateTime foo = DateTime.Now;
        public static double unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

        public OpenChashbox()
        {
            InitializeComponent();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {


            bool parse = decimal.TryParse(txtOpenAmount.Text, out openAmountP);
            if (parse)
            {
                DailyOpenCloseBalance b = new DailyOpenCloseBalance();
                b.UserId = Globals.User.Id;
                b.Amount = openAmountP;
                b.Status = "open";
                b.StationId = Globals.Station.Id;
                b.Date = DateTime.Now.ToLocalTime().AddHours(1);

                b.Insert();
                FiscalPrinterHelper.CashInOrCashOut(openAmountP);

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show(paragraph_put_valid_value.Text);
            }
            txtOpenAmount.Text = openAmountP.ToString();

        }

        private void OpenChashbox_Load(object sender, EventArgs e)
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



            //if (dailyOpen == null)
            //{
            //    openAmountP = 0;
            //    txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:Gss");
            //    txtUser.Text = MyNET.Globals.User.Name;
            //    txtOpenAmount.Text = "0";
            //}
            //else
            //{
            //    openAmountP = dailyOpen.neArke;
            //    txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:Gss");
            //    txtUser.Text = MyNET.Globals.User.Name;
            //    txtOpenAmount.Text = openAmountP.ToString();
            //}

            txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:Gss");
            txtUser.Text = MyNET.Globals.User.Name;
            txtOpenAmount.Text = "0.00";


        }

        private void txtOpenAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnOpen_Click(sender, e);
            }
        }
    }
}
