using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ItemCategoriesSaleReportClass
    {
        public ItemCategoriesSaleReportClass() { }
        public string CategoryName { get; set; }
        public decimal TotalAmount { get; set; }
        public string CreatedBy { get; set; }


        public static List<ItemCategoriesSaleReportClass> GetAllReportByDate(DateTime date)
        {
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string searchParams = "&date=" + strDateFrom;
            var rptDailyBalance = Services.RestHepler<ItemCategoriesSaleReportClass>.Select("salesByDateAndItemCategories", searchParams);
            return rptDailyBalance;
        }
        public static List<ItemCategoriesSaleReportClass> GetReportByDateAndUser(DateTime date, string username)
        {
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string searchParams = "&date=" + strDateFrom + "&UserName=" + username;
            var rptDailyBalance = Services.RestHepler<ItemCategoriesSaleReportClass>.Select("salesByDateAndUserItemCategories", searchParams);
            return rptDailyBalance;
        }
    }

}
