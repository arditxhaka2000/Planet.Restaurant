using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace MyNET.DAL
{

    /// <summary>
    /// This object represents the properties and methods of a Sale.
    /// </summary>
    public class Sale : MyNET.Entities.Sale
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Sale()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Sale(MyNET.Entities.Sale obj)
        {
            mId = obj.Id;
            mDate = obj.Date;
            mSaleId = obj.SaleId;
            mInvoiceNo = obj.InvoiceNo;
            mReference = obj.Reference;
            mPartnerId = obj.PartnerId;
            mPaymentMethodId = obj.PaymentMethodId;
            mSaleTypeId = obj.SalesTypeId;            
            mTotalSum = obj.TotalSum;
            mWithVat = obj.WithVat;
            mExport = obj.Export;
            mVatSum = obj.VatSum;
            mCurrency = obj.Currency;
            mCurrencyRate = obj.CurrencyRate;
            mComment = obj.Comment;
            mPrinted = obj.Printed;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;

        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public Sale(long Id)
        {
            string strquery = "GetSale";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    LoadFromReader(dr);
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
                //if (!dr.IsDBNull(dr.GetOrdinal("EndDate"))) this.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
                if (!dr.IsDBNull(dr.GetOrdinal("SaleId"))) this.SaleId = dr.GetInt32(dr.GetOrdinal("SaleId"));
                //if (!dr.IsDBNull(dr.GetOrdinal("SaleType"))) this.SaleType = dr.GetInt32(dr.GetOrdinal("SaleType"));
                if (!dr.IsDBNull(dr.GetOrdinal("CashBoxId"))) this.CashBoxId = dr.GetInt32(dr.GetOrdinal("CashBoxId"));
                if (!dr.IsDBNull(dr.GetOrdinal("StationId"))) this.StationId = dr.GetInt32(dr.GetOrdinal("StationId"));
                if (!dr.IsDBNull(dr.GetOrdinal("InvoiceNo"))) this.InvoiceNo = dr.GetString(dr.GetOrdinal("InvoiceNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("Reference"))) this.Reference = dr.GetString(dr.GetOrdinal("Reference"));
                if (!dr.IsDBNull(dr.GetOrdinal("PartnerId"))) this.PartnerId = dr.GetInt32(dr.GetOrdinal("PartnerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("SalesTypeId"))) this.SalesTypeId = dr.GetInt32(dr.GetOrdinal("SalesTypeId"));
                if (!dr.IsDBNull(dr.GetOrdinal("PaymentMethod"))) this.PaymentMethodId = dr.GetInt32(dr.GetOrdinal("PaymentMethod"));
                //if (!dr.IsDBNull(dr.GetOrdinal("TotalCash"))) this.TotalCash = dr.GetDecimal(dr.GetOrdinal("TotalCash"));
                //if (!dr.IsDBNull(dr.GetOrdinal("TotalCoupon"))) this.TotalCoupon = dr.GetDecimal(dr.GetOrdinal("TotalCoupon"));
                //if (!dr.IsDBNull(dr.GetOrdinal("TotalCheck"))) this.TotalCheck = dr.GetDecimal(dr.GetOrdinal("TotalCheck"));
                //if (!dr.IsDBNull(dr.GetOrdinal("TotalAmountPaidCard"))) this.TotalAmountPaidCard = dr.GetDecimal(dr.GetOrdinal("TotalAmountPaidCard"));
                if (!dr.IsDBNull(dr.GetOrdinal("TotalSum"))) this.TotalSum = dr.GetDecimal(dr.GetOrdinal("TotalSum"));
                if (!dr.IsDBNull(dr.GetOrdinal("WithVat"))) this.WithVat = dr.GetBoolean(dr.GetOrdinal("WithVat"));
                if (!dr.IsDBNull(dr.GetOrdinal("Export"))) this.Export = dr.GetBoolean(dr.GetOrdinal("Export"));
                if (!dr.IsDBNull(dr.GetOrdinal("VatSum"))) this.VatSum = dr.GetDecimal(dr.GetOrdinal("VatSum"));
                if (!dr.IsDBNull(dr.GetOrdinal("Currency"))) this.Currency = dr.GetString(dr.GetOrdinal("Currency"));
                if (!dr.IsDBNull(dr.GetOrdinal("CurrencyRate"))) this.CurrencyRate = dr.GetDecimal(dr.GetOrdinal("CurrencyRate"));
                if (!dr.IsDBNull(dr.GetOrdinal("Comment"))) this.Comment = dr.GetString(dr.GetOrdinal("Comment"));
                //if (!dr.IsDBNull(dr.GetOrdinal("PrintFiscal"))) this.PrintFiscal = dr.GetBoolean(dr.GetOrdinal("PrintFiscal"));
                if (!dr.IsDBNull(dr.GetOrdinal("Printed"))) this.Printed = dr.GetBoolean(dr.GetOrdinal("Printed"));
                if (!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) this.AmountPaid = dr.GetDateTime(dr.GetOrdinal("AmountPaid"));
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedBy"))) this.CreatedBy = dr.GetString(dr.GetOrdinal("CreatedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedAt"))) this.ChangedAt = dr.GetDateTime(dr.GetOrdinal("ChangedAt"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedBy"))) this.ChangedBy = dr.GetString(dr.GetOrdinal("ChangedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("Status"))) this.Status = dr.GetInt32(dr.GetOrdinal("Status"));
            }
        }

        public Sale(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static Sale Get(long Id)
        {
            return new Sale(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static ArrayList Get()
        {
            string strquery = "GetSales";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            Sale retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Sale(dr);
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
        /// Search object in table
        /// </summary>
        /// <param name="WhereCondition">Where conditions</param>
        /// <param name="OrderByExpression">Order by</param>
        /// <returns>List of objects</returns>
        public static DataTable Search(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchSales";
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

        public static DataTable RptSalesBook(string WhereCondition, string OrderByExpression)
        {
            string strquery = "RptSalesBook";
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

        public static DataTable GetSalesByPartnerID(int partnerId)
        {
            string strquery = "GetSalesByPartnerID";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartnerID", SqlDbType.Int).Value = partnerId;
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

        public static DataTable RptSalesBookNew(DateTime? fromDate, DateTime? toDate, int warehouse, int partner, int purchasetype)
        {
            string strquery = "RptSalesBookNew";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fromDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = toDate;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouse;
            cmd.Parameters.Add("@CompanyBranch", SqlDbType.Int).Value = partner;
            cmd.Parameters.Add("@PurchaseType", SqlDbType.Int).Value = purchasetype;
            //cmd.Parameters.AddWithValue("@project", project);
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

        public static DataTable RptSalesBookVat(int saleType, int startmonth, int endmonth, int year, int Station)
        {
            string strquery = "RptSalesBookVat";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startmonth", startmonth);
            cmd.Parameters.AddWithValue("@endmonth", endmonth);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@Station", Station);
            cmd.Parameters.Add("@saleType", SqlDbType.Int).Value = saleType;
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

        public static DataTable GetItemsforOffers()
        {
            string strquery = "GetItemsforOffers";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
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

        public static DataTable RptSalesBookVatProject(int project, int startmonth, int endmonth, int year)
        {
            string strquery = "RptSalesBookVatProject";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startmonth", startmonth);
            cmd.Parameters.AddWithValue("@endmonth", endmonth);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.Add("@project", SqlDbType.Int).Value = project;
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

        public static DataTable GetDailySales(DateTime fromDate, DateTime toDate)
        {
            string strquery = "GetDailySales";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@From", fromDate);
            cmd.Parameters.AddWithValue("@To", toDate);

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

        /// <summary>
        /// Search object in table
        /// </summary>
        /// <param name="WhereCondition">Where conditions</param>
        /// <param name="OrderByExpression">Order by</param>
        /// <returns>List of objects</returns>
        public static DataSet GetRptSalesBook(int  startmonth, int  endmonth, int year)
        {
            string strquery = "[GetRptSalesBook]";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startmonth", startmonth);
            cmd.Parameters.AddWithValue("@endmonth", endmonth);
            cmd.Parameters.AddWithValue("@year", year);
            DataSet retobjs = new DataSet();
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

        public static DataSet RptSales(int companybranch,int startmonth, int endmonth, int year)
        {
            string strquery = "[RptAtkSaleBook]";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startmonth", startmonth);
            cmd.Parameters.AddWithValue("@endmonth", endmonth);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@companybranch", companybranch);
            DataSet retobjs = new DataSet();
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
        /// <summary>
        /// Get daily sales objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static MyNET.Models.Sale GetInvoice(int Id)
        {
            string strquery = "SELECT Distinct S.Id, S.InvoiceNo,st.Name SalesType, S.Date,S.Comment,S.TotalSum,S.Reference, " +
            " ISNULL(SUM(sd.Price * (1 - sd.Discount / 100) * sd.Quantity), 0.00) Total," +
            " ISNULL(SUM(sd8.Price * (1 - sd8.Discount / 100) * sd8.Quantity * 0.08), 0) Vat8," +
            " ISNULL(SUM(sd18.Price * (1 - sd18.Discount / 100) * sd18.Quantity * 0.18), 0) Vat18," +
            " ISNULL(SUM(sd.Price * sd.Quantity *(sd.Discount/100)) + s.TotalSum ,0) TotalBeforeDiscount," +
            " ISNULL(SUM(sd.Price * sd.Quantity *(sd.Discount/100)),0) DiscountValue," +
            " s.VatSum , " +
            " S.TotalSum + s.VatSum TotalWithVat " +
            " FROM Sales S LEFT JOIN " +
            " SalesDetails sd ON s.Id = sd.SaleId Left JOIN " +
            " SalesDetails sd8 ON sd.Id = sd8.Id AND sd8.Vat = 8 LEFT JOIN " +
            " SalesDetails sd18 ON sd.Id = sd18.Id AND sd18.Vat = 18  LEFT JOIN "+
            " SalesType st ON st.Id = s.SalesTypeId"+
            " Where s.Id = @Id " +
            " GROUP BY S.Id,S.InvoiceNo, S.Date,S.Comment,st.Name,s.TotalSum,s.VatSum,S.Reference ";

            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlDataReader dr = null;
            cmd.Parameters.AddWithValue("@Id", Id);

            MyNET.Models.Sale retobj = new MyNET.Models.Sale();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    retobj.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    retobj.InvoiceNo = dr.GetString(dr.GetOrdinal("InvoiceNo"));
                    retobj.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    retobj.SalesType = dr.GetString(dr.GetOrdinal("SalesType"));
                    retobj.Total = dr.GetDecimal(dr.GetOrdinal("Total"));
                    retobj.TotalSum = dr.GetDecimal(dr.GetOrdinal("TotalSum"));
                    retobj.Vat8 = dr.GetDecimal(dr.GetOrdinal("Vat8"));
                    retobj.Vat18 = dr.GetDecimal(dr.GetOrdinal("Vat18"));
                    retobj.VatSum = dr.GetDecimal(dr.GetOrdinal("VatSum"));
                    retobj.TotalWithVat = dr.GetDecimal(dr.GetOrdinal("TotalWithVat"));
                    retobj.DiscountValue = dr.GetDecimal(dr.GetOrdinal("DiscountValue"));
                    retobj.TotalBeforeDiscount = dr.GetDecimal(dr.GetOrdinal("TotalBeforeDiscount"));
                    retobj.Comment = dr.GetString(dr.GetOrdinal("Comment"));
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
            }

            return retobj;
        }

        public static MyNET.Models.Sale GetInvoicePos(int id)
        {
            string strquery = "SELECT Distinct S.Id, S.InvoiceNo,st.Name SalesType, S.Date,S.Comment,S.TotalSum, " +
            " ISNULL(SUM(sd.Price * (1 - sd.Discount / 100) * sd.Quantity), 0.00) Total," +
            " ISNULL(SUM(sd8.Price * (1 - sd8.Discount / 100) * sd8.Quantity * 0.08), 0) Vat8," +
            " ISNULL(SUM(sd18.Price * (1 - sd18.Discount / 100) * sd18.Quantity * 0.18), 0) Vat18," +
            " ISNULL(SUM(sd.Price * sd.Quantity *(sd.Discount/100)) + s.TotalSum ,0.00) TotalBeforeDiscount," +
            " ISNULL(SUM(sd.Price * sd.Quantity *(sd.Discount/100)),0.00) DiscountValue," +
            " s.VatSum , " +
            " S.TotalSum + s.VatSum TotalWithVat " +
            " FROM Sales S LEFT JOIN " +
            " SalesDetails sd ON s.Id = sd.SaleID Left JOIN " +
            " SalesDetails sd8 ON sd.Id = sd8.Id AND sd8.Vat = 8 LEFT JOIN " +
            " SalesDetails sd18 ON sd.Id = sd18.Id AND sd18.Vat = 18  LEFT JOIN " +
            " SalesType st ON st.Id = s.SalesTypeID" +
            " Where s.Id = @Id " +
            " GROUP BY S.Id,S.InvoiceNo, S.Date,S.Comment,st.Name,s.TotalSum,s.VatSum ";

            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlDataReader dr = null;
            cmd.Parameters.AddWithValue("@Id", id);

            MyNET.Models.Sale retobj = new MyNET.Models.Sale();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    retobj.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    retobj.InvoiceNo = dr.GetString(dr.GetOrdinal("InvoiceNo"));
                    retobj.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    //retobj.SalesType = dr.GetString(dr.GetOrdinal("SalesType"));
                    retobj.Total = dr.GetDecimal(dr.GetOrdinal("Total"));
                    retobj.TotalSum = dr.GetDecimal(dr.GetOrdinal("TotalSum"));
                    retobj.Vat8 = dr.GetDecimal(dr.GetOrdinal("Vat8"));
                    retobj.Vat18 = dr.GetDecimal(dr.GetOrdinal("Vat18"));
                    retobj.VatSum = dr.GetDecimal(dr.GetOrdinal("VatSum"));
                    retobj.TotalWithVat = dr.GetDecimal(dr.GetOrdinal("TotalWithVat"));
                    retobj.DiscountValue = dr.GetDecimal(dr.GetOrdinal("DiscountValue"));
                    retobj.TotalBeforeDiscount = dr.GetDecimal(dr.GetOrdinal("TotalBeforeDiscount"));
                    retobj.Comment = dr.GetString(dr.GetOrdinal("Comment"));
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
            }

            return retobj;
        }

        /// <summary>
        /// Get daily sales objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static DataTable GetCupon(int Id)
        {
            string strquery = "GetCoupon";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            DataTable retobj = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                da.Fill(retobj);
                da.Dispose();
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

            return retobj;
        }
        
        /// <summary>
        /// Get daily sales objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static DataTable GetInvoiceForFiscalPrinter(int Id)
        {
            string strquery = "GetInvoiceForFiscalPrinter";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            DataTable retobj = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                da.Fill(retobj);
                da.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
            }
           
            return retobj;
        }

        public static bool ExistReference(string reference)
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand();

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.Connection = cnn;           
            cmd.CommandText = "SELECT COUNT(*) FROM Sales WHERE Reference = @Reference"; 
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Reference", reference);
            int numRecords = (int)cmd.ExecuteScalar();

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            return (numRecords > 0);
        }

        #endregion

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
           
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "InsertSale";
            SqlCommand cmd = new SqlCommand(strquery, cnn);
          
            cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
            cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = SaleId;
            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = Reference;
            cmd.Parameters.Add("@CashBoxId", SqlDbType.Int).Value = CashBoxId;
            cmd.Parameters.Add("@StationId", SqlDbType.Int).Value = StationId;
            cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = PartnerId;
            cmd.Parameters.Add("@PaymentMethod", SqlDbType.Int).Value = PaymentMethodId;
            cmd.Parameters.Add("@SalesTypeId", SqlDbType.Int).Value = SalesTypeId;
            cmd.Parameters.Add("@TotalSum", SqlDbType.Decimal).Value = TotalSum;
            cmd.Parameters.Add("@WithVat", SqlDbType.Bit).Value = WithVat;

            cmd.Parameters.Add("@Export", SqlDbType.Bit).Value = Export;

            cmd.Parameters.Add("@VatSum", SqlDbType.Decimal).Value = VatSum;
            cmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
            cmd.Parameters.Add("@CurrencyRate", SqlDbType.Decimal).Value = CurrencyRate;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = Comment;
            cmd.Parameters.Add("@Printed", SqlDbType.Bit).Value = Printed;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status; 
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;

   
            SqlParameter invoiceno = new SqlParameter("@InvoiceNo", SqlDbType.VarChar,50);
            invoiceno.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(invoiceno);

            invoiceno.Value = InvoiceNo;

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
                this.InvoiceNo = invoiceno.Value.ToString();
            }
            //catch (SqlException sq)
            //{
            //  TrackError.SqlError(sq);

            //}
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
            string strquery = "UpdateSale";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
            //cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = SaleId;
            //cmd.Parameters.Add("@SaleType", SqlDbType.Int).Value = SaleType;
            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = Reference;
            cmd.Parameters.Add("@CashBoxId", SqlDbType.Int).Value = CashBoxId;
            cmd.Parameters.Add("@StationId", SqlDbType.Int).Value = StationId;
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = InvoiceNo;
            cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = PartnerId;
            cmd.Parameters.Add("@PaymentMethod", SqlDbType.Int).Value = PaymentMethodId;
            cmd.Parameters.Add("@SalesTypeId", SqlDbType.Int).Value = SalesTypeId;
            //cmd.Parameters.Add("@TotalCash", SqlDbType.Decimal).Value = TotalCash;
            //cmd.Parameters.Add("@TotalCoupon", SqlDbType.Decimal).Value = TotalCoupon;
            //cmd.Parameters.Add("@TotalCheck", SqlDbType.Decimal).Value = TotalCheck;
            //cmd.Parameters.Add("@TotalAmountPaidCard", SqlDbType.Decimal).Value = TotalAmountPaidCard;
            cmd.Parameters.Add("@TotalSum", SqlDbType.Decimal).Value = TotalSum;
            cmd.Parameters.Add("@WithVat", SqlDbType.Bit).Value = WithVat;
            cmd.Parameters.Add("@Export", SqlDbType.Bit).Value = Export;
            cmd.Parameters.Add("@VatSum", SqlDbType.Decimal).Value = VatSum;
            cmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
            cmd.Parameters.Add("@CurrencyRate", SqlDbType.Decimal).Value = CurrencyRate;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = Comment;
            cmd.Parameters.Add("@Printed", SqlDbType.Bit).Value = Printed;
            //cmd.Parameters.Add("@PrintFiscal", SqlDbType.Bit).Value = PrintFiscal;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
            cmd.Parameters.Add("@ChangedBy", SqlDbType.VarChar).Value = ChangedBy;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            

            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);
            int retval = 0;
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                cmd.ExecuteNonQuery();
                retval = (int)rowsaffected.Value;
                
            }
            //catch (SqlException sq)
            //{
            //    TrackError.SqlError(sq);

            //}
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open) cnn.Close();
            }
            return retval;
        }

        public static void ChngPrintStatus(int saleId, bool printed)
        {
            string strquery = "Update Sales SET Printed = @Printed Where Id = @Id";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.Add("@Printed", SqlDbType.Bit).Value = printed;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = saleId;

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            cmd.ExecuteNonQuery();
            if (cnn.State == System.Data.ConnectionState.Open) 
                cnn.Close();
        }

        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        public int Delete(string username = "")
        {
            string strquery = "DeleteSale";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
             
           List<MyNET.DAL.SaleDetails> det = SaleDetails.GetDetailsBySaleId(Id);
            
            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);
            int retval = 0;
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

        #endregion

        #region Converters

        public static DataTable ConvertToTable()
        {
            //DataTable rettable = new DataTable();
            //rettable.Columns.AddRange(new DataColumn[] {"Id","Date","SaleId",
            //    "CustomrId",""};
            
            //DataRow row = new DataRow();
            return null;
            
        }

        #endregion

    }
}
	

