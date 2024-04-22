using MyNET;
using MyNET.Pos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using System.Globalization;
using MyNET.Pos.Modules;
using MyNET.Shops;
using System.Drawing.Printing;

namespace MyNET.Pos
{
    public partial class CloseChashbox : Form
    {
        public static decimal openAmount;
        public static decimal totalsum;
        public static decimal gjendjaMomentale;
        public static decimal dorezimi;
        public static int dailyOpenId = Globals.User.Id;

        Services.DailyOpenCloseBalance dailyOpen = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);
        

        public Form Parenti { get; set; }

        public CloseChashbox()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DateTime foo = DateTime.Now;
            double unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

        openAmount = Convert.ToDecimal(txtTotali.Text);

            DailyOpenCloseBalance b = new DailyOpenCloseBalance();
                b.UserId = Globals.User.Id;
                b.Amount = openAmount;
                b.Status = "close";
                b.StationId = Globals.Station.Id;
                b.Date = DateTime.Now.ToLocalTime().AddHours(2);
                b.TotalShitje = PosRestaurant.totalSumOpenBalance;
                b.Insert();


                this.DialogResult = DialogResult.OK;
                this.Close();

                
            PosRestaurant.totalSumOpenBalance = 0M;
            PosRestaurant.countNumFiscal = 0;
            frmPayment.Kesh = 0M;
            frmPayment.CreditCard = 0M;
            PosRestaurant.daily.DailyFiscalCount = 0;
                
            Globals.NextStep = "LoginForm";
            this.Owner.Close();

        }

        private void CloseChashbox_Load(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();
            

            txtNrKuponav.Text = PosRestaurant.countNumFiscal.ToString();
            
            if(dailyOpen.Status == "open")
            {
                txtOpenAmount.Text = dailyOpen.Amount.ToString("N");

            }
            
            var daily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
            txtTotaliShitje.Text = daily.TotalShitje.ToString("N");
            totalsum = Convert.ToDecimal(txtOpenAmount.Text) + daily.TotalCash;
            txtTotali.Text = daily.TotalCash.ToString("N");
            txtNrKuponav.Text = daily.DailyFiscalCount.ToString();
            txtKesh.Text = daily.TotalCash.ToString("N");
            txtBankat.Text = daily.TotalCreditCard.ToString("N");


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDorzimi_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if(txtDorzimi.Text == "")
            {
                txtDorzimi.Text = "0";
            }
            if(decimal.TryParse(txtDorzimi.Text, out number))
            {
                dorezimi = Convert.ToDecimal(txtDorzimi.Text);
                if (number <= Convert.ToDecimal(txtTotali.Text))
                {
                    gjendjaMomentale = Convert.ToDecimal(txtTotali.Text) - Convert.ToDecimal(txtDorzimi.Text);
                    txtGjendjaMomentale.Text =gjendjaMomentale.ToString();


                }
                else
                {
                    MessageBox.Show(paragraph_choose_small_amount_cashbox.Text);
                    txtDorzimi.Text = "";
                    txtGjendjaMomentale.Text = "0.00";

                }
                
            }
        }


        private void btn_PrintRaport_Click(object sender, EventArgs e)
        {
            Raporti raporti = new Raporti();

            raporti.Owner = this;
            raporti.ShowDialog();
           
        }
    }

}



