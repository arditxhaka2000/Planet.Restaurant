using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public  class Warehouse
    {
        public int Id { get;set; }
        public decimal InStock { get;set; }
        public int StationId { get;set; }

        public Warehouse()
        {

        }

        public static Warehouse GetbyId(int id)
        {
            return Services.RestHepler<Warehouse>.Get("warehouse", id);
        }
        public int Update()
        {
            int row = Services.RestHepler<Warehouse>.Update("warehouse", this);
            return row;
        }

        public static int BatchUpdate(List<Warehouse> warehouse)
        {
            int row = Services.RestHepler<Warehouse>.BatchUpdate("warehouse", warehouse);
            return row;
        }

        public static void CalculateStock(decimal inStock, int id, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { inStock = inStock, id = id, stationId = stationId });
            //string parms = "saleId=" + saleId + "&status=" + status;
            Services.RestHepler<Warehouse>.Query("CalculateStock", jsonParams);
        }
    }
}
