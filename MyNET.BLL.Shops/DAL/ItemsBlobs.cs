using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.DAL
{
    public class ItemsBlobs : MyNET.Entities.ItemsBlobs
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
        public ItemsBlobs()
        {

        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public ItemsBlobs(MyNET.Entities.ItemsBlobs obj)
        {
            mImageId = obj.ImageId;
            mItemId = obj.ItemId;
            mName = obj.Name;
            mBlobData = obj.BlobData;

        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public ItemsBlobs(int Id)
        {
            string strquery = "GetItemBlobs";

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

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
                this.ImageId = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("ItemsID"))) this.ItemId = dr.GetInt32(dr.GetOrdinal("ItemsID"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) this.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("BlobData"))) this.BlobData = (byte[])dr[dr.GetOrdinal("BlobData")];

            }
        }

        /// <summary>
        /// Load from reader. Static method
        /// </summary>
        /// <param name="dr">DataReader object</param>
        /// <returns>Return object</returns>
        private static MyNET.Entities.ItemsBlobs LoadObjectFromReader(SqlDataReader dr)
        {
            MyNET.Entities.ItemsBlobs retobj = new MyNET.Entities.ItemsBlobs();
            if (dr != null && !dr.IsClosed)
            {
                retobj.ImageId = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("ItemsID"))) retobj.ItemId = dr.GetInt32(dr.GetOrdinal("ItemsID"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) retobj.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("BlobData"))) retobj.BlobData = (byte[])dr[dr.GetOrdinal("BlobData")];

                return retobj;
            }
            else return retobj;
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static MyNET.Entities.ItemsBlobs Get(int Id)
        {
            return new ItemsBlobs(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        //public static ArrayList Get()
        //{
        //    string strquery = "GetItems";

        //    SqlCommand cmd = new SqlCommand(strquery, statcnn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    MyNET.Entities.Item retobj;

        //    ArrayList retobjs = new ArrayList();

        //    if (statcnn.State == System.Data.ConnectionState.Closed)
        //        statcnn.Open();

        //    SqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        retobj = new MyNET.Entities.Item();
        //        retobj = LoadObjectFromReader(dr);

        //        retobjs.Add(retobj);
        //    }

        //    if (statcnn.State == System.Data.ConnectionState.Open)
        //        statcnn.Close();

        //    dr.Dispose();

        //    if (retobjs.Count == 0)
        //        return null;
        //    else
        //        return retobjs;
        //}
        public static ArrayList Get()
        {
            string strquery = "GetItems";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            MyNET.Entities.ItemsBlobs retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new ItemsBlobs();
                retobj = LoadObjectFromReader(dr);

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
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static DataTable GetTable()
        {
            string strquery = "SELECT * from Items ";

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




        #endregion

        #region Insert, Update and Delete
        public int InsertImage()
        {
            //if (this.IsinRole(roleId))
            //    return 0;

            string strquery = "Insert into ItemsBlobs(ItemsId,Name,BlobData) values (@ItemsId,@Name,@BlobData); SELECT @ImageId = @@IdENTITY";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Id = new SqlParameter("@ImageId", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@ItemsId", SqlDbType.Int).Value = ItemId;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@BlobData", SqlDbType.Image).Value = BlobData;

            int retval = 0;
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                retval = cmd.ExecuteNonQuery();
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
        public int Update()
        {
            string strquery = "UpdateItemBlob";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemsId", SqlDbType.Int).Value = ItemId;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@BlobData", SqlDbType.Image).Value = BlobData;

            cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = ImageId;

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

                if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retval;
        }

        public int UpdateImage()
        {
            string strquery = "Update ItemsBlobs set ItemsId = @ItemsId,Name = @Name,BlobData = @BlobData where ImageId = @ImageId; Set @rowsaffected = @@Rowcount";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@ItemsId", SqlDbType.Int).Value = ItemId;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@BlobData", SqlDbType.Image).Value = BlobData;

            cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = ImageId;


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
        /// E rikalkulon  sasin e artikujev ne depo 
        /// dhe cmimin mesatare
        /// </summary>
        public static int CalculateItemsInWarehouse(int year, string user)
        {
            string strquery = "RikalkuloArtikujtNeDepo";
            statcnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;
            cmd.Parameters.Add("@UserId", SqlDbType.VarChar, 100).Value = user;
            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();
            int retval = cmd.ExecuteNonQuery();
            if (statcnn.State == System.Data.ConnectionState.Open) statcnn.Close();
            return retval;
        }

        /// <summary>
        /// E rikalkulon  sasin depo per artikullin e dhene
        /// dhe cmimin mesatare
        /// </summary>
        public static int CalculateStock(int itemId, int year, string user)
        {
            string strquery = "CalculateStock";
            statcnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;
            cmd.Parameters.Add("@UserId", SqlDbType.VarChar, 100).Value = user;
            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();
            int retval = cmd.ExecuteNonQuery();
            if (statcnn.State == System.Data.ConnectionState.Open) statcnn.Close();
            return retval;
        }

        #endregion
    }
}
