using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ItemSaleReportClass
    {
        public ItemSaleReportClass() { }
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Quantity { get; set; }
        public string CreatedBy { get; set; }

        public static List<ItemSaleReportClass> GetItemAllReportByDate(DateTime date)
        {
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string searchParams = "&date=" + strDateFrom;
            var rptDailyBalance = Services.RestHepler<ItemSaleReportClass>.Select("salesItemReportByDate", searchParams);
            return rptDailyBalance;
        }
        public static List<ItemSaleReportClass> GetItemReportByDateAndUser(DateTime date, string username)
        {
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string searchParams = "&date=" + strDateFrom + "&UserName=" + username;
            var rptDailyBalance = Services.RestHepler<ItemSaleReportClass>.Select("salesItemReportByDateAndUser", searchParams);
            return rptDailyBalance;
        }
    }

}
