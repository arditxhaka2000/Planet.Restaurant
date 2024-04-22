using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a User.
    /// </summary>
    public class EUser
    {
        #region Class Members

        protected int mId;
        protected string mUserName = String.Empty;
        protected string mEmail = String.Empty;
        protected string mPassword = String.Empty;
        protected string mName = String.Empty;
        protected string mSurname = String.Empty;
        //protected DateTime mDateOfBirth;
        //protected string mCity = String.Empty;
        //protected string mCountry = String.Empty;
        protected DateTime mDateAdded;
        protected int mStationId;

        #endregion

        #region Class constuctors
        ///Default constructor
        public EUser()
        {
        }

        ///Class type constructor
        public EUser(EUser obj)
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

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public int StationId
        {
            get { return mStationId; }
            set { mStationId = value; }
        }

        public string UserName
        {
            get { return mUserName; }
            set { mUserName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Surname
        {
            get { return mSurname; }
            set { mSurname = value; }
        }

        public DateTime DateAdded
        {
            get { return mDateAdded; }
            set { mDateAdded = value; }
        }


        #endregion

    }
}



