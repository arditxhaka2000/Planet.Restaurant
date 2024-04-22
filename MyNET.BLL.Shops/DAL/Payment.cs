using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{
    public class Payment : MyNET.Entities.Payment
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
        public Payment()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Payment(MyNET.Entities.Payment obj)
        {
            mId = obj.Id;
            mDate = obj.Date;
            mNo = obj.No;
            //mPaymentBankId = obj.PaymentBankId;
            mDescription = obj.Description;
            mDocumentId = obj.DocumentId;
            mPartnerId = obj.PartnerId;
            mPaymentType = obj.PaymentType;
            mProjectId = obj.ProjectId;
            mWarehouseId = obj.WarehouseId;
            mUserId = obj.UserId;
            mCashBoxId = obj.CashBoxId;
            mBankId = obj.BankId;
            mAccountId = obj.AccountId;
            //mDebit = obj.Debit;
            mAmountPaid = obj.AmountPaid;
            //mBill = obj.Bill;
            mCreatedAt = obj.CreatedAt;
            mChangedAt = obj.ChangedAt;
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Payment(MyNET.Models.Payment obj)
        {
            mId = obj.Id;
            mDate = obj.Date;
            mNo = obj.No;
            mDescription = obj.Description;
            mDocumentId = obj.DocumentId;
            mPartnerId = obj.PartnerId;
            mPaymentType = obj.PaymentType;
            mProjectId = obj.ProjectId;
            mWarehouseId = obj.WarehouseId;
            mUserId = obj.UserId;
            mCashBoxId = obj.CashBoxId;
            mBankId = obj.BankId;
            mAccountId = obj.AccountId;
            //mDebit = obj.Debit;
            mAmountPaid = obj.AmountPaid;
            mCreatedAt = obj.CreatedAt;
            mChangedAt = obj.ChangedAt;
        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public Payment(long Id)
        {
            string strquery = "GetPayment";

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                LoadFromReader(dr);

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            dr.Dispose();
        }

        /// <summary>
        /// Load object from reader 
        /// </summary>
        /// <param name="dr">DataReader object</param>		
        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);

                if (!dr.IsDBNull(dr.GetOrdinal("Date"))) this.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                if (!dr.IsDBNull(dr.GetOrdinal("Description"))) this.Description = dr.GetString(dr.GetOrdinal("Description"));                
                if (!dr.IsDBNull(dr.GetOrdinal("PartnerId"))) this.PartnerId = dr.GetInt32(dr.GetOrdinal("PartnerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("PaymentType"))) this.PaymentType = dr.GetInt32(dr.GetOrdinal("PaymentType"));
                if (!dr.IsDBNull(dr.GetOrdinal("WarehouseId"))) this.WarehouseId = dr.GetInt32(dr.GetOrdinal("WarehouseId"));
                if (!dr.IsDBNull(dr.GetOrdinal("UserId"))) this.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
                if (!dr.IsDBNull(dr.GetOrdinal("BankId"))) this.BankId = dr.GetInt32(dr.GetOrdinal("BankId"));
                if (!dr.IsDBNull(dr.GetOrdinal("CashBoxId"))) this.CashBoxId = dr.GetInt32(dr.GetOrdinal("CashBoxId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ProjectId"))) this.ProjectId = dr.GetInt32(dr.GetOrdinal("ProjectId"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountId"))) this.AccountId = dr.GetInt32(dr.GetOrdinal("AccountId"));
                //if (!dr.IsDBNull(dr.GetOrdinal("Debit"))) this.Debit = dr.GetDecimal(dr.GetOrdinal("Debit"));
                if (!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) this.AmountPaid = dr.GetDecimal(dr.GetOrdinal("AmountPaid"));
                //if (!dr.IsDBNull(dr.GetOrdinal("CreatedAt"))) this.CreatedAt = dr.GetDateTime(dr.GetOrdinal("CreatedAt"));
                //if (!dr.IsDBNull(dr.GetOrdinal("ChangedAt"))) this.ChangedAt = dr.GetDateTime(dr.GetOrdinal("ChangedAt"));

                //if (!dr.IsDBNull(13)) this.Bill = dr.GetInt32(13);
            }
        }

        public Payment(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static Payment Get(int Id)
        {
            return new Payment(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static ArrayList Get()
        {
            string strquery = "GetPayments";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            Payment retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Payment(dr);
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

        /// <summary>
    
       

        


        /// <param name="WhereCondition">Where conditions</param>
        /// <param name="OrderByExpression">Order by</param>
        /// <returns>List of objects</returns>
        public static ArrayList Search(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchPayments";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;
            SqlDataReader dr = null;
            Payment retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Payment(dr);
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

        public static DataTable SearchPayment(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchPayments";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;
            DataTable retobjs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(retobjs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return retobjs;
        }

        public static DataTable SearchCashBox(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchCashBox";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;
            DataTable retobjs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(retobjs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return retobjs;
        }
        public static DataTable SearchBank(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchBank";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;
            DataTable retobjs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(retobjs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return retobjs;
        }

        public static DataTable GetSaldoByPartnerId()
        {
            string strquery = "GetSaldoByPartnerId";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouseid;
            DataTable retobjs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(retobjs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return retobjs;
        }
        public static DataTable GetCoffeeSaldoByPartnerId()
        {
            string strquery = "GetCoffeeSaldoByPartnerId";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouseid;
            DataTable retobjs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(retobjs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return retobjs;
        }


        public static List<MyNET.DAL.Payment> GetPaymentsBank(int Id)
        {
            string strquery = "SELECT Id,Date,DocumentId,Description,PartnerID,PaymentType,ProjectID,WarehouseId,CashBoxId,BankId,UserId,AccountId,Debit,AmountPaid,0 Status,ChangedAt  FROM Payments WHERE Id = @Id";

            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            //cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            SqlDataReader dr = null;

            List<MyNET.DAL.Payment> retobjs = new List<MyNET.DAL.Payment>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MyNET.DAL.Payment retobj = new MyNET.DAL.Payment(dr);
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

        public static List<MyNET.DAL.Payment> GetPaymentsCash(int Id)
        {
            string strquery = "SELECT Id,Date,DocumentId,Description,PartnerID,PaymentType,ProjectID,WarehouseId,CashBoxId,BankId,UserId,AccountId,Debit,AmountPaid,0 Status,ChangedAt  FROM Payments WHERE ID = @Id";

            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            //cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            SqlDataReader dr = null;

            List<MyNET.DAL.Payment> retobjs = new List<MyNET.DAL.Payment>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MyNET.DAL.Payment retobj = new MyNET.DAL.Payment(dr);
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

        //public static List<MyNET.DAL.Payment> GetPaymentsSaldo(int Id)
        //{
        //    string strquery = "SELECT Id,Date,DocumentId,Description,PartnerID,PaymentType,ProjectID,WarehouseId,CashBoxId,BankId,UserId,AccountId,Debit,AmountPaid,0 Status,ChangedAt  FROM Payments WHERE  Id = @Id";

        //    SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        //    SqlCommand cmd = new SqlCommand(strquery, cnn);

        //    //cmd.Parameters.AddWithValue("@Date", Date);
        //    //cmd.Parameters.Add("@I", SqlDbType.DateTime).Value = Date;
        //    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        //    SqlDataReader dr = null;

        //    List<MyNET.DAL.Payment> retobjs = new List<MyNET.DAL.Payment>();
        //    try
        //    {
        //        if (cnn.State == System.Data.ConnectionState.Closed)
        //            cnn.Open();
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            MyNET.DAL.Payment retobj = new MyNET.DAL.Payment(dr);
        //            retobjs.Add(retobj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (cnn.State == System.Data.ConnectionState.Open)
        //            cnn.Close();
        //        dr.Dispose();
        //    }

        //    return retobjs;
        //}
        #endregion

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        /// 
        public int Insert()
        {
            string strquery = "InsertPayment";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            //cmd.Parameters.Add("@PaymentBankId", SqlDbType.Int).Value = PaymentBankId;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
            cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = PartnerId;
            cmd.Parameters.Add("@PaymentType", SqlDbType.Int).Value = PaymentType;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = WarehouseId;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
            cmd.Parameters.Add("@BankId", SqlDbType.Int).Value = BankId;
            //cmd.Parameters.Add("@Debit", SqlDbType.Decimal).Value = Debit;
            cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = AmountPaid;
            cmd.Parameters.Add("@CashBoxId", SqlDbType.Int).Value = CashBoxId;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = AccountId;
            cmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = DateTime.Now;

            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);
            try
            {

                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                cmd.ExecuteNonQuery();
                retval = (int)rowsaffected.Value;
                this.Id = (int)Id.Value;
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
        
        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            string strquery = "UpdatePayment";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
            cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = PartnerId;
            cmd.Parameters.Add("@PaymentType", SqlDbType.Int).Value = PaymentType;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = WarehouseId;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
            cmd.Parameters.Add("@BankId", SqlDbType.Int).Value = BankId;
            //cmd.Parameters.Add("@Debit", SqlDbType.Decimal).Value = Debit;
            cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = AmountPaid;
            cmd.Parameters.Add("@CashBoxId", SqlDbType.Int).Value = CashBoxId;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = AccountId;
            cmd.Parameters.Add("@ChangedAt", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();

            int retval = (int)rowsaffected.Value;

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }

        
        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string strquery = "DeletePayments";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();

            int retval = (int)rowsaffected.Value;

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }

        #endregion

        
    }
}
