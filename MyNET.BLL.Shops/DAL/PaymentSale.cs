using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{
   public class PaymentSale : MyNET.Entities.PaymentSale
    {
        #region Class members

        ///Conection to database
        protected SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        ///Staric member connection
        protected static SqlConnection statcnn = new SqlConnection(Constants.Connectionstr());


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PaymentSale()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public PaymentSale(MyNET.Entities.PaymentSale obj)
        {            
            PaymentId = obj.PaymentId;
            SaleId = obj.SaleId;
            AmountPaid = obj.AmountPaid;
        }

        /// <summary>
        /// Load object from reader 
        /// </summary>
        /// <param name="dr">DataReader object</param>		
        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                if (!dr.IsDBNull(dr.GetOrdinal("PaymentId"))) this.PaymentId = dr.GetInt32(dr.GetOrdinal("PaymentId"));
                if (!dr.IsDBNull(dr.GetOrdinal("SaleId"))) this.SaleId = dr.GetInt32(dr.GetOrdinal("SaleId"));
                if (!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) this.AmountPaid = dr.GetDecimal(dr.GetOrdinal("AmountPaid"));
            }
        }

        public PaymentSale(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        public static List<PaymentSale> Get(int saleid)
        {
            //return null;

            string strquery = "GetPaymentSales";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.AddWithValue("@SaleId", saleid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;

            List<PaymentSale> retobjs = new List<PaymentSale>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PaymentSale retobj = new PaymentSale(dr);
                    retobjs.Add(retobj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
                dr.Dispose();
            }
           
            return retobjs;
        }

        public static List<MyNET.Models.PaymentSale> Get(int partnerid, int saleid)
        {
            string strquery = "GetPaymentSale";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.AddWithValue("@PartnerId", partnerid);
            cmd.Parameters.AddWithValue("@SaleId", saleid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;

            List<MyNET.Models.PaymentSale> retobjs = new List<MyNET.Models.PaymentSale>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MyNET.Models.PaymentSale retobj = new MyNET.Models.PaymentSale();
                    retobj.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    retobj.InvoiceNo = dr.GetString(dr.GetOrdinal("InvoiceNo"));
                    retobj.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    retobj.PartnerId = dr.GetInt32(dr.GetOrdinal("PartnerId"));
                    retobj.PartnerName = dr.GetString(dr.GetOrdinal("PartnerName"));
                    retobj.AmountPaid = dr.GetDecimal(dr.GetOrdinal("AmountPaid"));
                    retobj.Debts = dr.GetDecimal(dr.GetOrdinal("Debts"));
                    retobj.TotalSum = dr.GetDecimal(dr.GetOrdinal("TotalSum"));
                    retobjs.Add(retobj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
                dr.Dispose();
            }
            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        #endregion

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        ///         
        public int Insert()
        {
            string strquery = "InsertPaymentSales";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            
            cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = PaymentId;
            cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = SaleId;
            cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = AmountPaid;
            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);
            try
            {

                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                cmd.ExecuteNonQuery();
                retval = (int)rowsaffected.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
            }
            return retval;
        }

        //public int Update()
        //{
        //    string strquery = "UpdatePaymentSales";
        //    SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        //    SqlCommand cmd = new SqlCommand(strquery, cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = PaymentId;
        //    cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = SaleId;
        //    cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = AmountPaid;
           
        //    SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
        //    rowsaffected.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(rowsaffected);
        //    int retval = 0;
        //    try
        //    {
        //        if (cnn.State == System.Data.ConnectionState.Closed)
        //            cnn.Open();
        //        cmd.ExecuteNonQuery();
        //        retval = (int)rowsaffected.Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;
        //    }
        //    return retval;
        //}

        //public int Delete()
        //{
        //    string strquery = "DeletePaymentSaleSale";
        //    SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        //    SqlCommand cmd = new SqlCommand(strquery, cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = SaleId;

        //    SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
        //    rowsaffected.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(rowsaffected);
        //    int retval = 0;
        //    try
        //    {
        //        if (cnn.State == System.Data.ConnectionState.Closed)
        //            cnn.Open();
        //        cmd.ExecuteNonQuery();
        //        retval = (int)rowsaffected.Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (cnn.State == System.Data.ConnectionState.Open)
        //            cnn.Close();
        //    }
        //    return retval;
        //}


        #endregion
    }
}
