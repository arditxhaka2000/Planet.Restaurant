using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyNET.DAL
{
public class PartnerType
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

        public PartnerType()
        {

        }

        public PartnerType(int Id, string name)
        {
            this.mId = Id;
            this.mName = name;
        }

        public PartnerType(SqlDataReader dr)
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

        public static List<PartnerType> Get()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Name FROM PartnerType";
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            
            SqlDataReader dr = null;
            PartnerType retobj;
            List<PartnerType> retobjs = new List<PartnerType>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new PartnerType(dr);
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

        public static PartnerType Get(int Id)
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT Id,Name FROM PartnerType where Id = @Id";
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr = null;
            PartnerType retobj = new PartnerType();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    retobj = new PartnerType(dr);                    
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
