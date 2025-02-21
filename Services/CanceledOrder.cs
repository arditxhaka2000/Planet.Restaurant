using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CanceledOrder : IBaseObj
    {
        public CanceledOrder() { }

        public int Id { get; set; }

        public int id_saler { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        public int Insert()
        {
            int rows = Services.RestHepler<CanceledOrder>.Insert("CanceledOrder", this);
            return rows;
        }

        public static List<CanceledOrder> getAllCanceledOrder()
        {
            return Services.RestHepler<CanceledOrder>.Search("CanceledOrder", "");
        }
        public static List<CanceledOrder> GetCanceldOrderByDate(DateTime date)
        {
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string searchParams = "&CreatedAt=" + strDateFrom;
            var rptDailyBalance = Services.RestHepler<CanceledOrder>.Select("getCanceledOrderByDate", searchParams);
            return rptDailyBalance;
        }
        public static List<CanceledOrder> GetCanceldOrderByDateAndUser(DateTime date, string username)
        {
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string searchParams = "&CreatedAt=" + strDateFrom + "&CreatedBy=" + username;
            var rptDailyBalance = Services.RestHepler<CanceledOrder>.Select("getCanceledOrderByDateAndUser", searchParams);
            return rptDailyBalance;
        }
    }
}