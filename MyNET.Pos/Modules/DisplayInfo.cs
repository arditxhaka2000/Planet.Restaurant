using MyNET.Shops;
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
    public partial class DisplayInfo : Form
    {
        public static decimal Cash=0m;
        public static decimal CreditC=0m;
        public static decimal numP=0m;
        public static decimal numTot=0m;
        public static decimal numRet= 0m;
        public DisplayInfo()
        {
            InitializeComponent();
        }

        private void DisplayInfo_Load(object sender, EventArgs e)
        {
            numCash.Text = Cash.ToString();  
            numPos1.Text = numP.ToString();  
            numTotal.Text = numTot.ToString();
            numReturn.Text = numRet.ToString();  
        }
        public void UpdateTextBox(string text,string credit,string total,string ret)
        {
            numCash.Text = text;
            numPos1.Text = credit;
            numTotal.Text = total;
            numReturn.Text = ret;
        }

        private void DisplayInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }
    }
}
