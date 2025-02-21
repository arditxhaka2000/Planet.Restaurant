using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class TablesSaleDetails : IBaseObj
    {

        public int Id { get; set; }
        public int ItemId { get; set; }

        public int No { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        //public string ProducerName { get; set; }
        //public string ProductNo { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityNow { get; set; }
        public decimal Price { get; set; }

        public decimal AvgPrice { get; set; }
        public decimal CategoryId { get; set; }

        public string CostOfGoods { get; set; }

        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }

        public decimal DiscountPriceWithVat { get; set; }

        public decimal TotalWithVatAvg { get; set; }

        public int Vat { get; set; }
        public decimal VatSum { get; set; }
        public decimal VatPrice { get; set; }
        public decimal Total { get; set; }
        public decimal TotalWithVat { get; set; }
        public int Status { get; set; }
        public int tableId { get; set; }
        public int Printed { get; set; } = 0;
        public int PrintedFiscal { get; set; } = 0;
        public decimal PrintedQuantity { get; set; } = 0;
        public decimal PrintedFiscalQuantity { get; set; } = 0;
        public decimal ClientDiscount { get; set; }
        public int Sale_Id { get; set; }
        public bool ForReturn { get; set; }
        public int ItemNumber { get; set; }
        public decimal DiscountAmount { get; set; }
        public int toClose { get; set; }
        public string CreatedBy { get; set; }


        public static List<Models.TablesSaleDetails> GetTS()
        {
            var item = Services.RestHepler<Models.TablesSaleDetails>.Search("TablesSaleDetails", "");

            return item;
        }
        public static List<Models.TablesSaleDetails> GetTSItemWithId(int id)
        {
            var item = Services.RestHepler<Models.TablesSaleDetails>.Search("TablesSaleDetails", $"Id={id}");

            return item;
        }
        public static List<Models.TablesSaleDetails> GetSaleDetailsBySaleId(int tableId)
        {
            var items = Services.RestHepler<Models.TablesSaleDetails>.Select("GetTablesSaleDetails", "tableId=" + tableId);
            return items;
        }
        public int Insert()
        {
            int rows = Services.RestHepler<Models.TablesSaleDetails>.Insert("TablesSaleDetails", this);

            return rows;
        }
        public int Update()
        {
            int rows = Services.RestHepler<Models.TablesSaleDetails>.Update("TablesSaleDetails", this);

            return rows;
        }
        public void UpdateTableItem(decimal quantity, decimal total, decimal totalWithVat, string itemname, int tableId, string description)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Quantity = quantity, Total = total, TotalWithVat = totalWithVat, ItemName = itemname, tableId = tableId, CostOfGoods = description });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updateTablesSaleDetails", jsonParams);
        }
        public static void UpdateTableSDPrinted(int printed, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Printed = printed, tableId = id });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updateTSDPrined", jsonParams);
        } 
        public static void UpdateTStoClose(int toClose, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { toClose = toClose, tableId = id });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updateTStoClose", jsonParams);
        } 
        public static void UpdateTableSDFiscalPrinted(int printed, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintedFiscal = printed, tableId = id });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updateTSDPrinedFiscal", jsonParams);
        } 
        public static void UpdateTableQuantityPrinted(decimal printedQ, string id, int itemId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintedQuantity = printedQ, ItemId = itemId, tableId = id });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updatePrinedQuantity", jsonParams);
        }
        public static void UpdateTableFiscalQuantityPrinted(decimal printedQ, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { PrintedFiscalQuantity = printedQ, Id = id });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updatePrinedFiscalQuantity", jsonParams);
        }
        public static void UpdateStatus(int status, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Status = status, tableId = id });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updateStatus", jsonParams);
        } public static void UpdateSaleId(int SaleId, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Sale_Id = SaleId, tableId = id });
            Services.RestHepler<Models.TablesSaleDetails>.Query("updateSaleId", jsonParams);
        }
        public static void UpdateTSQuantity(string tableId, string itemId, string quantity, string total)
        {
            string jsonParams = JsonConvert.SerializeObject(new { tableId = tableId, itemId = itemId, quantity = quantity, TotalWithVat = total });
            Services.RestHepler<Models.TablesSaleDetails>.RestaurantQuery("updateTSQuantity", jsonParams);

        }
        public static void DeleteTableSaleWithId(string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Id = id });
            Services.RestHepler<Models.TablesSaleDetails>.RestaurantQuery("deleteTableSaleWithId", jsonParams);

        }
    }
}
