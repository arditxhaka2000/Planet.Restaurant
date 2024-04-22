
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.Security
{

    /// <summary>
    /// This object represents the properties and methods of a User.
    /// </summary>
    public class User : MyNET.Entities.EUser
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public User(MyNET.Entities.EUser obj)
        {
            mId = obj.Id;
            mUserName = obj.UserName;
            mEmail = obj.Email;
            mPassword = obj.Password;
            mName = obj.Name;
            mSurname = obj.Surname;
            //mDateOfBirth = obj.DateOfBirth;
            //mCity = obj.City;
            //mCountry = obj.Country;
            mDateAdded = obj.DateAdded;
            mStationId = obj.StationId;
        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public User(long Id)
        {
            string strquery = "select * from CMS_Users where Id = @Id";
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
        /// Contructor by primarykey
        /// </summary>
        public User(string username)
        {
            string strquery = "select * from CMS_Users where username = @username";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            cmd.Parameters.Add("@username", SqlDbType.VarChar,50).Value = username;

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
               
                if (!dr.IsDBNull(dr.GetOrdinal("UserName"))) this.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                if (!dr.IsDBNull(dr.GetOrdinal("Email"))) this.Email = dr.GetString(dr.GetOrdinal("Email"));
                if (!dr.IsDBNull(dr.GetOrdinal("Password"))) this.Password = dr.GetString(dr.GetOrdinal("Password"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) this.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Surname"))) this.Surname = dr.GetString(dr.GetOrdinal("Surname"));
                //if (!dr.IsDBNull(dr.GetOrdinal("DateAdded"))) this.DateAdded = dr.GetDateTime(dr.GetOrdinal("DateAdded"));
                if (!dr.IsDBNull(dr.GetOrdinal("StationId"))) this.StationId = dr.GetInt32(dr.GetOrdinal("StationId"));
                //if (!dr.IsDBNull(dr.GetOrdinal("CashBoxId"))) this.CashBoxId = dr.GetInt32(dr.GetOrdinal("CashBoxId"));
            }
        }

        public User(SqlDataReader dr)
        {
            this.LoadFromReader(dr);
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static User Get(long Id)
        {
            return new User(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static List<User> GetByStation(int stationId)
        {
            string strquery = "SELECT U.Id,U.UserName,U.Email,U.Password,U.Name,U.Surname,S.Name CashBox,U.StationId,U.CreatedAt " +
                " FROM CMS_Users U LEFT JOIN Stations S ON S.Id = U.StationId and u.stationId = @stationId ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@stationId", stationId);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            User retobj;
            List<User> retobjs = new List<User>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new User(dr);
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


        public static List<Role> GetUserRoles(int Id)
        {
            string strquery = "SELECT * FROM CMS_Roles where Id in (select roleId from cms_userroles where userId = @Id) ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.AddWithValue("@Id", Id);
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
            string strquery = "INSERT INTO CMS_Users(UserName,Email,Password,Name,Surname,DateAdded,StationId)" +
            " Values (@UserName,@Email,@Password,@Name,@Surname,@DateAdded,@StationId)" +
            " SELECT @Id = @@IdENTITY ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = Surname;
            cmd.Parameters.Add("@DateAdded", SqlDbType.DateTime).Value = DateAdded;
            cmd.Parameters.Add("@StationId", SqlDbType.Int).Value = StationId;

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
            string strquery = "UPDATE CMS_Users SET UserName = @UserName,Email = @Email,Password = @Password,Name = @Name,Surname = @Surname," +
                "DateAdded = @DateAdded, StationId = @StationId WHERE Id = @Id;";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = Surname;            
            cmd.Parameters.Add("@DateAdded", SqlDbType.DateTime).Value = DateAdded;
            cmd.Parameters.Add("@StationId", SqlDbType.Int).Value = StationId;
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


        public static int SetUserCashBox(int userId,int cashBoxId)
        {
            string strquery = "UPDATE CMS_Users SET CashBoxId = @CashBoxId WHERE Id = @Id;";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.Add("@cashBoxId", SqlDbType.VarChar).Value = cashBoxId;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = userId;

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
            string strquery = "Delete FROM CMS_Users  WHERE Id = @Id; ";
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
         
        protected bool IsinRole(int roleId)
        {
            string strquery = "Select count(*) from cms_userroles where userId = @userId and roleId = @roleId";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userId", this.Id);
            cmd.Parameters.AddWithValue("@roleId", roleId);

            int retval = 0;
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                retval = (int) cmd.ExecuteScalar();
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
            return (retval > 0);
        }

        public int AddRole(int roleId)
        {
            if (this.IsinRole(roleId))
                return 0;

            string strquery = "Insert into CMS_UserRoles(userId,roleId) values (@userId,@roleId)";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userId", this.Id);
            cmd.Parameters.AddWithValue("@roleId", roleId);

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

        public int RemoveRole(int roleId)
        {
            string strquery = "Delete FROM CMS_UserRoles  WHERE userId = @userId and RoleId = @roleId;";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userId", this.Id);
            cmd.Parameters.AddWithValue("@roleId", roleId);

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


