using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public class Tables : IBaseObj
    {
        public int Id { get; set; }
        public int Space_id { get; set; }
        public string Name { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public string Shape { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public int inPos { get; set; }
        public int Status { get; set; }
        public string station_id { get; set; }
        public string toUpdate { get; set; }
        public string toDelete { get; set; }
        public string inPosTotal { get; set; }
        public int PrintTotal { get; set; }
        public int PrintFiscal { get; set; }
        public int saleId { get; set; }
        public int FiscalCount { get; set; }
        public int Emp_id { get; set; }
        public int JoinId { get; set; }
        public string Date { get; set; }

        public static List<Tables> GetTables()
        {
            var item = Services.RestHepler<Tables>.Search("RestaurantTables", "");

            return item;
        }
        public static List<Tables> GetLastFiscalCount()
        {
            var last = Services.RestHepler<Tables>.Select("getLastFiscalCount", "");

            return last;
        }
        public static List<Tables> GetTablesBySpaceId(int spaceId)
        {
            string searchParams = "SpaceId=" + spaceId;
            var last = Services.RestHepler<Tables>.Select("getBySpaceId", searchParams);
            return last;
        }

        public int Insert()
        {
            int rows = Services.RestHepler<Tables>.Insert("RestaurantTables", this);
            return rows;
        }
        public int Update()
        {
            int rows = Services.RestHepler<Tables>.Update("RestaurantTables", this);

            return rows;
        }
        public static void UpdateTableLocation(decimal locationX, decimal locationY, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { LocationX = locationX, LocationY = locationY, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTableLocation", jsonParams);

        }
        public static void UpdateTablePos(int posOn, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { inPos = posOn, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTablePos", jsonParams);

        }
        public static void UpdateTotalInPos(string inPosTotal, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { inPosTotal = inPosTotal, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTotalInPos", jsonParams);

        }
        public static void UpdatePrintTotal(int printTotal, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintTotal = printTotal, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updatePrintTotal", jsonParams);

        }
        public static void UpdatePrintFiscal(int printFiscal, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintFisacl = printFiscal, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updatePrintFiscal", jsonParams);

        }
        public static void UpdateTableSaleId(int saleId, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { saleId = saleId, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTableSaleId", jsonParams);

        }
        public static void UpdateTableFiscalCount(string count, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { FiscalCount = count, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTableFiscalCount", jsonParams);

        }
        public static void UpdateTableEmpId(string empId, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Emp_id = empId, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTableEmpId", jsonParams);

        }
        public static void UpdateTableJoinId(string joinId, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { JoinId = joinId, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTableJoinId", jsonParams);

        }
        public static void UpdateToUpdate(string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateToUpdateTables", jsonParams);

        }
        public static void UpdateDate(string date, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Date = date, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateDateTables", jsonParams);

        }
        public static void UpdateTableShape(string shape, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Shape = shape, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTableShape", jsonParams);

        }
        public static void UpdateTableSize(string width, string height, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Width = width, Height = height, Id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTableSize", jsonParams);

        }
    }
}
