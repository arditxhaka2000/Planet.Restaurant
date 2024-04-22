using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class Email : Form
    {
        public int saleId = 0;
        public Email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Sale.updateSendEmail(saleId, "1");
                Partner.updateEmail(PosRestaurant.PartnerId, textBox1.Text);                         
            }
            else
            {
                Sale.updateSendEmail(saleId, "0");
                this.Close();
            }
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string email = textBox1.Text.Trim();

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                e.Cancel = true;
                MessageBox.Show("Please enter a valid email address.", "Invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Email_Load(object sender, EventArgs e)
        {
            textBox1.Text = Partner.Get(PosRestaurant.PartnerId).Email;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Validating -= textBox1_Validating;

            if (checkBox1.Checked)
            {
                textBox1.Validating += textBox1_Validating;

                label1.Visible = true;
                textBox1.Visible = true;
            }
            else
            {

                label1.Visible = false;
                textBox1.Visible = false;
            }
        }
    }
}
