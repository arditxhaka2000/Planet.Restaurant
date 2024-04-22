using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;


namespace AutoUpdate
{
    static class Program
    {
        public static  string AppName { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MyNET.Config.RestUrl = ConfigurationManager.AppSettings["RestUrl"];           

            try
            {
                //ExeFile = args[0]; 
                //current version
                string versionFile = Application.StartupPath + "\\Version";

                string version = "1.0.0.0";
                if (System.IO.File.Exists(versionFile))
                {
                    version = System.IO.File.ReadAllText(versionFile);
                }
                
                AppName = ConfigurationManager.AppSettings["AppName"];                

                if (AppName == string.Empty)
                    Environment.Exit(1);
                
                bool isUptoDate = MyNET.UpdateService.IsUptoDate(AppName, version);
                if (isUptoDate) {
                    Application.Exit();
                }
                else
                {
                    frmGetUpdates frm = new frmGetUpdates();
                    frm.ClientAppVersion = version;
                    frm.AppName = AppName;
                    //frm.AppName = appName;

                    Application.Run(frm);
                }               
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.ToString,MsgBoxStyle.,"Error");
                MessageBox.Show(ex.Message);
                Application.Exit();                
            }
        }

        public static void KillAppExe()
        {
            // Get MainApp exe name without extension 
            //string AppExe = ExeFile.Replace(".exe", "");

            Process[] local = Process.GetProcesses();
            int i;
            // Search MainApp process in windows process 
            for (i = 0; i <= local.Length - 1; i++)
            {
                // If MainApp process found then close or kill MainApp 
                if (local[i].ProcessName.ToLower() == AppName.ToLower())
                {
                    local[i].CloseMainWindow();
                }
            }
        }
    }
}