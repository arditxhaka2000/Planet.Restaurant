using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyNET.DAL
{
    public class SalesType
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

        public SalesType()
        {

        }

        public SalesType(int Id, string Name)
        {
            this.mId = Id;
            this.mName = Name;
        }

        public SalesType(SqlDataReader dr)
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

        public static List<SalesType> Get()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Name FROM SalesType";
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            
            SqlDataReader dr = null;
            SalesType retobj;
            List<SalesType> retobjs = new List<SalesType>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new SalesType(dr);
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
    }
}
