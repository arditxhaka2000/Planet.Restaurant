using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleDetails_Archive : IBaseObj
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
        public string TableId { get; set; }


        #endregion

        public static List<Services.Models.SaleDetails_Archive> GetSaleDetailsBySaleId(int saleId)
        {
            var items = Services.RestHepler<Services.Models.SaleDetails_Archive>.Select("GetSaleDetailsBySaleId", "saleId=" + saleId);
            return items;
        }
        public static List<Services.SaleDetails_Archive> GetSdById(int saleId)
        {
            var items = Services.RestHepler<Services.SaleDetails_Archive>.Select("GetSaleDetailsBySaleId", "saleId=" + saleId);
            return items;
        }

        public static List<SaleDetails_Archive> getSalesDetailsByDate(DateTime dateFrom, DateTime dateTo)
        {
            //string strDateFrom = dateFrom.AddHours(-2).ToString("O");
            //string strDateTo = dateTo.AddHours(-2).ToString("O");
            string strDateFrom = dateFrom.ToString("O");
            string strDateTo = dateTo.ToString("O");
            string searchParams ="&DateFrom=" + strDateFrom + "&DateTo=" + strDateTo;
            var getsalesByDate = Services.RestHepler <SaleDetails_Archive>.Select("getSalesDetailsByDate", searchParams);
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
        public static List<SaleDetails_Archive> UpdatePrinted(int saleId)
        {
            string searchParams = "SaleId=" + saleId;
            var getsalesByDate = Services.RestHepler <SaleDetails_Archive>.Select("updatePrinted", searchParams);
            return getsalesByDate;
        }
        public static int UpdateDiscount(int saleId,decimal discount)
        {
            string searchParams = "SaleId=" + saleId + "&Discount="+discount;
            var res = Services.RestHepler <SaleDetails_Archive>.Query("updateDiscount", searchParams);
            return res;
        } 
        public static List<SaleDetails_Archive> getUnprintedInvoice()
        {
            var getUnPrinted = Services.RestHepler <SaleDetails_Archive>.Select("getUnprintedInvoice", "");
            return getUnPrinted;
        } 

        public static SaleDetails_Archive GetById(int id)
        {
            var item = Services.RestHepler<SaleDetails_Archive>.Get("salesdetails", id);
            return item;
        }
        
        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            int rows = Services.RestHepler<SaleDetails_Archive>.Insert("salesdetails", this);
            return rows;
        }
        public static int BatchInsert(List<SaleDetails_Archive> saleDetails)
        {
            int row = Services.RestHepler<SaleDetails_Archive>.BatchInsert("salesdetails", saleDetails);
            return row;
        }

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int rows = Services.RestHepler<SaleDetails_Archive>.Update("salesdetails", this);
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

}
