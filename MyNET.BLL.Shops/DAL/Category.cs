

#region Categorie BLL

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{

    /// <summary>
    /// This object represents the properties and methods of a Categorie.
    /// </summary>
    public class Categorie : MyNET.Entities.Categorie
    {
        #region Class members

        ///Conection to database
        protected SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        ///Staric member connection
        protected static SqlConnection statcnn = new SqlConnection(Constants.Connectionstr());


        #endregion

        #region Constructors


        public Categorie()
        {

        }


        public Categorie(MyNET.Entities.Categorie obj)
        {
            mId = obj.Id;
            mName = obj.Name;

        }

        public Categorie(int Id)
        {
            string strquery = "GetCategory";

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


        private Categorie(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) this.Name = dr.GetString(dr.GetOrdinal("Name"));
            }

        }

        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) this.Name = dr.GetString(dr.GetOrdinal("Name"));

            }
        }

        private static MyNET.Entities.Categorie LoadObjectFromReader(SqlDataReader dr)
        {
            MyNET.Entities.Categorie retobj = new MyNET.Entities.Categorie();
            if (dr != null && !dr.IsClosed)
            {
                retobj.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) retobj.Name = dr.GetString(dr.GetOrdinal("Name"));

                return retobj;
            }
            else return retobj;
        }

        #endregion

        #region public static Get Methods

        public static MyNET.Entities.Categorie Get(int Id)
        {
            return new Categorie(Id);
        }

        public static ArrayList Get()
        {
            string strquery = "GetCategories";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;

            MyNET.Entities.Categorie retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new MyNET.Entities.Categorie();
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

        public static List<Categorie> GetTables()
        {
            string strquery = "GetCategories";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;


            List<Categorie> retobjs = new List<Categorie>();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                Categorie retobj = new Categorie(dr);

                //var itemblob = ItemsBlobs.Get(retobj.Id);
                //retobj.RetailPrice = itemblob.
                //retobj.BlobData = itemblob.BlobData;
                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

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
            string strquery = "InsertCategory";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            
            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);


            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
            int retval = (int)rowsaffected.Value;
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
            string strquery = "UpdateCategory";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
           
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
            string strquery = "DeleteCategory";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

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
#endregion

