using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Windows.Forms;
using MyNET.Pos.Modules;
using MyNET.Shops;

namespace MyNET.Pos
{
    static class Program
    {

        public static string AppName { get; set; }
        public static string language = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CultureInfo info = new CultureInfo("en-US");
            info.NumberFormat.CurrencySymbol = "€";
            info.NumberFormat.CurrencyPositivePattern = 1;
            info.NumberFormat.CurrencyNegativePattern = 5;

            var aa = info.DateTimeFormat;
            aa.DateSeparator = ".";
            aa.LongDatePattern = "dd.MM.yyyy";
            aa.ShortDatePattern = "dd.MM.yyyy";
            aa.YearMonthPattern = "MM.yyyy";

            //Application.Run(new frmPayment());


            System.Threading.Thread.CurrentThread.CurrentCulture = info;

            MyNET.Config.RestUrl = ConfigurationManager.AppSettings["RestUrl"];
            AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            string ipAddress = Properties.Settings.Default.IpAddres;

            Process[] localByName = Process.GetProcessesByName("POS");

            if (localByName != null && localByName.Length > 1)
            {
                Application.Run(new PosIsRunning());
                Application.Exit();
                return;
            }


             UpdateModule.CheckForUpdates();

            Globals.NextStep = "ConnectToServer";

            while (Globals.NextStep != "Exit")
            {
                ShowWindow(Globals.NextStep);
            }
        }
        
       

        public static Form ShowWindow(string name)
        {
            Form form = null;

            if(name.StartsWith("RestaurantPos"))
            {
                string tableId = name.Substring("RestaurantPos".Length);
                form = CreateRestaurantForm(tableId);
            }
            else
            {
                form = CreateForm(name);

            }
            //form.Show();

            if (name == "PosRestaurant" || name.StartsWith("RestaurantPos"))
            {
                Globals.LoadSettings();
            }

            Application.Run(form);
            return form;
        }

        public static Form CreateForm(string name)
        {
            Form retForm = null;

            switch (name)
            {
                case "LoginForm": retForm = (Form)new LoginForm(); break;
                case "ConnectToServer": retForm = (Form)new ConnectToServer(); break;
                case "SelectStation": retForm = (Form)new SelectStation(); break;
                case "Restaurant": retForm = (Form)new Restaurant(); break;
                case "PosRestaurant": retForm = (Form)new PosRestaurant(); break;
                case "RestaurantPos": retForm = (Form)new RestaurantPos(); break;
            }

            //Application.Run(retForm);

            return retForm;
        }
        public static Form CreateRestaurantForm(string tName)
        {
            Form form = null;

            form = (Form)new RestaurantPos(tName);

            return form;
        }

    }
}
