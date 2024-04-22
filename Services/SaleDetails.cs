using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleDetails : IBaseObj
    {
        #region Public Properties

        public int Id { get; set; }

        public int SaleId { get; set; }

        public int No { get; set; }

        public decimal Discount { get; set; }

        public int ItemId { get; set; }

        public int ProjectId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal AvgPrice { get; set; }

        public int VAT { get; set; }

        public decimal VatSum { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ChangedAt { get; set; }

        public string ChangedBy { get; set; }

        public int Status { get; set; }
        public int Printed { get; set; }
        public decimal ClientDiscount { get; set; }
        public int PrintedQuantity { get; set; }
        public bool ForReturn { get; set; }
        public string ItemNumber { get; set; }
        public string DiscountAmount { get; set; } = "0";
        public string PosId { get; set; }


        #endregion

        public static List<Services.Models.SaleDetails> GetSaleDetailsBySaleId(int saleId)
        {
            var items = Services.RestHepler<Services.Models.SaleDetails>.Select("GetSaleDetailsBySaleId", "saleId=" + saleId);
            return items;
        }
        public static List<Services.SaleDetails> GetSdById(int saleId)
        {
            var items = Services.RestHepler<Services.SaleDetails>.Select("GetSaleDetailsBySaleId", "saleId=" + saleId);
            return items;
        }

        public static List<SaleDetails> getSalesDetailsByDate(DateTime dateFrom, DateTime dateTo)
        {
            //string strDateFrom = dateFrom.AddHours(-2).ToString("O");
            //string strDateTo = dateTo.AddHours(-2).ToString("O");
            string strDateFrom = dateFrom.ToString("O");
            string strDateTo = dateTo.ToString("O");
            string searchParams ="&DateFrom=" + strDateFrom + "&DateTo=" + strDateTo;
            var getsalesByDate = Services.RestHepler <SaleDetails>.Select("getSalesDetailsByDate", searchParams);
            return getsalesByDate;
        } 
        public static List<SaleS> getSalesDetailsByDateAndEmp(DateTime dateFrom, DateTime dateTo, int sellerId)
        {
            //string strDateFrom = dateFrom.AddHours(-2).ToString("O");
            //string strDateTo = dateTo.AddHours(-2).ToString("O");
            string strDateFrom = dateFrom.ToString("O");
            string strDateTo = dateTo.ToString("O");
            string searchParams ="&DateFrom=" + strDateFrom + "&DateTo=" + strDateTo + "&id_saler=" + sellerId;
            var getsalesByDate = Services.RestHepler <SaleS>.Select("getSalesDetailsByDateAndEmp", searchParams);
            return getsalesByDate;
        }
        public static List<SaleDetails> UpdatePrinted(int saleId)
        {
            string searchParams = "SaleId=" + saleId;
            var getsalesByDate = Services.RestHepler <SaleDetails>.Select("updatePrinted", searchParams);
            return getsalesByDate;
        }
        public static int UpdateDiscount(int saleId,decimal discount)
        {
            string searchParams = "SaleId=" + saleId + "&Discount="+discount;
            var res = Services.RestHepler <SaleDetails>.Query("updateDiscount", searchParams);
            return res;
        } 
        public static List<SaleDetails> getUnprintedInvoice()
        {
            var getUnPrinted = Services.RestHepler <SaleDetails>.Select("getUnprintedInvoice", "");
            return getUnPrinted;
        } 

        public static SaleDetails GetById(int id)
        {
            var item = Services.RestHepler<SaleDetails>.Get("salesdetails", id);
            return item;
        }
        
        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            int rows = Services.RestHepler<SaleDetails>.Insert("salesdetails", this);
            return rows;
        }
        public static int BatchInsert(List<SaleDetails> saleDetails)
        {
            int row = Services.RestHepler<SaleDetails>.BatchInsert("salesdetails", saleDetails);
            return row;
        }

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int rows = Services.RestHepler<SaleDetails>.Update("salesdetails", this);
            return rows;
        }

        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        //public int Delete(string username = "")
        //{
        //    int rows = Services.RestHepler<SaleDetails>.Delete("salesdetails", this);
        //    return rows;
        //}

        #endregion
    }

    public class SaleS
    {
        public int Id { get; set; }

        public int SaleId { get; set; }

        public int No { get; set; }

        public decimal Discount { get; set; }

        public int ItemId { get; set; }
        public string ItemNumber { get; set; }

        public int id_saler { get; set; }

        public int ProjectId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal AvgPrice { get; set; }

        public int Vat { get; set; }

        public decimal VatSum { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ChangedAt { get; set; }

        public string ChangedBy { get; set; }

        public int Status { get; set; }
        public int Printed { get; set; }
    }
}
