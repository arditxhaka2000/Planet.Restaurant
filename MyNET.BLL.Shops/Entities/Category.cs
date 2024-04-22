using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a Categorie.
    /// </summary>
    public class Categorie
    {
        #region Class Members
               
        protected int mId;
        protected string mName = String.Empty;
        protected int mParentId;

        #endregion

        #region Class constuctors
        ///Default constructor
        public Categorie()
        {
        }

        ///Class type constructor
        public Categorie(Categorie obj)
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

