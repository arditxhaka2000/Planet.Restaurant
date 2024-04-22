using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{
    public class UserColumns
    {
        #region Class members

        protected int mId;
        protected string mUserName;
        protected string mFormName = String.Empty;
        protected string mHColumns = String.Empty;
       

        ///Conection to database
        protected SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        ///Staric member connection
        protected static SqlConnection statcnn = new SqlConnection(Constants.Connectionstr());

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserColumns()
        {
            string strquery = "select * from UserColumns ";

            SqlCommand cmd = new SqlCommand(strquery, cnn);

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                LoadFromReader(dr);

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();
            dr.Dispose();
        }

        public UserColumns(string userName, string formName)
        {
            string strquery = "select * from userColumns where username = @username and formname = @formname";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlDataReader dr = null;
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@FormName", formName);

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
        /// Contructor by entity object
        /// </summary>
        public UserColumns(MyNET.DAL.UserColumns obj)
        {
            mId = obj.mId;
            mUserName = obj.UserName;
            mFormName = obj.FormName;
            mHColumns = obj.HColumns;  
        }

        /// <summary>
        /// Load object from reader 
        /// </summary>
        /// <param CompanyName="dr">DataReader object</param>		
        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(1)) this.UserName = dr.GetString(1);
                if (!dr.IsDBNull(2)) this.FormName = dr.GetString(2);
                if (!dr.IsDBNull(3)) this.HColumns = dr.GetString(3);
            }
        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }
        public string UserName
        {
            get { return mUserName; }
            set { mUserName = value; }
        }
        public string FormName
        {
            get { return mFormName; }
            set { mFormName = value; }
        }
        public string HColumns
        {
            get { return mHColumns; }
            set { mHColumns = value; }
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static UserColumns Get()
        {
            return new UserColumns();
        }

        
        #endregion

        #region Update

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        /// 
        public int Insert()
        {
            string strquery = "Insert into UserColumns(UserName,FormName,HColumns)" +
                "Values(@UserName,@FormName,@HColumns)";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            //id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = mUserName;
            cmd.Parameters.Add("@FormName", SqlDbType.VarChar, 50).Value = mFormName;
            cmd.Parameters.Add("@HColumns", SqlDbType.VarChar, 500).Value = mHColumns;


            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            int retval = cmd.ExecuteNonQuery();

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }


        public int Update()
        {
            string strquery = "Update UserColumns set " +
            "UserName = @UserName," +
            "FormName = @FormName," +
            "HColumns = @HColumns " +
            "WHERE FormName = @FormName AND UserName = @UserName";
            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = mUserName;
            cmd.Parameters.Add("@FormName", SqlDbType.VarChar, 50).Value = mFormName;
            cmd.Parameters.Add("@HColumns", SqlDbType.VarChar, 500).Value = mHColumns;
            

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            int retval = cmd.ExecuteNonQuery();

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }

        #endregion
    }
}
