using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MyNET;

namespace MyNET.Pos
{
    public partial class Base : Form
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
        //protected List<MyNET.Models.ISyncModel> mItemsList;
                 
        /// <summary>
        /// E ruan indeksin e elementit te selektuar ne  ne listen mItemsLists
        /// </summary>
        protected int mIndex = 0;

        /// <summary>
        /// E ruan vleren nese te dhenat kan fillu me u ndryshu ne objekt
        /// </summary>
        protected bool mIsChanged = false;

   


        //protected Form mDashboardForm = null;

        //public Form DashboardForm
        //{
        //    get { return mDashboardForm; }
        //    set { mDashboardForm = value; }
        //}

        #endregion

        #region Properties

        //public List<MyNET.Models.ISyncModel> DataSource
        //{
        //    get { return mItemsList; }
        //    set { mItemsList = value; }
        //}

        #endregion

        #region constructors

        public Base()
        {
            InitializeComponent();
        }


        #endregion

        #region Enable disable toolbar buttons

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
       
        //public bool EnableRegister
        //{
        //    get { return tsbRegister.Enabled; }
        //    set { tsbRegister.Enabled = value; }
        //}

        /*** ------------------------------------------- ***/
        /*** ------------------------------------------- ***/
        
        /// <summary>
        /// Shfletimi i objekteve ne liste, me shku para prapa.
        /// </summary>
        //public bool EnableNavigate
        //{
        //    get { return tsbMoveForward.Enabled; }
        //    set { tsbMoveForward.Enabled = tsbMoveBack.Enabled  = value; }
        //}
        /*** ------------------------------------------- ***/
        /*** ------------------------------------------- ***/

        public bool EnableExportExcell
        {
            get { return tsbImportExcel.Enabled; }
            set { tsbImportExcel.Enabled = value; }
        }

        //public bool EnableExportPDF
        //{
        //    get { return tsbExportPDF.Enabled; }
        //    set { tsbExportPDF.Enabled = value; }
        //}

        //public bool EnableExportXML
        //{
        //    get { return tsbExportXML.Enabled; }
        //    set { tsbExportXML.Enabled = value; }
        //}
        

        #endregion

        #region show hide toolbar buttons

        public bool VisibleNew
        {
            get { return tsbNew.Visible; }
            set { tsbNew.Visible = value; tssNew.Visible = value; }
        }

        public bool VisibleDelete
        {
            get { return tsbDelete.Visible; return tssDelete.Visible; }
            set { tsbDelete.Visible = value; tssDelete.Visible = value; }

        }

        public bool VisibleShowBackNext
        {
            get { return tsbBack.Visible; return tssPrapa.Visible; return tsbNext.Visible; return tssPara.Visible; }

            set { tsbBack.Visible = value; tssPrapa.Visible = value; tsbNext.Visible = value; tssPara.Visible = value; }
            
             
        }
       

        public bool VisibleSearchMenu
        {
            get { return tsbSaveClose.Visible;  return tssSearch.Visible;}
            set { tsbSaveClose.Visible = value; tssSearch.Visible = value; }

        }

        public bool VisibleSaveMenu
        {
            get { return tsbSave.Visible; return tssSave.Visible; }
            set { tsbSave.Visible = value; tssSave.Visible = value; }
        }

        public bool VisiblePrintMenu
        {
            get { return tsbPrint.Visible; return tssPrint.Visible; }
            set { tsbPrint.Visible = value; tssPrint.Visible = value; }
        }
        public bool VisibleOpenMenu
        {
            get { return tsbOpen.Visible; return tssOpen.Visible; }
            set { tsbOpen.Visible = value; tssOpen.Visible = value; }
        }
        public bool VisibleExportImport
        {
            get { return tsbExportExcel.Visible; return tssExport.Visible; return tsbImportExcel.Visible; return tssImport.Visible; return tsbPDF.Visible; return tssPDF.Visible; }
            set { tsbExportExcel.Visible = value; tssExport.Visible = value; tsbImportExcel.Visible = value; tssImport.Visible = value; tsbPDF.Visible = value; tssPDF.Visible = value; }
        }

        #endregion

        #region methods

        public void Help()
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
        protected virtual void SaveClose()
        {

        }
        protected virtual void Warehouse()
        {

        }
        protected virtual void Close1()
        {
            this.Close();
        }


        public virtual void Open()
        {
        }

       
        public virtual void Save()
        {
            //EnableRegister = true;
            EnableNew = true;
            EnableDelete = true;
            //EnableRefresh = false;
            mIsChanged = false;
        }

        public virtual void Delete()
        {
            //LoadData();
            
        }

        public virtual void Print()
        {
        }

        protected virtual void Register()
        {
        }
       
        protected virtual void Payment()
        {

        }

        /// <summary>
        /// I rilexon te dhenat ne baze te shenimeve
        /// </summary>
        public new virtual void Refresh()
        {            
            EnableNew = true;
        }

        protected virtual void MoveBack()
        {
            //if (mItemsList == null)
            //    return;
            //if (mIndex > 0)
            //{
            //    mIndex -= 1;
            //    LoadData();
            //}
            //if (mIndex == 0) tsbBack.Enabled = false;
        }

        protected virtual void MoveForward()
        {
            //if (mItemsList == null)
            //    return;

            //if (mIndex < mItemsList.Count)
            //{
            //    mIndex += 1;
            //    LoadData();
            //}
            //if (mIndex == mItemsList.Count) tsbNext.Enabled = false;
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

        protected new virtual bool Validate()
        {
            return true;
        }

        #endregion

        #region event handlers

        private void ts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbClose": Close1(); break;
                case "tsbNew": New(); break;
                case "tsbOpen" :Open();break;
                case "tsbSave": Save(); break;
                case "tsbDelete": Delete(); break;                
                case "tsbMoveBack": MoveBack(); break;
                case "tsbPrint": Print(); break;
                case "tsbMoveForward": MoveForward(); break;
                case "tsbExportExcel": ExportExcell(); break;
                case "tsbExportPDF": ExportPDF(); break;
                case "tsbExportXML": ExportXML(); break;
                //case "tsc1": Warehouse(); break;
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
                case Keys.F2: ts.Focus(); New(); break;
                case Keys.F3: Save(); break;
                case Keys.F4: Open(); break;
                case Keys.F5: Refresh(); break;
                case Keys.F9: Payment(); break;
                case Keys.F10: Print(); break;

                default: break;
            }
        }

        private void Base_Load(object sender, EventArgs e)
        {
            LoadData();
            //ts.BackColor = Color.FromName(Globals.UserSettings.Style);
        }

        #endregion

        //private void BaseForm_Load(object sender, EventArgs e)
        //{
        //    LoadData();
        //    //if (Globals.Settings.Style == ("Green"))
        //    //{
        //    //    ts.BackColor = Color.Green;
        //    //}
        //    //if (Globals.Settings.Style == ("SteelBlue"))
        //    //{
        //    //    ts.BackColor = Color.SteelBlue;
        //    //}
        //    //if (Globals.Settings.Style == ("OliveDrab"))
        //    //{
        //    //    ts.BackColor = Color.OliveDrab;
        //    //}
        //    //if (Globals.Settings.Style == ("Goldenrod"))
        //    //{
        //    //    ts.BackColor = Color.Goldenrod;
        //    //}
        //    //if (Globals.Settings.Style == ("Crimson"))
        //    //{
        //    //    ts.BackColor = Color.Crimson;
        //    //}
        //    //if (Globals.Settings.Style == ("Maroon"))
        //    //{
        //    //    ts.BackColor = Color.Maroon;
        //    //}
        //    //if (Globals.Settings.Style == ("Olive"))
        //    //{
        //    //    ts.BackColor = Color.Olive;
        //    //}
        //    //if (Globals.Settings.Style == ("DarkGreen"))
        //    //{
        //    //    ts.BackColor = Color.DarkGreen;
        //    //}
        //    //if (Globals.Settings.Style == ("SaddleBrown"))
        //    //{
        //    //    ts.BackColor = Color.SaddleBrown;
        //    //}
        //    //if (Globals.Settings.Style == ("OrangeRed"))
        //    //{
        //    //    ts.BackColor = Color.OrangeRed;
        //    //}


        //    //LoadColumns();
        //}

    }
}
