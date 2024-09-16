using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TablesSaleDetails_Archive : IBaseObj
    {
        public int Id { get; set; }

        public int SaleId { get; set; }

        public int No { get; set; }

        public decimal Discount { get; set; }

        public int ItemId { get; set; }

        public int ProjectId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal AvgPrice { get; set; }

        public int Vat { get; set; }

        public decimal VatSum { get; set; }
        public decimal TotalWithVat { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ChangedAt { get; set; }

        public string ChangedBy { get; set; }

        public int Status { get; set; }
        public int Printed { get; set; }
        public int tableId { get; set; }
        public bool ForReturn { get; set; }
        public int ItemNumber { get; set; }


        public static List<TablesSaleDetails_Archive> GetTS()
        {
            var item = Services.RestHepler<TablesSaleDetails_Archive>.Search("TablesSaleDetails", "");

            return item;
        }
        public int Insert()
        {
            int rows = Services.RestHepler<TablesSaleDetails_Archive>.Insert("TablesSaleDetails", this);

            return rows;
        }
        public int Update()
        {
            int rows = Services.RestHepler<TablesSaleDetails_Archive>.Update("TablesSaleDetails", this);

            return rows;
        } 
        public static void UpdateTSTableId(string tableId, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { tableId = tableId, id = id });
            Services.RestHepler<Tables>.RestaurantQuery("updateTSTableId", jsonParams);

        }
        public static void UpdateTSQuantity(string tableId, string itemId,string quantity,string total)
        {
            string jsonParams = JsonConvert.SerializeObject(new { tableId = tableId, itemId = itemId, quantity = quantity, TotalWithVat = total});
            Services.RestHepler<Tables>.RestaurantQuery("updateTSQuantity", jsonParams);

        }
        public static void DeleteTableSaleWithId(string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Id = id});
            Services.RestHepler<Tables>.RestaurantQuery("deleteTableSaleWithId", jsonParams);

        }
    }
}
