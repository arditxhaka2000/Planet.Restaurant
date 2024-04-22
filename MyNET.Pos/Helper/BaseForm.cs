using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyNET.Pos
{
    public partial class BaseForm : Form
    {
        #region Class Members

        /// <summary>
        /// E ruan listen e objekteve te cilat munde te shfaqen me butonat Para - Pase
        /// p.sh. nese kemi shitje, ruhen id e shitjeve neper te cilat dojme me navigu para - pase
        /// Navigimi nuk behet sipas radhes se rekodeve qe jave ne databaze, por siaps radhes ne
        /// kete liste, sepse kete liste mundem me mushe me objekte sipas nje kerkimi te bere.
        /// P.sh. nese i kerkojm vetem shitjet e dites se sodit, kur navigoje para dhe pase na dalin
        /// vetem shitjet e sodit, duke fillu prej te pares deri tek e fundit per diten e zgjedhur
        /// </summary>
        protected object[] mItemsList;

        /// <summary>
        /// E ruan indeksin e elementit te selektuar ne  ne listen mItemsLists
        /// </summary>
        protected int mIndex = 0;

        /// <summary>
        /// E ruan vleren nese te dhenat kan fillu me u ndryshu ne objekt
        /// </summary>
        protected bool mIsChanged = false;

        #endregion

        #region constructors

        public BaseForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property per ti treguar listen e veglave kryesore
        /// </summary>
        public bool ShowMainToolbar
        {
            get { return ts.Visible; }
            set { ts.Visible = value; }
        }        
        
        /// <summary>
        /// Veti per me be butoni new ne toolbar aktive ose pasive
        /// </summary>
        public bool EnableNew
        {
            get { return tsbNew.Enabled; }
            set { tsbNew.Enabled = value; }
        }

        public bool EnableOpen
        {
            get { return tsbOpen.Enabled; }
            set { tsbOpen.Enabled = value; }
        }

        public bool EnableSave
        {
            get { return tsbSave.Enabled; }
            set { tsbSave.Enabled = value; }
        }

        public bool EnableDelete
        {
            get { return tsbDelete.Enabled; }
            set { tsbDelete.Enabled = value; }
        }
        /*** ------------------------------------------- ***/
        public bool EnableRefresh
        {
            get { return tsbRefresh.Enabled; }
            set { tsbRefresh.Enabled = value; }
        }

        public bool EnableRegister
        {
            get { return tsbRegister.Enabled; }
            set { tsbRegister.Enabled = value; }
        }

        /*** ------------------------------------------- ***/
        /*** ------------------------------------------- ***/
        
        /// <summary>
        /// Shfletimi i objekteve ne liste, me shku para prapa.
        /// </summary>
        public bool EnableNavigate
        {
            get { return tsbMoveForward.Enabled; }
            set { tsbMoveForward.Enabled = tsbMoveBack.Enabled  = value; }
        }
        /*** ------------------------------------------- ***/
        /*** ------------------------------------------- ***/

        public bool EnableExportExcell
        {
            get { return tsbExportExcel.Enabled; }
            set { tsbExportExcel.Enabled = value; }
        }

        public bool EnableExportPDF
        {
            get { return tsbExportPDF.Enabled; }
            set { tsbExportPDF.Enabled = value; }
        }

        public bool EnableExportXML
        {
            get { return tsbExportXML.Enabled; }
            set { tsbExportXML.Enabled = value; }
        }
        

        #endregion

        #region methods

        protected void Help()
        {
        }

        /// <summary>
        ///Metoda kur te shtohet nje element i ri
        ///duhet te mishkruhet ne kalasat qe trashegohet
        ///per implementinin e funksionaliteteve
        /// </summary>
        public virtual void New()
        {
            EnableSave = true;
            //mIsChanged = true;
        }

        protected virtual void Open()
        {
        }

        protected virtual void Save()
        {
            EnableRegister = true;
            EnableNew = true;
            EnableDelete = true;
            EnableRefresh = false;

            mIsChanged = false;
        }

        protected virtual void Delete()
        {
            LoadData();
        }

        protected virtual void Print()
        {
        }

        protected virtual void Register()
        {
        }
       
        /// <summary>
        /// I rilexon te dhenat ne baze te shenimeve
        /// </summary>
        protected virtual void Refresh()
        {
            LoadData();
            EnableNew = true;
            EnableSave = false;
            EnableDelete = true;
        }

        protected virtual void MoveBack()
        {
            if (mIndex > 0)
            {
                mIndex -= 1;
                LoadData();                
            }
            if (mIndex == 0) tsbMoveBack.Enabled = false;
        }

        protected virtual void MoveForward()
        {
            if (mIndex < mItemsList.Length)
            {
                mIndex += 1;
                LoadData();
            }
            if (mIndex == mItemsList.Length) tsbMoveForward.Enabled = false;
        }

        protected virtual void ExportExcell()
        {

        }

        protected virtual void ExportPDF()
        {
        }

        protected virtual void ExportXML()
        {
        }

        protected virtual void LoadData()
        {
        }

        #endregion

        #region event handlers

        private void ts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbNew": New(); break;
                case "tsbOpen" :Open();break;
                case "tsbSave": Save(); break;
                case "tsbDelete": Delete(); break;
                case "tsbRefresh": Refresh(); break;
                case "tsbRegister": Register(); break;
                case "tsbMoveBack": MoveBack(); break;
                case "tsbMoveForward": MoveForward(); break;
                case "tsbExportExcel": ExportExcell(); break;
                case "tsbExportPDF": ExportPDF(); break;
                case "tsbExportXML": ExportXML(); break;                
                    ///Vazhdon edhe per butona tjere
                default: break;

            }
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mIsChanged)
            {
                DialogResult result = MessageBox.Show("A dëshironi ti ruani ndryshimet e bëra?", "Ruaj ndryshimet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes: Save(); break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                    case DialogResult.No: break;
                    default: break;
                }
            }
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //case Keys.Escape: ClearFields(); break; 
                case Keys.F1: Help(); break;
                case Keys.F2: New(); break;
                case Keys.F3: Save(); break;                  

                case Keys.F5: Refresh(); break;
                //case Keys.F10: Print(); break;
                
                default: break;
            }
        }

        #endregion

        private void BaseForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tsbMoveBack_Click(object sender, EventArgs e)
        {

        }

       
    }
}
