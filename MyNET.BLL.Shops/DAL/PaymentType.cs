using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyNET.DAL
{
    public class PaymentType
    {
        #region class members

        private int mId = 0;
        private string mName = "";

        #endregion

        #region properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public string Name  
        {
            get { return mName; }
            set { mName = value; }
        }
          
        #endregion
        
        #region constructors

        public PaymentType()
        {

        }

        public PaymentType(int Id, string name)
        {
            this.mId = Id;
            this.mName = name;
        }

        public PaymentType(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region methods

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
            }
        }
        public static DataTable GetPaymentType()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Name FROM PaymentType";

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable retobj = new DataTable();

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            da.Fill(retobj);

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }


        public static List<PaymentType> Get()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Name FROM PaymentType";
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            
            SqlDataReader dr = null;
            PaymentType retobj;
            List<PaymentType> retobjs = new List<PaymentType>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new PaymentType(dr);
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

        public static PaymentType Get(int Id)
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Name FROM PaymentType where Id = @Id";
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr = null;
            PaymentType retobj = new PaymentType();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    retobj = new PaymentType(dr);                    
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
           
            return retobj;
        }

        #endregion
    }
}
