
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MyNET.Models;

namespace MyNET.DAL
{

    /// <summary>
    /// This object represents the properties and methods of a SaleDetails.
    /// </summary>
    public class SaleDetails : MyNET.Entities.SaleDetails//,ISyncObj
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SaleDetails()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public SaleDetails(MyNET.Entities.SaleDetails obj)
        {
            mId = obj.Id;
            mSaleId = obj.SaleId;
            mNo = obj.No;
            mItemId = obj.ItemId;
            mProjectId = obj.ProjectId;
            mQuantity = obj.Quantity;
            mAvgPrice = obj.AvgPrice;
            mPrice = obj.Price;
            mVat = obj.Vat;
            mVatSum = obj.VatSum;
            mDiscount = obj.Discount;

        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public SaleDetails(long Id)
        {
            string strquery = "GetSalesDetail";
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
                this.Id = dr.GetInt32(dr.GetOrdinal("Id"));

                if (!dr.IsDBNull(dr.GetOrdinal("SaleId"))) this.SaleId = dr.GetInt32(dr.GetOrdinal("SaleId"));
                if (!dr.IsDBNull(dr.GetOrdinal("No"))) this.No = dr.GetInt32(dr.GetOrdinal("No"));
                if (!dr.IsDBNull(dr.GetOrdinal("ItemId"))) this.ItemId = dr.GetInt32(dr.GetOrdinal("ItemId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ProjectId"))) this.ProjectId = dr.GetInt32(dr.GetOrdinal("ProjectId"));
                if (!dr.IsDBNull(dr.GetOrdinal("Quantity"))) this.Quantity = dr.GetDecimal(dr.GetOrdinal("Quantity"));
                if (!dr.IsDBNull(dr.GetOrdinal("AvgPrice"))) this.AvgPrice = dr.GetDecimal(dr.GetOrdinal("AvgPrice"));
                if (!dr.IsDBNull(dr.GetOrdinal("Price"))) this.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                if (!dr.IsDBNull(dr.GetOrdinal("Discount"))) this.Discount = dr.GetDecimal(dr.GetOrdinal("Discount"));
                if (!dr.IsDBNull(dr.GetOrdinal("Vat"))) this.Vat = dr.GetInt32(dr.GetOrdinal("Vat"));
                if (!dr.IsDBNull(dr.GetOrdinal("VatSum"))) this.VatSum = dr.GetDecimal(dr.GetOrdinal("VatSum"));
            }
        }

        public SaleDetails(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static SaleDetails Get(long Id)
        {
            return new SaleDetails(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static ArrayList Get()
        {
            string strquery = "GetSalesDetails";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            SaleDetails retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new SaleDetails(dr);
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
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static List<MyNET.Models.SaleDetails> GetBySaleId(int saleId)
        {
            string strquery = "SELECT sd.Id, ROW_NUMBER() OVER (ORDER BY sd.Id ) No,I.ItemName, ISNULL(I.Barcode,'') Barcode,ISNULL(I.ProductNo,'') ProductNo,U.Name Unit," +
                        "sd.Quantity,sd.Price,sd.Discount, sd.Price * (1- sd.Discount/100) DiscountPrice,sd.VAT,sd.VATSum, sd.Quantity * sd.Price * (1- sd.Discount/100) as Total," +
                        "sd.Quantity * sd.Price * (1- sd.Discount/100) + sd.VATSum as TotalWithVat," +
                        "sd.Price * (1+ sd.VAT/100.00) as VatPrice " +
                        "FROM Sales S " +
                        "LEFT JOIN SalesDetails sd on s.Id = sd.SaleId " +
                        "LEFT JOIN Partners p on p.Id = s.PartnerId " +
                        "LEFT JOIN Items I on I.Id = sd.ItemId "+
                        "LEFT JOIN Units u on u.Id = i.Unit " +
                        //"LEFT JOIN Producers pr on pr.Id = i.ProducerID "+
                        "WHERE S.Id = @Id";

            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.AddWithValue("@Id", saleId);

            SqlDataReader dr = null;
            MyNET.Models.SaleDetails retobj;
            List<MyNET.Models.SaleDetails> retobjs = new List<MyNET.Models.SaleDetails>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new MyNET.Models.SaleDetails();

                    retobj.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    string strNumri = dr.GetInt64(dr.GetOrdinal("No")).ToString();
                    retobj.No = int.Parse(strNumri);
                    retobj.ProductNo = (!dr.IsDBNull(dr.GetOrdinal("ProductNo"))) ? dr.GetString(dr.GetOrdinal("ProductNo")) : "";
                    retobj.ItemName = (!dr.IsDBNull(dr.GetOrdinal("ItemName"))) ? dr.GetString(dr.GetOrdinal("ItemName")) : "";

                    retobj.Barcode = (!dr.IsDBNull(dr.GetOrdinal("Barcode"))) ? dr.GetString(dr.GetOrdinal("Barcode")) : "";
                   
                    retobj.Unit = (!dr.IsDBNull(dr.GetOrdinal("Unit"))) ? dr.GetString(dr.GetOrdinal("Unit")) : "";
                    retobj.Quantity = dr.GetDecimal(dr.GetOrdinal("Quantity"));
                    retobj.Discount = dr.GetDecimal(dr.GetOrdinal("Discount"));
                    retobj.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                    retobj.Total = dr.GetDecimal(dr.GetOrdinal("Total"));
                    retobj.Vat = dr.GetInt32(dr.GetOrdinal("VAT"));
                    retobj.VatSum = dr.GetDecimal(dr.GetOrdinal("VATSum"));
                    retobj.VatPrice = dr.GetDecimal(dr.GetOrdinal("VATPrice"));
                    retobj.TotalWithVat = dr.GetDecimal(dr.GetOrdinal("TotalWithVat"));
                    
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
        /// Kthen te gjitha detalet per nje fature
        /// </summary>
        /// <returns>List of objects</returns>
        /// 
       
        public static List<MyNET.DAL.SaleDetails> GetDetailsBySaleId(int saleId)
        {
            string strquery = "SELECT * FROM SalesDetails WHERE SaleId = @SaleId";

            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.AddWithValue("@SaleId", saleId);

            SqlDataReader dr = null;
           
            List<MyNET.DAL.SaleDetails> retobjs = new List<MyNET.DAL.SaleDetails>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MyNET.DAL.SaleDetails retobj = new MyNET.DAL.SaleDetails(dr);
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

        public static DataTable GetSaleDetailsBySaleId(int saleId)
        {
            string strquery = "GetSalesDetailsBySaleId"; 
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = saleId;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //public static DataTable GetOffersDetailsBySaleId(int saleId)
        //{
        //    string strquery = "GetOffersDetailsBySaleId";
        //    SqlConnection cnn = new SqlConnection(Constants.Connectionstr());

        //    SqlCommand cmd = new SqlCommand(strquery, cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = saleId;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);

        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}

        public static DataTable GetSaleDetailsBySaleIdManagement(int saleId)
        {
            string strquery = "GetSalesDetailsBySaleIdManagement";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = saleId;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /// <summary>
        /// return saledetails
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static DataTable GetInvoiceDetails(int saleId)
        {
            string strquery = "GetInvoiceDetails";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = saleId;
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
            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        #endregion

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            string strquery = "InsertSalesDetail";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = SaleId;
            cmd.Parameters.Add("@No", SqlDbType.Int).Value = No;
            cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = ItemId;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = Quantity;
            cmd.Parameters.Add("@AvgPrice", SqlDbType.Decimal).Value = AvgPrice;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Discount;
            cmd.Parameters.Add("@Vat", SqlDbType.Int).Value = Vat;
            cmd.Parameters.Add("@VatSum", SqlDbType.Decimal).Value = VatSum;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;

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
            string strquery = "UpdateSalesDetail";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleId", SqlDbType.Int).Value = SaleId;
            cmd.Parameters.Add("@No", SqlDbType.Int).Value = No;
            cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = ItemId;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = Quantity;
            cmd.Parameters.Add("@AvgPrice", SqlDbType.Decimal).Value = AvgPrice;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Discount;
            cmd.Parameters.Add("@Vat", SqlDbType.Int).Value = Vat;
            cmd.Parameters.Add("@VatSum", SqlDbType.Decimal).Value = VatSum;
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;
            }
            return retval;
        }

        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string strquery = "DeleteSalesDetail" +
                "" +
                "";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

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

    }
}