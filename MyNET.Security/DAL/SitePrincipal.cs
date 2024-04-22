using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace MyNET.Security
{
    public class SitePrincipal
    {
        protected SiteIdentity identity;
        protected List<Role> roleList;

        public SitePrincipal(string name)
        {
            identity = new SiteIdentity(name);
            roleList = User.GetUserRoles(((SiteIdentity)Identity).UserId);
        }

        public SitePrincipal(int userId)
        {
            identity = new SiteIdentity(userId);
            roleList = User.GetUserRoles(((SiteIdentity)Identity).UserId);
        }

        public static SitePrincipal ValidateLogin(string username, string password)
        {
            User usr = new User(username);

            if (usr.Id != 0 && usr.Password == password)
                return new SitePrincipal(usr.Id);
            else
                return null;
        }

        public bool IsInRole(string rolename)
        {
            bool contains = false;
            foreach(Role role in roleList)
            {
                if (role.RoleName.ToLower() == rolename.ToLower())
                {
                    contains = true;
                    break;
                }

            }
            return contains;
        }

        // Properties
        public SiteIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        public List<Role> Roles
        {
            get { return roleList; }
        }
    }
}
