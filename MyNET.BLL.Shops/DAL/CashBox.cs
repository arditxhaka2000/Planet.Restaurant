using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{
    public class CashBox : MyNET.Entities.CashBox
    {
        #region Class members

        ///Conection to database
        protected SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        ///Staric member connection
        protected static SqlConnection statcnn = new SqlConnection(Constants.Connectionstr());


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CashBox()
        {

        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public CashBox(Entities.CashBox obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mWarehouseId = obj.WarehouseId;
            mAccountId = obj.AccountId;
            mAccount = obj.Account;
            mWarehouse = obj.Warehouse;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;
        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public CashBox(int Id)
        {
            string strquery = "Select * from CashBoxes where Id=@Id";

            SqlCommand cmd = new SqlCommand(strquery, cnn);   
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                LoadFromReader(dr);

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            dr.Dispose();
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
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) this.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("WarehouseId"))) this.WarehouseId = dr.GetInt32(dr.GetOrdinal("WarehouseId"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountId"))) this.AccountId = dr.GetInt32(dr.GetOrdinal("AccountId"));
            }
        }

        public CashBox(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }
        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static CashBox Get(int Id)
        {
            return new CashBox(Id);
        }

        public static DataTable GetCashBox()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "SELECT c.Id,c.Name,c.WarehouseId,c.AccountId,w.Name Warehouse,p.Name Account FROM CashBoxes c LEFT JOIN Station w ON c.WarehouseId = w.Id LEFT JOIN PlaniKontabel p ON p.ID = c.AccountId";

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

        public static ArrayList Get()
        {
            string strquery = "SELECT c.Id,c.Name,c.WarehouseId,c.AccountId,w.Name Warehouse,p.Name Account FROM CashBoxes c LEFT JOIN Station w ON c.WarehouseId = w.Id LEFT JOIN PlaniKontabel p ON p.ID = c.AccountId";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            SqlDataReader dr = null;
            CashBox retobj;
            ArrayList retobjs = new ArrayList();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new CashBox(dr);
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
            string strquery = "Insert into CashBoxes (Name,WarehouseId,AccountId,AmountPaid,CreatedBy) Values (@Name,@WarehouseId,@AccountId,GETDATE(),@CreatedBy); SELECT @Id = @@IdENTITY";
            cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = WarehouseId;
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = AccountId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = CreatedBy;


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

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            string strquery = "Update CashBoxes set Name = @Name, WarehouseID = @WarehouseId, AccountId = @AccountId,ChangedAt = GETDATE(),ChangedBy = @ChangedBy where Id = @Id; Set @rowsaffected = @@Rowcount";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = WarehouseId;
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = AccountId;
            cmd.Parameters.Add("@ChangedBy", SqlDbType.NVarChar).Value = ChangedBy;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();

            int retval = (int)rowsaffected.Value;

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }

        
        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string strquery = "Delete CashBoxes where Id = @Id; Set @rowsaffected = @@Rowcount";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();

            int retval = (int)rowsaffected.Value;

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }

        #endregion

    }
}
