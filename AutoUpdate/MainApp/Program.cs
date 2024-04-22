using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Configuration;


namespace MainApp
{
    static class Program
    {
        public static string AppName { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            MyNET.Config.RestUrl = ConfigurationManager.AppSettings["RestUrl"];

            //AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            AppName = "planetpos";


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                Application.Run(new Main());
            }
            else
            {
                if (!IsUptoDate())
                    Application.Run(new UpdateDialog());
                else
                    Application.Run(new Main());
            }

            Environment.Exit(1);
        }

        private static bool IsUptoDate()
        {
            
            //Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //string strVer = appVersion.ToString();

            string versionFile = Application.StartupPath + "\\Version";

            string strVer = "1.0.0.0";
            if (System.IO.File.Exists(versionFile))
            {
                strVer = System.IO.File.ReadAllText(versionFile);
            }

            try
            {
                ///Shiko se a i ka aplikacioni update-t e fundit ne server.
                return MyNET.UpdateService.IsUptoDate(AppName, strVer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nuk munde te kyqeni ne qendren e update-ve! Ju lutem provoni me vone."
                + "\nMesazhi i gabimit:" + ex.Message);

                //nese nuk mundesh te kyqes ateher kthe true. D.m.th. aplikacionu eshte uptodate
                return true;
            }
        }
    }
}