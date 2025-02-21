using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.Models;


namespace Services
{
    public class DailyOpenCloseBalance : IBaseObj
    {
        #region Public Properties

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }       
        public int StationId { get; set; }       
        public int DailyFiscalCount { get; set; }       
        public decimal TotalShitje { get; set; }
        public decimal TotalCash { get; set; }
        public decimal TotalCreditCard { get; set; }
        public decimal Amount { get; set; }
        public decimal neArke { get; set; }
        public string Status { get; set; }



        #endregion

        public DailyOpenCloseBalance()
        {

        }

        public static DailyOpenCloseBalance Get(int id)
        {
            return RestHepler<DailyOpenCloseBalance>.Get("DailyOpenCloseBalance", id);

        }

        public static DailyOpenCloseBalance GetLastDailyBalance(int stationId)
        {
            string searchParams = "stationId=" + stationId;
            var last = Services.RestHepler<DailyOpenCloseBalance>.Select("getLastDailyBalance", searchParams);
            return last.FirstOrDefault();
        }
     
        public static DailyOpenCloseBalance GetLastDailyBalanceByEmployee(int userId)
        {
            string searchParams = "UserId=" + userId;
            var last = Services.RestHepler<DailyOpenCloseBalance>.Select("getLastDailyBalanceByEmployee", searchParams);
            return last.FirstOrDefault();
        }
        public static List<DailyOpenCloseBalance> GetDailyBalance(int userId)
        {
            string searchParams = "UserId=" + userId;
            var last = Services.RestHepler<DailyOpenCloseBalance>.Select("getDailyBalance", searchParams);
            return last;
        }
        public static List<DailyBalance> GetDailyBalance(int stationId, DateTime date)
        {
            DateTime dateTo = date.AddDays(1);
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string strDateTo = dateTo.ToString("yyyy-MM-dd");

            string searchParams = "StationId=" + stationId + "&DateFrom=" + strDateFrom + "&DateTo=" + strDateTo;
            var rptDailyBalance = Services.RestHepler<DailyBalance>.Select("rptDailyBalance", searchParams);
            return rptDailyBalance;
        }
        public static List<DailyOpenCloseBalance> GetDailyBalanceByDay(DateTime date)
        {
            string strDateFrom = date.ToString("yyyy-MM-dd");
            string searchParams = "&date=" + strDateFrom;
            var rptDailyBalance = Services.RestHepler<DailyOpenCloseBalance>.Select("GetDailyBalanceByDay", searchParams);
            return rptDailyBalance;
        }
        public static List<DailyBalance> GetBalanceReportByDays(int stationId, DateTime dateFrom, DateTime dateTo)
        {
            string strDateFrom = dateFrom.ToString("yyyy-MM-ddTHH:mm:ss");
            string strDateTo = dateTo.ToString("yyyy-MM-ddTHH:mm:ss");

            string searchParams = "StationId=" + stationId + "&DateFrom=" + strDateFrom + "&DateTo=" + strDateTo;
            var rptDailyBalance = Services.RestHepler<DailyBalance>.Select("rptDailyBalance", searchParams);
            return rptDailyBalance;
        }
    
        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            int rows = Services.RestHepler<DailyOpenCloseBalance>.Insert("DailyOpenCloseBalance", this);
            return rows;
        }

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int rows = Services.RestHepler<DailyOpenCloseBalance>.Update("DailyOpenCloseBalance", this);
            return rows;
        }
        public void UpdateDFC(string count,decimal totalShitje,decimal cash,decimal creditcard, int stationId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { DailyFiscalCount = count, TotalShitje = totalShitje, TotalCash = cash, TotalCreditCard = creditcard, id = stationId }) ;
            Services.RestHepler<Settings>.RestaurantQuery("updateDFC", jsonParams);

        }


        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        //public int Delete(string username = "")
        //{
        //    int rows = Services.RestHepler<DailyOpenCloseBalance>.Delete("DailyOpenCloseBalance", this);
        //    return rows;
        //}

        #endregion 
    }
}
