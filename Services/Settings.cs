using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Settings
    {
        #region Class properties
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string BusinessNumber { get; set; }
        public string FiscalNumber { get; set; }
        public string VatNumber { get; set; }
        public string Address { get; set; }
        public string StockWMinus { get; set; }
        public int StockRibbon { get; set; }
        public int LocationRibbon { get; set; }
        public string Language { get; set; }
        public int PagDirekte { get; set; }
        public int DiscountCol { get; set; }
        public int UnitCol { get; set; }
        public string AllowDiscount { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string FiscalPrinterPath { get; set; }
        public string DatecsType { get; set; }
        public string PrintingType { get; set; }
        public string FiscalPrinterType { get; set; }
        public string ServerPath { get; set; }
        public string PIN { get; set; }
        public string COM { get; set; }
        public string PrintCopy { get; set; }
        public string DefVersion { get; set; }
        public string PosPrinter { get; set; }
        public int BarcMode { get; set; }
        public int DefaultClientId { get; set; }
        public int FiscalCount { get; set; }
        public string ThermalPrinterName { get; set; }
        public string ThermalPrinterPageWidth { get; set; }
        public string EmpLoginMethod { get; set; }
        public int ForReturn { get; set; }
        public decimal MaxDiscount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ChangedAt { get; set; }
        public string ChangedBy { get; set; }
        public int Status { get; set; }
        public string Logo { get; set; }
        public string Theme { get; set; }
        public int DescriptionCol { get; set; }


        #endregion

        public Settings()
        {

        }

        public static Settings Get()
        {
            var settings = Services.RestHepler<Settings>.Search("settings", "");
            if (settings != null && settings.Count > 0)
                return settings.FirstOrDefault();
            else
                return null;
        }

        #region Update

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int rows = Services.RestHepler<Settings>.Update("settings", this);
            return rows;
        }
        public int Insert()
        {
            int rows = Services.RestHepler<Settings>.Insert("settings", this);
            return rows;
        }
        public void UpdateF(int discount,int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new {DiscountCol = discount, id = stationId });
            Services.RestHepler<Settings>.Query("updateF", jsonParams);
            
        } 
        public void UpdateUnitCol(int unit,int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new {UnitCol = unit, id = stationId });
            Services.RestHepler<Settings>.Query("updateUnitCol", jsonParams);
            
        } 
        public void UpdateDescriptionCol(int descr,int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new {DescriptionCol = descr, id = stationId });
            Services.RestHepler<Settings>.Query("updateDescription", jsonParams);
            
        }  
        public void UpdatePath(string path,int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new {FiscalPrinterPath = path, id = stationId });
            Services.RestHepler<Settings>.Query("updatePath", jsonParams);
            
        } 
        public void UpdateFT(string type,int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { FiscalPrinterType = type, id = stationId });
            Services.RestHepler<Settings>.Query("updateFT", jsonParams);
            
        }
        public void UpdateFC(string count,int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { FiscalCount = count, id = stationId });
            Services.RestHepler<Settings>.Query("updateFC", jsonParams);
            
        } 
        public void UpdateL(string lang,int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Language = lang, id = stationId });
            Services.RestHepler<Settings>.Query("updateL", jsonParams);
            
        }
        public void UpdateP(int i, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PagDirekte = i, id = stationId });
            Services.RestHepler<Settings>.Query("updateP", jsonParams);
            
        }
        public void BarcodeMode(int i, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { BarcMode = i, id = stationId });
            Services.RestHepler<Settings>.Query("updateBarcodeMode", jsonParams);
            
        }
        public static void UpdateCOM(string com, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { COM = com, id = stationId });
            Services.RestHepler<Settings>.Query("updateCom", jsonParams); 
            
        }
        public static void UpdatedefVer(string defVer, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { DefVersion = defVer, id = stationId });
            Services.RestHepler<Settings>.Query("updateDef", jsonParams); 
            
        }
        public static void UpdateThermalPrinter(string name, string pageWidth, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { ThermalPrinterName = name, ThermalPrinterPageWidth = pageWidth, id = stationId });
            Services.RestHepler<Settings>.Query("updateThermalPrinter", jsonParams); 
            
        }
        public static void UpdatePrintCopy(string printCopy, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintCopy = printCopy, id = stationId });
            Services.RestHepler<Settings>.Query("updatePrintCopy", jsonParams);

        }
        public static void updateEmpLoginMethod(int id, string EmpLoginMethod)
        {
            string jsonParams = JsonConvert.SerializeObject(new { EmpLoginMethod = EmpLoginMethod, id = id });
            Services.RestHepler<Settings>.Query("updateEmpLoginMethod", jsonParams);
        } 
        public  void updatePrintingType(string type, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintingType = type, id = id });
            Services.RestHepler<Settings>.Query("updatePrintingType", jsonParams);
        } 
        public  void UpdateStockRibbon(int type, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { StockRibbon = type, id = id });
            Services.RestHepler<Settings>.Query("updateStockRibbon", jsonParams);
        }
        public  void UpdateLocation(int type, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { LocationRibbon = type, id = id });
            Services.RestHepler<Settings>.Query("updateItemLocation", jsonParams);
        }
        public  void UpdateForReturn(int type, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { ForReturn = type, id = id });
            Services.RestHepler<Settings>.Query("updateForReturn", jsonParams);
        } 
        public static void UpdateThemePreference(string theme, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Theme = theme, id = id });
            Services.RestHepler<Settings>.Query("updateThemePreference", jsonParams);
        }

        #endregion
    }
}
    