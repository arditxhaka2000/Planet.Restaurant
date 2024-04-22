using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class DiscountTotalAmount : Form
    {
        public static decimal TotalPercentage = 0;

        public DiscountTotalAmount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTotalDiscountPercentage.Text);

                if (value < 0 || value > 99)
                {
                    MessageBox.Show("Please enter a positive number less than 100.");
                    txtTotalDiscountPercentage.Text = "";
                }
                else
                {
                    TotalPercentage = Convert.ToDecimal(txtTotalDiscountPercentage.Text);
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
                txtTotalDiscountPercentage.Text = "";
            }
        }

       

        private void txtTotalDiscountPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
