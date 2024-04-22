using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Pos
{
    public  class LoadJson
    {
        public static MyNET.Pos.DataSq DataSq = LoadSq();
        public static MyNET.Pos.DataEn DataEn = LoadEn();

        public static DataEn LoadEn()
        {
            var sett = Services.Settings.Get();

            var serverpath = sett.ServerPath;
            string path = serverpath + @"\Translate\TranslateEn.json";


            var fileData = File.ReadAllText(path);

            var data = JsonConvert.DeserializeObject<DataEn>(fileData);

            return data;

        }
        public static DataSq LoadSq()
        {
            var sett = Services.Settings.Get();

            var serverpath = sett.ServerPath;
            string path = serverpath + @"\Translate\TranslateSq.json";
            


            var fileData = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<DataSq>(fileData);

            return data;
        }
        
       
        public static string DataTabletoJsonDatecs(DataTable table)
        {
            var sett = Services.Settings.Get();

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            var serverpath = sett.ServerPath;

            File.WriteAllText(serverpath + @"\FiscalFolder\FiscalJsonDatecs.txt", JSONString);
            return JSONString;

        }
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally

            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
