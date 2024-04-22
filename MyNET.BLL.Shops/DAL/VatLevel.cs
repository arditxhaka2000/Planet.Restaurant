using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyNET.DAL
{
    public class VatLevel
    {
         #region class members

        private int mId = 0;
        private int mValue = 0;
        private bool mActive = false;

        #endregion

        #region properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public int Value  
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public bool Active
        {
            get { return mActive; }
            set { mActive = value; }
        }

        #endregion


        #region constructors

        public VatLevel()
        {

        }

        public VatLevel(int Id, int Value)
        {
            this.mId = Id;
            this.mValue = Value;
            this.mActive = Active;
        }

        public VatLevel(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region methods

        /// <summary>
        /// Load object from reader 
        /// </summary>
        /// <param Value="dr">DataReader object</param>		
        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(1)) this.Value = dr.GetInt32(1);
                if (!dr.IsDBNull(2)) this.Active = dr.GetBoolean(2);
            }
        }

        public static List<VatLevel> Get()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Value,Active FROM VatLevel";
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            
            SqlDataReader dr = null;
            VatLevel retobj;
            List<VatLevel> retobjs = new List<VatLevel>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new VatLevel(dr);
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
