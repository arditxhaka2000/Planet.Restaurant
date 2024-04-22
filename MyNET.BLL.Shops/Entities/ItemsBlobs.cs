using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Entities
{
    public class ItemsBlobs
    {
        #region Class Members
        protected int mImageId;
        protected int mItemId;
        protected string mName;
        protected byte[] mBlobData;
        #endregion

        #region Class constuctors
        ///Default constructor
        public ItemsBlobs()
        {
        }

        ///Class type constructor
        public ItemsBlobs(ItemsBlobs obj)
        {
            mImageId = obj.ImageId;
            mItemId = obj.ItemId;
            mName = obj.Name;
            mBlobData = obj.BlobData;
        }
        #endregion

        #region Image
        public int ImageId
        {
            get { return mImageId; }
            set { mImageId = value; }
        }
        public int ItemId
        {
            get { return mItemId; }
            set { mItemId = value; }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public byte[] BlobData
        {
            get { return mBlobData; }
            set { mBlobData = value; }
        }

        #endregion

    }
}
