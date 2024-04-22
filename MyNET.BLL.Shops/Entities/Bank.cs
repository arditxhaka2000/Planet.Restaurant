using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNET.Entities
{
    public class Bank
    {
        #region Class Members

        protected int mId;
        protected string mName = String.Empty;
        protected string mAccount = String.Empty;
        protected string mType;
        protected int mAccountId;
        protected DateTime mAmountPaid;
        protected string mCreatedBy = String.Empty;
        protected DateTime mChangedAt;
        protected string mChangedBy = String.Empty;        
        protected int mStatus;

        #endregion

        #region Class constuctors
        ///Default constructor
        public Bank()
        {
        }

        ///Class type constructor
        public Bank(Bank obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mAccount = obj.Account;
            mAccountId = obj.AccountId;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mType = obj.Type;
            OrderNo = obj.OrderNo;
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

        public string Type
        {
            get { return mType; }
            set { mType = value; }
        }

        public string Account
        {
            get { return mAccount; }
            set { mAccount = value; }
        }
        public int AccountId
        {
            get { return mAccountId; }
            set { mAccountId = value; }
        }
        public DateTime AmountPaid
        {
            get { return mAmountPaid; }
            set { mAmountPaid = value; }
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

        //public string Type { get; set; }

        public int OrderNo { get; set; }


        #endregion

    }
}
