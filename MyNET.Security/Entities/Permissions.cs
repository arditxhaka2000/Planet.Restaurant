using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a Permission.
    /// </summary>
    public class Permission
    {
        #region Class Members



        protected int mId;
        protected string mName = String.Empty;

        #endregion

        #region Class constuctors
        ///Default constructor
        public Permission()
        {
        }

        ///Class type constructor
        public Permission(Permission obj)
        {
            mId = obj.Id;
            mName = obj.Name;

        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }


        #endregion

    }
}



