using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyNET.DAL
{

    /// <summary>
    /// This object represents the properties and methods of a Customer.
    /// </summary>
    public class Partner : MyNET.Entities.Partner
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Partner()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Partner(MyNET.Entities.Partner obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mSurname = obj.Surname;
            mCompanyName = obj.CompanyName;
            mSaveAs = obj.SaveAs;
            mPartnerType = obj.PartnerType;
            mPartnerOrigin = obj.PartnerOrigin;
            mPhone = obj.Phone;
            mMobilePhone = obj.MobilePhone;
            mComment = obj.Comment;
            mBusinessNo = obj.BusinessNo;
            mFiscalNo = obj.FiscalNo;
            mVatNo = obj.VatNo;
            mAddress = obj.Address;
            mCity = obj.City;
            mCountry = obj.Country;
            mCustomer = obj.Customer;
            mSupplier = obj.Supplier;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;
            mDiscount = obj.Discount;
            mPaymentTypeId = obj.PaymentTypeId;
            mImportOrLocal = obj.ImportOrLocal;
        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public Partner(long Id)
        {
            string strquery = "GetPartner";
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

                if (!dr.IsDBNull(dr.GetOrdinal("PartnerType"))) this.PartnerType = dr.GetInt32(dr.GetOrdinal("PartnerType"));
                if (!dr.IsDBNull(dr.GetOrdinal("PartnerOrigin"))) this.PartnerOrigin = dr.GetInt32(dr.GetOrdinal("PartnerOrigin"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) this.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Surname"))) this.Surname = dr.GetString(dr.GetOrdinal("Surname"));
                if (!dr.IsDBNull(dr.GetOrdinal("CompanyName"))) this.CompanyName = dr.GetString(dr.GetOrdinal("CompanyName"));
                if (!dr.IsDBNull(dr.GetOrdinal("SaveAs"))) this.SaveAs = dr.GetString(dr.GetOrdinal("SaveAs"));
                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) this.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                if (!dr.IsDBNull(dr.GetOrdinal("MobilePhone"))) this.MobilePhone = dr.GetString(dr.GetOrdinal("MobilePhone"));
                if (!dr.IsDBNull(dr.GetOrdinal("Comment"))) this.Comment = dr.GetString(dr.GetOrdinal("Comment"));
                if (!dr.IsDBNull(dr.GetOrdinal("BusinessNo"))) this.BusinessNo = dr.GetString(dr.GetOrdinal("BusinessNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("FiscalNo"))) this.FiscalNo = dr.GetString(dr.GetOrdinal("FiscalNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("VatNo"))) this.VatNo = dr.GetString(dr.GetOrdinal("VatNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("Address"))) this.Address = dr.GetString(dr.GetOrdinal("Address"));
                if (!dr.IsDBNull(dr.GetOrdinal("City"))) this.City = dr.GetInt32(dr.GetOrdinal("City"));
                if (!dr.IsDBNull(dr.GetOrdinal("Country"))) this.Country = dr.GetInt32(dr.GetOrdinal("Country"));
                if (!dr.IsDBNull(dr.GetOrdinal("Customer"))) this.Customer = dr.GetBoolean(dr.GetOrdinal("Customer"));
                if (!dr.IsDBNull(dr.GetOrdinal("Supplier"))) this.Supplier = dr.GetBoolean(dr.GetOrdinal("Supplier"));
                //if (!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) this.AmountPaid = dr.GetDateTime(dr.GetOrdinal("AmountPaid"));
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedBy"))) this.CreatedBy = dr.GetString(dr.GetOrdinal("CreatedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedAt"))) this.ChangedAt = dr.GetDateTime(dr.GetOrdinal("ChangedAt"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedBy"))) this.ChangedBy = dr.GetString(dr.GetOrdinal("ChangedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("Status"))) this.Status = dr.GetInt32(dr.GetOrdinal("Status"));
                if (!dr.IsDBNull(dr.GetOrdinal("Discount"))) this.Discount = dr.GetDecimal(dr.GetOrdinal("Discount"));
                if (!dr.IsDBNull(dr.GetOrdinal("PaymentTypeId"))) this.PaymentTypeId = dr.GetInt32(dr.GetOrdinal("PaymentTypeId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ImportOrLocal"))) this.ImportOrLocal = dr.GetBoolean(dr.GetOrdinal("ImportOrLocal"));
            }
        }

        public Partner(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static Partner Get(long Id)
        {
            return new Partner(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        ///        
        protected static SqlConnection statcnn = new SqlConnection(Constants.Connectionstr());

        public static DataTable GetPartnerList()
        {
            string strquery = "GetPartners";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }


        public static ArrayList Get()
        {
            string strquery = "GetPartners";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            Partner retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Partner(dr);
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

        public static ArrayList GetSupplier()
        {
            string strquery = "GetPartnerSupplier";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            
            Partner retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Partner(dr);
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

        public static ArrayList GetCustomer()
        {
            string strquery = "GetPartnerCustomer";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
           
            Partner retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Partner(dr);
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
               
        public static List<Partner> GetList()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Name FROM Partners";
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlDataReader dr = null;
            Partner retobj;
            List<Partner> retobjs = new List<Partner>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Partner(dr);
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

        public static DataTable Search(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchPartners";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar,500).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar,100).Value = OrderByExpression;
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

        #endregion 

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            string strquery = "InsertPartner";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);
            cmd.Parameters.Add("@PartnerType", SqlDbType.Int).Value = PartnerType;
            cmd.Parameters.Add("@PartnerOrigin", SqlDbType.Int).Value = PartnerOrigin;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = Surname;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyName;
            cmd.Parameters.Add("@SaveAs", SqlDbType.VarChar).Value = SaveAs;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;
            cmd.Parameters.Add("@MobilePhone", SqlDbType.VarChar).Value = MobilePhone;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = Comment;
            cmd.Parameters.Add("@BusinessNo", SqlDbType.VarChar).Value = BusinessNo;
            cmd.Parameters.Add("@FiscalNo", SqlDbType.VarChar).Value = FiscalNo;
            cmd.Parameters.Add("@VatNo", SqlDbType.VarChar).Value = VatNo;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
            if (City != null)
                cmd.Parameters.Add("@City", SqlDbType.Int).Value = City;
            else
                cmd.Parameters.Add("@City", SqlDbType.Int).Value = DBNull.Value;
            if (Country != null)
                cmd.Parameters.Add("@Country", SqlDbType.Int).Value = Country;
            else
                cmd.Parameters.Add("@Country", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@Customer", SqlDbType.Bit).Value = Customer;
            cmd.Parameters.Add("@Supplier", SqlDbType.Bit).Value = Supplier;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Discount;
            cmd.Parameters.Add("@PaymentTypeId", SqlDbType.Int).Value = PaymentTypeId;
            cmd.Parameters.Add("@ImportOrLocal", SqlDbType.Bit).Value = ImportOrLocal;


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
            string strquery = "UpdatePartner";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartnerType", SqlDbType.Int).Value = PartnerType;
            cmd.Parameters.Add("@PartnerOrigin", SqlDbType.Int).Value = PartnerOrigin;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = Surname;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyName;
            cmd.Parameters.Add("@SaveAs", SqlDbType.VarChar).Value = SaveAs;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;
            cmd.Parameters.Add("@MobilePhone", SqlDbType.VarChar).Value = MobilePhone;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = Comment;
            cmd.Parameters.Add("@BusinessNo", SqlDbType.VarChar).Value = BusinessNo;
            cmd.Parameters.Add("@FiscalNo", SqlDbType.VarChar).Value = FiscalNo;
            cmd.Parameters.Add("@VatNo", SqlDbType.VarChar).Value = VatNo;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
            if (City != null)
                cmd.Parameters.Add("@City", SqlDbType.Int).Value = City;
            else
                cmd.Parameters.Add("@City", SqlDbType.Int).Value = DBNull.Value;
            
            if (Country != null)
                cmd.Parameters.Add("@Country", SqlDbType.Int).Value = Country;
            else
                cmd.Parameters.Add("@Country", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@Customer", SqlDbType.Bit).Value = Customer;
            cmd.Parameters.Add("@Supplier", SqlDbType.Bit).Value = Supplier;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
            cmd.Parameters.Add("@ChangedBy", SqlDbType.VarChar).Value = ChangedBy;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Discount;
            cmd.Parameters.Add("@PaymentTypeId", SqlDbType.Int).Value = PaymentTypeId;
            cmd.Parameters.Add("@ImportOrLocal", SqlDbType.Bit).Value = ImportOrLocal;

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
            string strquery = "DeletePartner";
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


