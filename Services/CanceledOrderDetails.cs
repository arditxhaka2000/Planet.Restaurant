using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CanceledOrderDetails : IBaseObj
    {
        public CanceledOrderDetails() { }

        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Item_Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string id_saler { get; set; }
        public DateTime CreatedAt { get; set; }

        public static List<Services.CanceledOrderDetails> GetCanceledOrderDetailsByOrderId(int saleId)
        {
            var items = Services.RestHepler<Services.CanceledOrderDetails>.Select("getCanceledOrderDetails", "Order_Id=" + saleId);
            return items;
        }
        public static List<Services.CanceledOrderDetails> GetCanceledOrderDetailsItems(string name)
        {
            var items = Services.RestHepler<Services.CanceledOrderDetails>.Select("GetSaleDetailsBySaleId", "Name=" + name);
            return items;
        }
        public int Insert()
        {
            int rows = Services.RestHepler<CanceledOrderDetails>.Insert("CanceledOrderDetails", this);
            return rows;
        }
        public static List<CanceledOrderDetails> CanceledOrderByDate(string fromDate, string toDate)
        {
            string searchParams = "&FromD=" + fromDate + "&ToD=" + toDate;
            var rptDailyBalance = Services.RestHepler<CanceledOrderDetails>.Select("getCanceledOrderItemsByDate", searchParams);
            return rptDailyBalance;
        }
        public static List<CanceledOrderDetails> CanceledOrderByDateAndUser(string fromDate, string toDate, int userId)
        {
            string searchParams = "&FromD=" + fromDate + "&ToD=" + toDate + "&id_saler=" + userId;
            var rptDailyBalance = Services.RestHepler<CanceledOrderDetails>.Select("getCanceledOrderItemsByDateAndUser", searchParams);
            return rptDailyBalance;
        }
    }
}
