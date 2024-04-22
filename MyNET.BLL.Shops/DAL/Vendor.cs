
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{

    /// <summary>
    /// This object represents the properties and methods of a Vendor.
    /// </summary>
    public class Vendor : MyNET.Entities.Vendor
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vendor()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Vendor(MyNET.Entities.Vendor obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mSurname = obj.Surname;
            mCompanyName = obj.CompanyName;
            mSaveAs = obj.SaveAs;
            mPhone = obj.Phone;
            mMobilePhone = obj.MobilePhone;
            mComment = obj.Comment;
            mBusinessNo = obj.BusinessNo;
            mFiscalNo = obj.FiscalNo;
            mVatNo = obj.VatNo;
            mAddress = obj.Address;
            mCity = obj.City;
            mCountry = obj.Country;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;

        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public Vendor(long Id)
        {
            string strquery = "GetVendor";
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
                if (!dr.IsDBNull(1)) this.Name = dr.GetString(1);
                if (!dr.IsDBNull(2)) this.Surname = dr.GetString(2);
                if (!dr.IsDBNull(3)) this.CompanyName = dr.GetString(3);
                if (!dr.IsDBNull(4)) this.SaveAs = dr.GetString(4);
                if (!dr.IsDBNull(5)) this.Phone = dr.GetString(5);
                if (!dr.IsDBNull(6)) this.MobilePhone = dr.GetString(6);
                if (!dr.IsDBNull(7)) this.Comment = dr.GetString(7);
                if (!dr.IsDBNull(8)) this.BusinessNo = dr.GetString(8);
                if (!dr.IsDBNull(9)) this.FiscalNo = dr.GetString(9);
                if (!dr.IsDBNull(10)) this.VatNo = dr.GetString(10);
                if (!dr.IsDBNull(11)) this.Address = dr.GetString(11);
                if (!dr.IsDBNull(12)) this.City = dr.GetInt32(12);
                if (!dr.IsDBNull(13)) this.Country = dr.GetInt32(13);
                if (!dr.IsDBNull(14)) this.AmountPaid = dr.GetDateTime(14);
                if (!dr.IsDBNull(15)) this.CreatedBy = dr.GetString(15);
                if (!dr.IsDBNull(16)) this.ChangedAt = dr.GetDateTime(16);
                if (!dr.IsDBNull(17)) this.ChangedBy = dr.GetString(17);
                if (!dr.IsDBNull(18)) this.Status = dr.GetInt16(18);
            }
        }

        public Vendor(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static Vendor Get(long Id)
        {
            return new Vendor(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static ArrayList Get()
        {
            string strquery = "GetVendors";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            Vendor retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Vendor(dr);
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
        public static ArrayList Search(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchVendors";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;
            SqlDataReader dr = null;
            Vendor retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Vendor(dr);
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
        public int Insert()
        {
            string strquery = "InsertVendor";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

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
            string strquery = "UpdateVendor";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
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
            string strquery = "DeleteVendor";
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


