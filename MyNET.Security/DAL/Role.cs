
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.Security
{

    /// <summary>
    /// This object represents the properties and methods of a Role.
    /// </summary>
    public class Role : MyNET.Entities.ERole
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Role()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Role(MyNET.Entities.ERole obj)
        {
            mId = obj.Id;
            mRoleName = obj.RoleName;

        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public Role(long Id)
        {
            string strquery = "select * from CMS_Roles where Id = @Id";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

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
        /// Load object from reader 
        /// </summary>
        /// <param name="dr">DataReader object</param>		
        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(1)) this.RoleName = dr.GetString(1);
            }
        }

        public Role(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static Role Get(long Id)
        {
            return new Role(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static List<Role> Get()
        {
            string strquery = "SELECT * FROM CMS_Roles ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;		
            SqlDataReader dr = null;
            Role retobj;
            List<Role> retobjs = new List<Role>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new Role(dr);
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
            string strquery = "INSERT INTO CMS_Roles(RoleName)" +
            " Values (@RoleName)" +
            " SELECT @Id = @@IdENTITY ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = RoleName;


            try
            {

                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                retval = cmd.ExecuteNonQuery();
                this.Id = (int)Id.Value;
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

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            string strquery = "UPDATE CMS_Roles SET RoleName = @RoleName WHERE Id = @Id;";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = RoleName;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


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
                if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;
            }
            return retval;
        }

       
        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string strquery = "Delete FROM CMS_Roles  WHERE Id = @Id; ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


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

        #endregion

    }
}


