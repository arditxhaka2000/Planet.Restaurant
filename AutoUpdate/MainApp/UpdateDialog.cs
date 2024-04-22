using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace MainApp
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Visible = false;
            frm.ShowDialog();
            Environment.Exit(1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {            
            //Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //string strVer = appVersion.ToString();

            string versionFile = Application.StartupPath + "\\Version";

            string strVer = "1.0.0.0";
            if (System.IO.File.Exists(versionFile))
            {
                strVer = System.IO.File.ReadAllText(versionFile);
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\" + "AutoUpdate.exe");

            string cmdLine;
            cmdLine = Program.AppName + ".exe " + strVer + " " + Program.AppName;
            startInfo.Arguments = cmdLine;
            Process.Start(startInfo);
            Environment.Exit(1);           
        }                
    }
}