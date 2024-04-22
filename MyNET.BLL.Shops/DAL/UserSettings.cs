using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{
    public class UserSettings
    {
        #region Class members

        protected int mId;
        protected int mUserId;
        protected bool mAllowToChangeSalePrice = false;
        protected string mStyle = "Blue";
        protected int mDigitsOnDetails = 2;
        protected int mDigits = 2;
        protected bool mSearchStatus;
        protected bool mAllowToChangeWarehouse;
        protected bool mAllowToDelete;
        protected string mBackupPath;

        ///Conection to database
        protected SqlConnection cnn;      

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserSettings()
        {
            
        }

        public UserSettings(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("UserId"))) this.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
                if (!dr.IsDBNull(dr.GetOrdinal("AllowToChangeSalePrice"))) this.AllowToChangeSalePrice = dr.GetBoolean(dr.GetOrdinal("AllowToChangeSalePrice"));
                if (!dr.IsDBNull(dr.GetOrdinal("DigitsOnDetails"))) this.DigitsOnDetails = dr.GetInt32(dr.GetOrdinal("DigitsOnDetails"));
                if (!dr.IsDBNull(dr.GetOrdinal("Digits"))) this.DigitsOnDetails = dr.GetInt32(dr.GetOrdinal("Digits"));
                if (!dr.IsDBNull(dr.GetOrdinal("Style"))) this.Style = dr.GetString(dr.GetOrdinal("Style"));
                if (!dr.IsDBNull(dr.GetOrdinal("SearchStatus"))) this.SearchStatus = dr.GetBoolean(dr.GetOrdinal("SearchStatus"));
                if (!dr.IsDBNull(dr.GetOrdinal("AllowToChangeWarehouse"))) this.AllowToChangeWarehouse = dr.GetBoolean(dr.GetOrdinal("AllowToChangeWarehouse"));
                if (!dr.IsDBNull(dr.GetOrdinal("AllowToDelete"))) this.AllowToDelete = dr.GetBoolean(dr.GetOrdinal("AllowToDelete"));
                if (!dr.IsDBNull(dr.GetOrdinal("BackupPath"))) this.BackupPath = dr.GetString(dr.GetOrdinal("BackupPath"));

            }
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public UserSettings(MyNET.DAL.UserSettings obj)
        {
            mId = obj.Id;
            mUserId = obj.UserId;          
            mAllowToChangeSalePrice = obj.AllowToChangeSalePrice;        
            mDigits = obj.Digits;
            mDigitsOnDetails = obj.DigitsOnDetails;
            mAllowToChangeWarehouse = obj.AllowToChangeWarehouse;
            mStyle = obj.Style;
            mSearchStatus = obj.SearchStatus;
            mAllowToDelete = obj.AllowToDelete;
            mBackupPath = obj.BackupPath;
        }

       

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }
        public int UserId
        {
            get { return mUserId; }
            set { mUserId = value; }
        }
        public bool AllowToChangeWarehouse
        {
            get { return mAllowToChangeWarehouse; }
            set { mAllowToChangeWarehouse = value; }
        }
        public bool SearchStatus
        {
            get { return mSearchStatus; }
            set { mSearchStatus = value; }
        }
        public bool AllowToChangeSalePrice
        {
            get { return mAllowToChangeSalePrice; }
            set { mAllowToChangeSalePrice = value; }
        }
        public bool AllowToDelete
        {
            get { return mAllowToDelete; }
            set { mAllowToDelete = value; }
        }
        public int DigitsOnDetails
        {
            get { return mDigitsOnDetails; }
            set { mDigitsOnDetails = value; }
        }
        public int Digits
        {
            get { return mDigits; }
            set { mDigits = value; }
        }
        public string Style
        {
            get { return mStyle; }
            set { mStyle = value; }
        }
        public string BackupPath
        {
            get { return mBackupPath; }
            set { mBackupPath = value; }
        }
        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static UserSettings Get(int userId)
        {
            string strquery = "select * from UserSettings where UserId = @UserId";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
      
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            UserSettings usrS = new UserSettings();

            if (dr.Read())
            {
                usrS = new UserSettings(dr);
            }
              

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();
            dr.Dispose();
            return usrS;
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
            string strquery = "Insert into UserSettings (UserId,AllowToChangeSalePrice,DigitsOnDetails,Digits,Style,SearchStatus,AllowToChangeWarehouse,AllowToDelete,BackupPath)" +
               " Values (@UserId,@AllowToChangeSalePrice,@DigitsOnDetails,@Digits,@Style,@SearchStatus,@AllowToChangeWarehouse,@AllowToDelete,@BackupPath); SELECT @Id = @@IdENTITY";

            cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = mUserId;
            cmd.Parameters.Add("@AllowToChangeSalePrice", SqlDbType.Bit).Value = mAllowToChangeSalePrice;
            cmd.Parameters.Add("@DigitsOnDetails", SqlDbType.Int).Value = mDigitsOnDetails;
            cmd.Parameters.Add("@Digits", SqlDbType.Int).Value = mDigits;
            cmd.Parameters.Add("@Style", SqlDbType.VarChar).Value = mStyle;
            cmd.Parameters.Add("@SearchStatus", SqlDbType.Bit).Value = mSearchStatus;
            cmd.Parameters.Add("@AllowToChangeWarehouse", SqlDbType.Bit).Value = mAllowToChangeWarehouse;
            cmd.Parameters.Add("@AllowToDelete", SqlDbType.Bit).Value = mAllowToDelete;
            cmd.Parameters.Add("@BackupPath", SqlDbType.VarChar).Value = mBackupPath;

            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);


            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
            int retval = (int)Id.Value;
            this.Id = (int)Id.Value;

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            return retval;

        }




        public int Update()
        {
            string strquery = "Update UserSettings set " +
            "UserId = @UserId," +           
            "AllowToChangeSalePrice = @AllowToChangeSalePrice," +
            "DigitsOnDetails = @DigitsOnDetails," +
            "Digits = @Digits," + 
            "Style = @Style," +
            "SearchStatus = @SearchStatus," +
            "BackupPath = @BackupPath," +
            "AllowToDelete = @AllowToDelete," +
            "AllowToChangeWarehouse = @AllowToChangeWarehouse where UserId = @UserId;";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = mUserId;
            cmd.Parameters.Add("@AllowToChangeSalePrice", SqlDbType.Bit).Value = mAllowToChangeSalePrice;
            cmd.Parameters.Add("@DigitsOnDetails", SqlDbType.Int).Value = mDigitsOnDetails;
            cmd.Parameters.Add("@Digits", SqlDbType.Int).Value = mDigits;
            cmd.Parameters.Add("@Style", SqlDbType.VarChar).Value = mStyle;
            cmd.Parameters.Add("@SearchStatus", SqlDbType.Bit).Value = mSearchStatus;
            cmd.Parameters.Add("@AllowToChangeWarehouse", SqlDbType.Bit).Value = mAllowToChangeWarehouse;
            cmd.Parameters.Add("@AllowToDelete", SqlDbType.Bit).Value = mAllowToDelete;
            cmd.Parameters.Add("@BackupPath", SqlDbType.VarChar).Value = mBackupPath;

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
           int retval = cmd.ExecuteNonQuery();

           if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }
                
        #endregion
    }
}
