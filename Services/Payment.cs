using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Services
{
    public class Payment : IBaseObj
    {
        #region Class properties

        public int Id { get; set; }
       
        public int BankId { get; set; }
        public decimal AmountPaid { get; set; } = 0.0M;
        public int SaleId { get; set; }
        public decimal ClientCash { get; set; } = 0.0M;


        #endregion properties

        #region public static Get Methods

        public static Payment Get(int id)
        {
            Payment item = Services.RestHepler<Payment>.Get("payments", id);
            return item;
        }

        /// <summary>
        /// Get all items by type
        /// </summary>
        /// <returns>List of Payments</returns>
        ///
        public static List<Payment> GetBySaleId(int PaymentId)
        {
            List<Payment> items = Services.RestHepler<Payment>.Search("payments", "SaleId="+ PaymentId);
            return items;
        }
        #endregion

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            int rows = Services.RestHepler<Payment>.Insert("payments", this);
            return rows;
        }
        public static int BatchInsert(List<Payment> payments)
        {
            int row = Services.RestHepler<Payment>.BatchInsert("payments", payments);
            return row;
        }
        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int rows = Services.RestHepler<Payment>.Update("payments", this);
            return rows;
        }    

        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        //public int Delete()
        //{
        //    int rows = Services.RestHepler<Payment>.Delete("payments", this);
        //    return rows;
        //}

        #endregion
    }

}
