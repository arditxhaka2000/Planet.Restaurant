

#region Unit Entities

using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a Unit.
    /// </summary>
    public class Station
    {
        #region Class Members



        protected int mId;
        protected int mParentId;
        protected string mName = String.Empty;
        protected DateTime mCreatedAt;
        protected string mCreatedBy = String.Empty;
        protected DateTime mChangedAt;
        protected string mChangedBy = String.Empty;
        protected int mStatus;
        #endregion

        #region Class constuctors
        ///Default constructor
        public Station()
        {
        }

        ///Class type constructor
        public Station(Station obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mParentId = obj.ParentId;
            mCreatedAt = obj.CreatedAt;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;
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
        public int ParentId
        {
            get { return mParentId; }
            set { mParentId = value; }
        }
        public DateTime CreatedAt
        {
            get { return mCreatedAt; }
            set { mCreatedAt = value; }
        }

        public string CreatedBy
        {
            get { return mCreatedBy; }
            set { mCreatedBy = value; }
        }

        public DateTime ChangedAt
        {
            get { return mChangedAt; }
            set { mChangedAt = value; }
        }

        public string ChangedBy
        {
            get { return mChangedBy; }
            set { mChangedBy = value; }
        }

        public int Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        #endregion

    }
}

#endregion

