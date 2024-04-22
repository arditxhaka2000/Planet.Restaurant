using System;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.Security
{
    public class SiteIdentity : System.Security.Principal.IIdentity
    {
        #region class members

        private int userId;
        private string mName;
        private string email;
        private string password;

        #endregion

        #region Properties

        public string AuthenticationType
        {
            get { return "Custom Authentication"; }
        }

        public bool IsAuthenticated
        {
            get
            {
                // assumption: all instances of a SiteIdentity have already
                // been authenticated.
                return true;
            }
        }

        public int UserId
        {
            get { return userId; }
        }

        public string Name
        {
            get { return mName; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Password
        {
            get { return password; }
        }

        #endregion

        #region constuctors

        public SiteIdentity(string name)
        {
            User user = new User(name);

            this.userId = user.Id;
            this.mName = user.UserName;
            this.email = user.Email;
            this.password = user.Password;
        }

        public SiteIdentity(int userId)
        {
            User user = new User(userId);

            this.userId = user.Id;
            this.mName = user.UserName;
            this.email = user.Email;
            this.password = user.Password;
        }

        #endregion

        #region Methods



        #endregion



    }
}
