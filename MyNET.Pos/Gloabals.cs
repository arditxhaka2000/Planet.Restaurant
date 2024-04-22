using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;


namespace MyNET
{
    public static class Globals 
    {        
        public static Services.Models.Station Station { get; set; }

        /// <summary>
        /// ParentStationId i bjen depo prej ku shkarkohet malli
        /// </summary>
        public static int ParentStationId { get; set; }

        public static string DeviceId { get; set; } = "";

        public static void LoadSettings()
        {
            Settings = Services.Settings.Get();  
            ItemLocation = Services.ItemLocation.Get();
        }

        public static string GetCurrencyFormat()
        {
           
            int decimals = 2; //Globals.UserSettings.Digits;
           
            string part1 = "#,##0.";
            string mask = "00000000";

            string part2 = mask.Substring(0, decimals) + "€"; ;
            return part1 + part2;
        }

        public static string GetCurrencyFormatMask(string totalOrDetails = "")
        {
            //decimalet pas presjes dhjetore
            int decimals = 2;           
            string part1 = "{currency:-9.";
            string part2 = decimals.ToString() + "}";
            return part1 + part2;
        }

        public static string GetNumericFormat()
        {
            //decimalet pas presjes dhjetore
            int decimals = 2;
           
            string part1 = "#,##0.";
            string mask = "00000000";

            string part2 = mask.Substring(0, decimals) + "";
            return part1 + part2;
        }
              
        public static string NextStep { get; set; }

        public static string CashBoxStatus { get; set; }

        public static Services.Settings Settings { get; set; }
        public static List<Services.ItemLocation> ItemLocation { get; set; }

        public static Services.User User { get; set; }
        public static Services.Printer Printer { get; set; }

        public static Pos.Models.Config GetConfig()
        {
            //application path
            string appPath = Application.StartupPath;
            string jsonfile = appPath + @"\config.json";
            // read file into a string and deserialize JSON to a type
            string jsContent = File.ReadAllText(jsonfile);
            Pos.Models.Config config = JsonConvert.DeserializeObject<Pos.Models.Config>(jsContent);
            return config;
        }

        public static void SaveConfig(Pos.Models.Config config)
        {
            string strQueries = JsonConvert.SerializeObject(config);
            //application path
            string appPath = Application.StartupPath;
            string jsonfile = appPath + @"\config.json";
            // read file into a string and deserialize JSON to a type
            File.WriteAllText(jsonfile, strQueries);
        }
    }
}
