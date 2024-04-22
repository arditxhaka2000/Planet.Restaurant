using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{
    public class Bank : MyNET.Entities.Bank
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
        public Bank()
        {

        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Bank(MyNET.Entities.Bank obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mAccount = obj.Account;
            mAccountId = obj.AccountId;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            Type = obj.Type;
            OrderNo = obj.OrderNo;
            mStatus = obj.Status;
        }


        public Bank (SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }
        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public Bank(int Id)
        {
            string strquery = "Select Id,Name,Account,AccountId,Type,OrderNo," + 
                " AmountPaid,CreatedBy,ChangedAt,ChangedBy,Status from Banks where Id = @Id";

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
                if (!dr.IsDBNull(dr.GetOrdinal("Account"))) this.Account = dr.GetString(dr.GetOrdinal("Account"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountId"))) this.AccountId = dr.GetInt32(dr.GetOrdinal("AccountId"));
                if (!dr.IsDBNull(dr.GetOrdinal("Type"))) this.Type = dr.GetString(dr.GetOrdinal("Type"));
                if (!dr.IsDBNull(dr.GetOrdinal("OrderNo"))) this.OrderNo = dr.GetInt32(dr.GetOrdinal("OrderNo"));

                if(!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) this.AmountPaid = dr.GetDateTime(dr.GetOrdinal("AmountPaid"));
                if(!dr.IsDBNull(dr.GetOrdinal("CreatedBy"))) this.CreatedBy = dr.GetString(dr.GetOrdinal("CreatedBy"));
                if(!dr.IsDBNull(dr.GetOrdinal("ChangedAt"))) this.ChangedAt = dr.GetDateTime(dr.GetOrdinal("ChangedAt"));
                if(!dr.IsDBNull(dr.GetOrdinal("ChangedBy"))) this.ChangedBy = dr.GetString(dr.GetOrdinal("ChangedBy"));
                if(!dr.IsDBNull(dr.GetOrdinal("Status"))) this.Status = dr.GetInt32(dr.GetOrdinal("Status"));
            }
        }        

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static MyNET.Entities.Bank Get(int Id)
        {
            return new Bank(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        /// 


        public static DataTable GetBank()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            string strquery = "Select b.Id,b.Name,b.Account,b.Type,b.AccountId,p.Name AccountName from Banks b LEFT JOIN PlaniKontabel p ON p.ID = b.AccountId";

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
            string strquery = "Select * from Banks";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);                      

            MyNET.Entities.Bank retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new Bank(dr);
                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        public static List<Bank> GetPoss()
        {
            string strquery = "Select Id,Name,0 AccountId,Account,Type,OrderNo,CreatedBy,ChangedAt, ChangedBy," +
                " Status from Banks where type ='p' order by OrderNo ";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);

            List<Bank> retobjs = new List<Bank>();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Bank retobj = new Bank(dr);
                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

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
            string strquery = "SearchBank";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);

            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;

            MyNET.Entities.Bank retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new Bank(dr);
                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

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
            string strquery = "Insert into Banks (Name,Account,AccountId,Type,AmountPaid,CreatedBy) Values (@Name,@Account,@AccountId,@Type,GETDATE(),@CreatedBy); SELECT @Id = @@IdENTITY";

            cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Account", SqlDbType.VarChar).Value = Account;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = AccountId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = CreatedBy;

            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);


            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
            int retval = (int)Id.Value;
            this.Id = (int) Id.Value;

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
            string strquery = "Update Banks set Name = @Name,Account = @Account,Type = @Type, AccountId = @AccountId,ChangedAt = GETDATE(),ChangedBy = @ChangedBy where Id=@Id; Set @rowsaffected = @@Rowcount";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Account", SqlDbType.VarChar).Value = Account;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
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
            string strquery = "Delete from Banks where Id=@Id; Set @rowsaffected = @@Rowcount";

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

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); 

            return retval;
        }

        #endregion
    }
}
