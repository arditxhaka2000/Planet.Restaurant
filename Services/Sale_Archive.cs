using Newtonsoft.Json;
using RestSharp;
using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;

namespace Services
{
    public class Sale_Archive : IBaseObj
    {

        #region Public Properties

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public long SaleId { get; set; }
        public int PosId { get; set; }
        public int StationId { get; set; }
        public string InvoiceNo { get; set; }
        public string Send_Email { get; set; }
        public int id_saler { get; set; }
        public string Reference { get; set; }
        public int PartnerId { get; set; }
        public int PaymentMethod { get; set; }
        public int SalesTypeId { get; set; }
        public decimal TotalSum { get; set; }
        public bool Export { get; set; }
        public decimal VatSum { get; set; }
        public string Comment { get; set; }
        public bool Printed { get; set; }
        public decimal CouponNo { get; set; }
        public int ConvertBill { get; set; } = 0;
        public int SentConvert { get; set; } = 0;
        public int FromRestaurant { get; set; } = 0;

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ChangedAt { get; set; }
        public string ChangedBy { get; set; }
        public int Status { get; set; }

        #endregion


        public Sale_Archive()
        {

        }

        public static Sale_Archive Get(int id)
        {
            return RestHepler<Sale_Archive>.Get("sales_archive", id);
        }

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            int rows = Services.RestHepler<Sale_Archive>.Insert("sales_archive", this);
            return rows;
        }

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int rows = Services.RestHepler<Sale_Archive>.Update("sales_archive", this);
            return rows;
        }

        public static void ChngPrintStatus(int saleId, bool printed)
        {
            string jsonParams = JsonConvert.SerializeObject(new { saleId = saleId, printed = printed });
            //string parms = "saleId=" + saleId + "&printed=" + printed;
            Services.RestHepler<Sale_Archive>.Query("ChngPrintStatus", jsonParams);
        }
        public static List<Sale_Archive> getAllSales()
        {
            return Services.RestHepler<Sale_Archive>.Search("sales_archive", "");
        }
        public static List<Sale_Archive> getAllSalesPosId(string posId)
        {
            string searchParams = "&PosId=" + posId;
            return Services.RestHepler<Sale_Archive>.Search("sales_archive", searchParams);
        }
        public static List<Sale_Archive> getAllSalesPrintedSd(string posId)
        {
            string searchParams = "&PosId=" + posId;
            return Services.RestHepler<Sale_Archive>.Select("salesSd", searchParams);
        }
        public static int getSalesCount()
        {
            return Services.RestHepler<int>.SelectCount("salesCount", "");

        }
        public static int getSalesCountWithPosId(string posId)
        {
            string searchParams = "&PosId=" + posId;

            return Services.RestHepler<int>.SelectCount("salesCountPosId", searchParams);

        }
        public static List<Sale_Archive> getSalesWithParams(string total, string date)
        {
            string searchParams = "&TotalSum=" + total + "&Date=" + date;

            return Services.RestHepler<Sale_Archive>.Select("searchS", searchParams);
        }
        public static Sale_Archive GetLastSaleByStation(string posId)
        {
            string searchParams = "&PosId=" + posId;

            return Services.RestHepler<Sale_Archive>.Select("getlastSaleByStation", searchParams).First();
        }

        public static void ChngStatus(int saleId, int status)
        {
            string jsonParams = JsonConvert.SerializeObject(new { saleId = saleId, status = status });
            //string parms = "saleId=" + saleId + "&status=" + status;
            Services.RestHepler<Sale_Archive>.Query("ChngStatus", jsonParams);
        }
        public static void IdSaler(int saleId, int id_saler)
        {
            string jsonParams = JsonConvert.SerializeObject(new { saleId = saleId, id_saler = id_saler });
            //string parms = "saleId=" + saleId + "&status=" + status;
            Services.RestHepler<Sale_Archive>.Query("ChngIdSaler", jsonParams);
        }
        public static void updateConvert(int saleId, int partnerId, int convert)
        {
            string jsonParams = JsonConvert.SerializeObject(new { saleId = saleId, PartnerId = partnerId, ConvertBill = convert });
            Services.RestHepler<Sale_Archive>.Query("updateConvert", jsonParams);
        }
        public static void updateSendEmail(int saleId, string sendemail)
        {
            string jsonParams = JsonConvert.SerializeObject(new { saleId = saleId, Send_Email = sendemail });
            Services.RestHepler<Sale_Archive>.Query("updateSendEmail", jsonParams);
        }
        public static int CheckInvoiceNo(int saleId)
        {
            string jsonParams = JsonConvert.SerializeObject(new { saleId = saleId });
            var row = Services.RestHepler<Sale_Archive>.Query("CheckInvoiceNo", jsonParams);
            return row;
        }
        public static int UpdateTotalSum(decimal totals, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { TotalSum = totals, saleId = id });
            var row = Services.RestHepler<Sale_Archive>.Query("updateTotalSum", jsonParams);
            return row;
        }
        public static List<Sale_Archive> SalesByDate(string dateFrom, string dateTo)
        {
            string searchParams = "&FromDate=" + dateFrom + "&ToDate=" + dateTo;
            return Services.RestHepler<Sale_Archive>.Select("searchsales_archive", searchParams);

        }
       
        //public static List<Dictionary<string, object>> SalesByDateNoStock(string dateFrom, string dateTo)
        //{
        //    string searchParams = "&FromDate=" + dateFrom + "&ToDate=" + dateTo;
        //    return Services.RestHepler<Dictionary<string, object>>.Select("reportSaleNoStock", searchParams);

        //}
        public static List<Dictionary<string, object>> StockMinus()
        {
            return Services.RestHepler<Dictionary<string, object>>.Select("reportStockWithMinus", "");

        }


        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        //public int Delete(string username = "")
        //{
        //    int rows = Services.RestHepler<Sale>.Delete("sales", this);
        //    return rows;
        //}

        #endregion


    }


}