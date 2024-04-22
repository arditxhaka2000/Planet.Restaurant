using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Printer
    {
        public string Id { get; set; }

        public string COM { get; set; }

        public string DefVersion { get; set; }
        public string PrintTermal { get; set; }
        public string FiscalType { get; set; }
        public string Path { get; set; }
        public string TermalName { get; set; }
        public string TermalPaperWidth { get; set; }
        public string DatecsType { get; set; }
        public string IsShared { get; set; }
        public int ToPrint { get; set; }
        public int PosId { get; set; }




        public static List<Printer> Get()
        {
            var printers = Services.RestHepler<Printer>.Search("printer", "");
            if (printers != null && printers.Count > 0)
                return printers;
            else
                return null;
        }

        public static void InsertId(string id, int posid)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Id = id, PosId = posid });
            Services.RestHepler<Printer>.Query("insertPrinter", jsonParams);
        } 
        public static void UpdateCOM(string com, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { COM = com, id = deviceId });
            Services.RestHepler<Printer>.Query("updateComPort", jsonParams);
        } 
        public static void UpdateDefVersion(string def, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { DefVersion = def, id = deviceId });
            Services.RestHepler<Printer>.Query("updateDefVersion", jsonParams);
        } 
        public void UpdatePrintTermal(string def, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintTermal = def, id = deviceId });
            Services.RestHepler<Printer>.Query("updatePrintTermal", jsonParams);
        }
        public void UpdateFiscalType(string type, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { FiscalType = type, id = deviceId });
            Services.RestHepler<Printer>.Query("updateFiscalType", jsonParams);
        }
        public void UpdatePath(string path, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Path = path, id = deviceId });
            Services.RestHepler<Printer>.Query("updatePath", jsonParams);
        } 
        public void UpdateTermalName(string name, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { TermalName = name, id = deviceId });
            Services.RestHepler<Printer>.Query("updateTermalName", jsonParams);
        }
        public void UpdatePaperWidth(string width, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { TermalPaperWidth = width, id = deviceId });
            Services.RestHepler<Printer>.Query("updatePaperWidth", jsonParams);
        } 
        public void UpdateDatecsType(string type, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { DatecsType = type, id = deviceId });
            Services.RestHepler<Printer>.Query("updateDatecsType", jsonParams);
        }
        public void UpdateIsShared(string isShared, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { IsShared = isShared, id = deviceId });
            Services.RestHepler<Printer>.Query("updateIsShared", jsonParams);
        }
        public void UpdateToPrint(string toPrint, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { ToPrint = toPrint, id = deviceId });
            Services.RestHepler<Printer>.Query("updateToPrint", jsonParams);
        } 
        public void UpdateIsPrinted(string isPrinted, string deviceId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { IsPrinted = isPrinted, id = deviceId });
            Services.RestHepler<Printer>.Query("updateIsPrinted", jsonParams);
        }
    }
}
