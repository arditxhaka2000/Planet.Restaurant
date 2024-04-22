using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNET.Entities
{
    public class CashBox
    {
        #region Class Members
        
        protected int mId;
        protected string mName = String.Empty;
        protected int mWarehouseId;
        protected int mAccountId;
        //protected int mUserId;
        protected string mWarehouse;
        protected string mAccount;
        protected DateTime mAmountPaid;
        protected string mCreatedBy = String.Empty;
        protected DateTime mChangedAt;
        protected string mChangedBy = String.Empty;
        protected int mStatus;
        #endregion

        #region Class constuctors
        ///Default constructor
        public CashBox()
        {
        }

        ///Class type constructor
        public CashBox(CashBox obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mWarehouseId = obj.WarehouseId;
            mAccountId = obj.AccountId;
            mAccount = obj.Account;
            mWarehouse = obj.Warehouse;
            mAmountPaid = obj.AmountPaid;
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
        public int WarehouseId
        {
            get { return mWarehouseId; }
            set { mWarehouseId = value; }
        }
        public int AccountId
        {
            get { return mAccountId; }
            set { mAccountId = value; }
        }

        public string Warehouse
        {
            get { return mWarehouse; }
            set { mWarehouse = value; }
        }
        public string Account
        {
            get { return mAccount; }
            set { mAccount = value; }
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



        #endregion
    }
}
