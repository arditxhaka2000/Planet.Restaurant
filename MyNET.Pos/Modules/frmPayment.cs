
using MyNET.Pos;
using MyNET.Pos.Modules;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNET.Shops
{
    public partial class frmPayment : Form
    {
        #region Properties

        public static decimal Kesh = 0M;
        public static decimal c = 0M;
        public static decimal CreditCard = 0M;
        public static decimal numreturn = 0M;
        public static decimal bonusValue = 0M;
        public static bool displayReturn = false;
        public decimal clientPayed = 0m;
        public decimal tot = 0m;
        public decimal numToPayReal = 0m;
        public BonusCard BonusCard = new BonusCard();

        public DisplayInfo displayInfo = new DisplayInfo();

        private TextBox Selected;

        public decimal TotalCash
        {
            get; set;
        }

        public decimal TotalCreditCard
        {

            get
            {
                decimal total = 0;
                decimal.TryParse(numPos1.Text, out total); /*+ decimal.Parse(numPos2.Text) + decimal.Parse(numPos3.Text) + decimal.Parse(numPos4.Text);*/
                return total;
            }
        }

        public decimal Cash
        {

            get
            {
                decimal totalCash = 0;
                decimal.TryParse(numCash.Text, out totalCash);
                return totalCash;

            }
        }

        public decimal ForReturn { get; set; }

        public decimal TotalForPay
        {
            get
            {
                decimal totalForPay = 0;
                //totalForPay = decimal.Parse(numTotalForPayment.Text);
                totalForPay = numToPayReal;
                return totalForPay;
            }
        }


        public int BankPos1
        {
            get
            {

                int id = ucb1.SelectedValue != null ? (int)ucb1.SelectedValue : 0;
                return id;
            }

        }

        #endregion

        #region event handlers

        public frmPayment()
        {
            InitializeComponent();
        }
        public frmPayment(DisplayInfo dinfo)
        {
            InitializeComponent();
            displayInfo = dinfo;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            displayReturn = false;
            //Load
            //numTotalForPayment.Text
            numCash.Text = c.ToString();
            numCash.Focus();
            numCash.SelectAll();

            //TotalPos1 = TotalPos2 = TotalPos3 = TotalPos4 = TotalPos5 = 0.0M;
            ///load pos
            ///



            //ucb1.DataSource = posList;
            //ucb1.DisplayMember = "Name";
            //ucb1.ValueMember = "Id";
            //ucb1.SelectedValue = 1;
            //ucb1.Visible = true;
            //numPos1.Visible = true;

            var posList1 = Services.Bank.Get("1").Where(p => p.StationId == 0 || p.StationId == Globals.Station.Id).ToList();
            //var posList2 = Services.Bank.Get("1"); posList2.Insert(0, new Services.Bank());
            //var posList3 = Services.Bank.Get("1"); posList3.Insert(0, new Services.Bank());
            //var posList4 = Services.Bank.Get("1"); posList4.Insert(0, new Services.Bank());

            ucb1.DataSource = posList1;/* ucb2.DataSource = posList2; ucb3.DataSource = posList3; ucb4.DataSource = posList4;*/

            ucb1.DisplayMember = "Name";
            ucb1.ValueMember = "Id";

            if (posList1 != null && posList1.Count > 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (i < posList1.Count - 1)
                    {
                        foreach (Control item in splitContainer1.Panel1.Controls)
                        {
                            ComboBox ucb = (ComboBox)item.Controls.Find("ucb" + (i + 1), false)[0];
                            var numPos = item.Controls.Find("numPos" + (i + 1), false)[0];
                            ucb.SelectedValue = posList1[i + 1].Id;
                            ucb.Visible = numPos.Visible = true;
                        }

                    }
                }
            }
            numPos1.Text = "0";

            if (PosRestaurant.bonuscardValue > 0)
            {

                numPosBonusCard.Text = PosRestaurant.bonuscardValue1.ToString("N");
            }

        }

        private void CalculateTotal()
        {

            decimal total = numToPayReal;
            tot = total;

            var forP = numToPayReal;
            if (numPos1.Text != "0")
            {

                if (forP > Cash)
                {
                    numPos1.Text = (numToPayReal - Cash).ToString("N");

                }
                else
                {
                    numPos1.Text = "0";
                }
            }


            decimal totalPayment = Cash + TotalCreditCard;
            ForReturn = totalPayment - total;
            decimal fReturn = ForReturn;
            numReturn.Text = fReturn.ToString("N");
            numreturn = fReturn;
            displayReturn = true;
            numTotal.Text = totalPayment.ToString("N");
            displayInfo.UpdateTextBox(Cash.ToString(), TotalCreditCard.ToString(), totalPayment.ToString(), fReturn.ToString());
        }

        protected override bool ProcessCmdKey(ref Message m, Keys k)
        {
            //switch (k)
            // {
            //     case Keys.Enter: btnEnter_Click(null,null); break;
            //     case Keys.Escape: this.DialogResult = DialogResult.Abort; this.Close(); break;
            //     default: break;
            // }
            return base.ProcessCmdKey(ref m, k);
        }

        #endregion

        private void frmPayment_Shown(object sender, EventArgs e)
        {
            numCash.Focus();
        }



        private void total_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();

        }

        private void btnNoClick(object sender, EventArgs e)
        {
            Selected.Focus();
            var btn = (Button)sender;
            SendKeys.Send(btn.Text);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Selected.Text = "0.00";
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            Selected.Focus();
            SendKeys.Send("{BKSP}");
        }

        public string SelectedOpction { get; set; } = "Cancel";

        private void btnEnter_Click(object sender, EventArgs e)
        {
            var daily = Services.DailyOpenCloseBalance.GetLastDailyBalance(Globals.Station.Id);
            SelectedOpction = "Ok";

            decimal otherPayments = TotalCreditCard;


            if (otherPayments > 0)
            {
                //nese pagesa eshte edhe me kartel ather shuma e paguar duhet te jete e barabart me shumen per pages
                //nuk ka kusur
                if (Math.Abs(ForReturn) > 0.01M)
                {
                    MessageBox.Show(paragraph_pay_error.Text);
                    return;
                }
                else
                {
                    TotalCash = Cash;
                    Kesh = TotalCash;
                }


            }
            else if (otherPayments == 0)
            {
                if (Math.Round(TotalForPay, 2) > Cash)
                {
                    MessageBox.Show(paragraph_pay_error_2.Text);
                    return;
                }
                else
                {
                    TotalCash = Cash - ForReturn;
                    Kesh = TotalCash;
                }
            }
            CreditCard += TotalCreditCard;
            clientPayed = Cash;
            this.DialogResult = DialogResult.OK;

            if (PosRestaurant.bonuscard != null)
            {
                var newCurrentAmount = PosRestaurant.bonuscard.CurrentAmount - PosRestaurant.bonuscardValue;
                BonusCard.UpdateCurrentAmountBonusCard(newCurrentAmount, PosRestaurant.bonuscard.Id);
            }


            this.Close();
        }

        private void num_Enter(object sender, EventArgs e)
        {
            this.Selected = (TextBox)sender;
        }

        private void frmPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedOpction == "Cancel")
                this.DialogResult = DialogResult.Cancel;

            displayInfo.UpdateTextBox("0.00", "0.00", "0.00", "0.00");
        }

        private void numCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Handle digits, control characters, and punctuation
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar);

            // Trigger btnEnter_Click if Enter key is pressed
            if (e.KeyChar == 13)
            {
                btnEnter_Click(null, null);
            }

            // Allow Backspace
            if (e.KeyChar == 8)
            {
                e.Handled = false; // Allow Backspace
                return; // Exit the method to avoid further validation for Backspace
            }

            // Handle digit and decimal point entry
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                // Handle multiple decimal points
                if (e.KeyChar == '.' && numCash.Text.IndexOf('.') > -1)
                {
                    e.Handled = true; // Prevent entering multiple decimal points
                }
                else if (e.KeyChar == '.')
                {
                    // Allow a decimal point only if there are no digits after it
                    if (numCash.Text.Substring(numCash.SelectionStart).Any(char.IsDigit))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    // Allow digits only if there are two or fewer digits after the decimal point
                    int decimalIndex = numCash.Text.IndexOf('.');
                    if (decimalIndex > -1 && numCash.Text.Length - decimalIndex > 2)
                    {
                        e.Handled = true;
                    }

                    // Allow only 6 digits before the decimal point
                    if (decimalIndex == -1 && numCash.Text.Length >= 6)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                e.Handled = true; // Prevent non-numeric characters
            }
        }

        private void numPos1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
            if (e.KeyChar == 13)
            {
                btnEnter_Click(null, null);
            }

        }

        private void numPos1_Click(object sender, EventArgs e)
        {
            var forP = Convert.ToDecimal(numTotalForPayment.Text);
            if (forP > Cash)
            {
                var numPosValue = (Convert.ToDecimal(numTotalForPayment.Text) - Cash);
                numPos1.Text = numPosValue.ToString("N");

            }
            else
            {
                numPos1.Text = "0";
            }
        }

        private void frmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(null, null);
            }
        }

        private void numCash_Click(object sender, EventArgs e)
        {
            var forP = Convert.ToDecimal(numTotalForPayment.Text);
            if (numPos1.Text != "0")
            {

                if (forP > Cash)
                {
                    numPos1.Text = (Convert.ToDecimal(numTotalForPayment.Text) - Cash).ToString("C2");

                }
                else
                {
                    numPos1.Text = "0";
                }
            }

        }

        private void txt_bonusCard_Click(object sender, EventArgs e)
        {

        }

        private void txt_bonusCard_TextChanged(object sender, EventArgs e)
        {
            //qitu funksioni per me i marr centat prej bonus karteles

        }

        private void numPosBonusCard_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();

        }

        private void numPosBonusCard_Click(object sender, EventArgs e)
        {

        }
    }
}
