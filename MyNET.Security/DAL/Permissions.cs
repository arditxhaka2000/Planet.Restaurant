using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace MyNET.Security
{
    public enum PagePermission
    {
        Deny = -1,//Vetem me i pa te dhenat
        View = 0,//Me i editu te dhenat
        Write = 1,
        Full = 2
    }

    public class Permissions
    {
        public static PagePermission GetPremission(string user, int objectId)
        {
            //PagePermission retval = PagePermission.Deny;
            //DataTable table = MyNET.CMS.DAL.Permissions.GetPermissions(user, objectId);
            //if (table != null && table.Rows.Count > 0)
            //{
            //    foreach (DataRow row in table.Rows)
            //    {
            //        int rowval = (int)row[0];
            //        if (rowval > (int)retval)
            //            retval = (PagePermission)rowval;
            //    }
            //}
            //return retval;
            return PagePermission.Deny;
        }
    }
}
