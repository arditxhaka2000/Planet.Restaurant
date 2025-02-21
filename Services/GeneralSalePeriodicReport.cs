using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GeneralSalePeriodicReport
    {
        public GeneralSalePeriodicReport() { }
        public decimal TotalAmount { get; set; }
        public decimal VatAmount { get; set; }
        public int TotalSalesCount { get; set; }
        public decimal TotalNoVatAmount { get; set; }
        public decimal TotalVat8Amount { get; set; }
        public decimal TotalVat18Amount { get; set; }
        public decimal Vat8Amount { get; set; }
        public decimal Vat18Amount { get; set; }

        public static List<GeneralSalePeriodicReport> GeneralSalesByDate(string fromDate, string toDate)
        {
            string searchParams = "&FromDate=" + fromDate + "&ToDate=" + toDate;
            var rptDailyBalance = Services.RestHepler<GeneralSalePeriodicReport>.Select("searchsalesbyDate", searchParams);
            return rptDailyBalance;
        }
        public static List<GeneralSalePeriodicReport> GeneralSalesByDateAndUser(string fromDate, string toDate, int id_saler)
        {
            string searchParams = "&FromDate=" + fromDate + "&ToDate=" + toDate + "&id_saler=" + id_saler;
            var rptDailyBalance = Services.RestHepler<GeneralSalePeriodicReport>.Select("searchsalesbyDateAndUser", searchParams);
            return rptDailyBalance;
        }
    }
}
