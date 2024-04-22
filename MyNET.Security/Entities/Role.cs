using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a Role.
    /// </summary>
    public class ERole
    {
        #region Class Members

        protected int mId;
        protected string mRoleName = String.Empty;

        #endregion

        #region Class constuctors
        ///Default constructor
        public ERole()
        {
        }

        ///Class type constructor
        public ERole(ERole obj)
        {
            mId = obj.Id;
            mRoleName = obj.RoleName;

        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public string RoleName
        {
            get { return mRoleName; }
            set { mRoleName = value; }
        }


        #endregion

    }
}



