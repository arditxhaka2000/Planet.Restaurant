using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace MyNET.Shops
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {   
            ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\" + "AutoUpdate.exe");
                        
            Process.Start(startInfo);
            Environment.Exit(1);           
        }                
    }
}