using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MainApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            

            //string version = Properties.Settings.Default.Version;
           // this.Text = this.Text += " Version " + version;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Coral;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test 123");
        }
    }
}