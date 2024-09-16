using MyNET.Pos.Helper;
using System.Windows.Forms;

namespace MyNET.Pos
{
    partial class RestaurantPos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestaurantPos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtsearchB = new System.Windows.Forms.ComboBox();
            this.txtsrchB = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNameAndQuant = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.word_station_branch = new System.Windows.Forms.Label();
            this.smlLogo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.word_user = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tblInfo = new System.Windows.Forms.TableLayoutPanel();
            this.eurSymbol = new System.Windows.Forms.TextBox();
            this.word_total = new System.Windows.Forms.TextBox();
            this.txtTotalSum = new System.Windows.Forms.TextBox();
            this.eursymb = new System.Windows.Forms.TextBox();
            this.txtTotalWVatSum = new System.Windows.Forms.TextBox();
            this.word_discount = new System.Windows.Forms.TextBox();
            this.percSymb = new System.Windows.Forms.TextBox();
            this.word_totalwithoutVat = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.word_client = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnnInvoice = new System.Windows.Forms.Button();
            this.cbPartners = new System.Windows.Forms.ComboBox();
            this.lblClientDisc = new System.Windows.Forms.Label();
            this.txtShortcuts = new System.Windows.Forms.TextBox();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.pnlGrids = new System.Windows.Forms.Panel();
            this.ug = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSubCat = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.txt = new System.Windows.Forms.TextBox();
            this.txtsearch = new System.Windows.Forms.ComboBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.pnlDrinks = new System.Windows.Forms.Panel();
            this.pnlItems1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.word_no_order = new System.Windows.Forms.TextBox();
            this.lblFiscalCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.word_print_the_coupon = new System.Windows.Forms.Button();
            this.word_cancel_order = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.paragraph_sale_saved_successfuly = new System.Windows.Forms.Button();
            this.paragraph_invoice_error = new System.Windows.Forms.Button();
            this.word_select_the_client = new System.Windows.Forms.Button();
            this.paragraph_quantity_num = new System.Windows.Forms.Button();
            this.paragraph_change_discount = new System.Windows.Forms.Button();
            this.paragraph_discount_ = new System.Windows.Forms.Button();
            this.paragraph_enter_number_price = new System.Windows.Forms.Button();
            this.word_error = new System.Windows.Forms.Button();
            this.paragraph_change_price = new System.Windows.Forms.Button();
            this.paragraph_select_row_change_quant = new System.Windows.Forms.Button();
            this.paragraph_sale_save_successful = new System.Windows.Forms.Button();
            this.report_invoici = new System.Windows.Forms.Button();
            this.word_deleting_the_sales_invoice = new System.Windows.Forms.Button();
            this.paragraph_invoice_without_item = new System.Windows.Forms.Button();
            this.paragraph_delete_invoice_question = new System.Windows.Forms.Button();
            this.paragraph_no_item_invoice = new System.Windows.Forms.Button();
            this.paragraph_invoice_cannotbesaved_ = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.word_save_changes = new System.Windows.Forms.Button();
            this.paragraph_fisc_with_zero = new System.Windows.Forms.Button();
            this.word_do_you_want_to_delete_all_items = new System.Windows.Forms.Button();
            this.word_print_again_ask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smlLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tblInfo.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.pnlGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ug)).BeginInit();
            this.tableLayoutPanel11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtB);
            this.splitContainer2.Panel1.Controls.Add(this.txtsearchB);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtsrchB);
            // 
            // txtB
            // 
            resources.ApplyResources(this.txtB, "txtB");
            this.txtB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.txtB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtB.ForeColor = System.Drawing.Color.White;
            this.txtB.Name = "txtB";
            this.txtB.Enter += new System.EventHandler(this.txtsrchB_Enter);
            this.txtB.Leave += new System.EventHandler(this.txtB_Leave);
            // 
            // txtsearchB
            // 
            resources.ApplyResources(this.txtsearchB, "txtsearchB");
            this.txtsearchB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtsearchB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtsearchB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.txtsearchB.DropDownWidth = 200;
            this.txtsearchB.ForeColor = System.Drawing.Color.White;
            this.txtsearchB.FormattingEnabled = true;
            this.txtsearchB.Name = "txtsearchB";
            this.txtsearchB.SelectionChangeCommitted += new System.EventHandler(this.txtsearchB_SelectionChangeCommitted);
            // 
            // txtsrchB
            // 
            resources.ApplyResources(this.txtsrchB, "txtsrchB");
            this.txtsrchB.BackColor = System.Drawing.Color.White;
            this.txtsrchB.ForeColor = System.Drawing.Color.Gray;
            this.txtsrchB.Name = "txtsrchB";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.pnlMenu, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.splitContainer2, 0, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.lblNameAndQuant);
            this.panel2.Name = "panel2";
            // 
            // lblNameAndQuant
            // 
            resources.ApplyResources(this.lblNameAndQuant, "lblNameAndQuant");
            this.lblNameAndQuant.ForeColor = System.Drawing.Color.White;
            this.lblNameAndQuant.Name = "lblNameAndQuant";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(82)))));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.tableLayoutPanel6);
            this.pnlMenu.Controls.Add(this.btnSignOut);
            resources.ApplyResources(this.pnlMenu, "pnlMenu");
            this.pnlMenu.Name = "pnlMenu";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.lblTime, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.word_station_branch, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.smlLogo, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.pictureBox1, 6, 0);
            this.tableLayoutPanel6.Controls.Add(this.word_user, 5, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Name = "lblTime";
            // 
            // word_station_branch
            // 
            resources.ApplyResources(this.word_station_branch, "word_station_branch");
            this.word_station_branch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.word_station_branch.ForeColor = System.Drawing.Color.White;
            this.word_station_branch.Name = "word_station_branch";
            // 
            // smlLogo
            // 
            this.smlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.smlLogo, "smlLogo");
            this.smlLogo.Image = global::MyNET.Pos.Properties.Resources.planet_accounting_logo_;
            this.smlLogo.Name = "smlLogo";
            this.smlLogo.TabStop = false;
            this.smlLogo.Click += new System.EventHandler(this.smlLogo_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::MyNET.Pos.Properties.Resources.logout;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // word_user
            // 
            this.word_user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.word_user, "word_user");
            this.word_user.ForeColor = System.Drawing.Color.White;
            this.word_user.Name = "word_user";
            this.word_user.UseVisualStyleBackColor = false;
            this.word_user.Click += new System.EventHandler(this.btnLogedUser_Click);
            // 
            // btnSignOut
            // 
            resources.ApplyResources(this.btnSignOut, "btnSignOut");
            this.btnSignOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(82)))));
            this.btnSignOut.ForeColor = System.Drawing.Color.White;
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.pnlTotal, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pnlGrids, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel11, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlButtons, 1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // pnlTotal
            // 
            resources.ApplyResources(this.pnlTotal, "pnlTotal");
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(82)))));
            this.pnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotal.Controls.Add(this.tableLayoutPanel9);
            this.pnlTotal.Controls.Add(this.btnInvoice);
            this.pnlTotal.Name = "pnlTotal";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutPanel9, "tableLayoutPanel9");
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.tblInfo, 0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // tblInfo
            // 
            this.tblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tblInfo, "tblInfo");
            this.tblInfo.Controls.Add(this.eurSymbol, 2, 2);
            this.tblInfo.Controls.Add(this.word_total, 0, 2);
            this.tblInfo.Controls.Add(this.txtTotalSum, 1, 2);
            this.tblInfo.Controls.Add(this.eursymb, 2, 1);
            this.tblInfo.Controls.Add(this.txtTotalWVatSum, 1, 1);
            this.tblInfo.Controls.Add(this.word_discount, 0, 0);
            this.tblInfo.Controls.Add(this.percSymb, 3, 0);
            this.tblInfo.Controls.Add(this.word_totalwithoutVat, 0, 1);
            this.tblInfo.Controls.Add(this.txtDiscount, 1, 0);
            this.tblInfo.Name = "tblInfo";
            // 
            // eurSymbol
            // 
            this.eurSymbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.eurSymbol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.eurSymbol, "eurSymbol");
            this.eurSymbol.ForeColor = System.Drawing.Color.White;
            this.eurSymbol.Name = "eurSymbol";
            // 
            // word_total
            // 
            this.word_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.word_total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.word_total, "word_total");
            this.word_total.ForeColor = System.Drawing.Color.White;
            this.word_total.Name = "word_total";
            this.word_total.ReadOnly = true;
            this.word_total.TabStop = false;
            // 
            // txtTotalSum
            // 
            this.txtTotalSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.txtTotalSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtTotalSum, "txtTotalSum");
            this.txtTotalSum.ForeColor = System.Drawing.Color.White;
            this.txtTotalSum.Name = "txtTotalSum";
            this.txtTotalSum.ReadOnly = true;
            this.txtTotalSum.TabStop = false;
            this.txtTotalSum.TextChanged += new System.EventHandler(this.txtTotalSum_TextChanged);
            // 
            // eursymb
            // 
            this.eursymb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.eursymb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.eursymb, "eursymb");
            this.eursymb.ForeColor = System.Drawing.Color.White;
            this.eursymb.Name = "eursymb";
            // 
            // txtTotalWVatSum
            // 
            this.txtTotalWVatSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.txtTotalWVatSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtTotalWVatSum, "txtTotalWVatSum");
            this.txtTotalWVatSum.ForeColor = System.Drawing.Color.White;
            this.txtTotalWVatSum.Name = "txtTotalWVatSum";
            this.txtTotalWVatSum.ReadOnly = true;
            this.txtTotalWVatSum.TabStop = false;
            // 
            // word_discount
            // 
            this.word_discount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.word_discount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.word_discount, "word_discount");
            this.word_discount.ForeColor = System.Drawing.Color.White;
            this.word_discount.Name = "word_discount";
            this.word_discount.ReadOnly = true;
            this.word_discount.TabStop = false;
            // 
            // percSymb
            // 
            this.percSymb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.percSymb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.percSymb, "percSymb");
            this.percSymb.ForeColor = System.Drawing.Color.White;
            this.percSymb.Name = "percSymb";
            // 
            // word_totalwithoutVat
            // 
            this.word_totalwithoutVat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.word_totalwithoutVat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.word_totalwithoutVat, "word_totalwithoutVat");
            this.word_totalwithoutVat.ForeColor = System.Drawing.Color.White;
            this.word_totalwithoutVat.Name = "word_totalwithoutVat";
            this.word_totalwithoutVat.ReadOnly = true;
            this.word_totalwithoutVat.TabStop = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtDiscount, "txtDiscount");
            this.txtDiscount.ForeColor = System.Drawing.Color.White;
            this.txtDiscount.Name = "txtDiscount";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tableLayoutPanel8, "tableLayoutPanel8");
            this.tableLayoutPanel8.Controls.Add(this.word_client, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnAddClient, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnnInvoice, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.cbPartners, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblClientDisc, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.txtShortcuts, 0, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            // 
            // word_client
            // 
            this.word_client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.word_client, "word_client");
            this.word_client.FlatAppearance.BorderSize = 0;
            this.word_client.ForeColor = System.Drawing.Color.White;
            this.word_client.Name = "word_client";
            this.word_client.UseVisualStyleBackColor = false;
            this.word_client.Click += new System.EventHandler(this.BtnClient_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.btnAddClient, "btnAddClient");
            this.btnAddClient.FlatAppearance.BorderSize = 0;
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnnInvoice
            // 
            this.btnnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.btnnInvoice, "btnnInvoice");
            this.btnnInvoice.FlatAppearance.BorderSize = 0;
            this.btnnInvoice.ForeColor = System.Drawing.Color.White;
            this.btnnInvoice.Name = "btnnInvoice";
            this.btnnInvoice.UseVisualStyleBackColor = false;
            this.btnnInvoice.Click += new System.EventHandler(this.btnnInvoice_Click);
            // 
            // cbPartners
            // 
            this.cbPartners.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.tableLayoutPanel8.SetColumnSpan(this.cbPartners, 3);
            resources.ApplyResources(this.cbPartners, "cbPartners");
            this.cbPartners.ForeColor = System.Drawing.Color.White;
            this.cbPartners.FormattingEnabled = true;
            this.cbPartners.Name = "cbPartners";
            this.cbPartners.SelectedIndexChanged += new System.EventHandler(this.cbPartners_SelectedIndexChanged);
            // 
            // lblClientDisc
            // 
            resources.ApplyResources(this.lblClientDisc, "lblClientDisc");
            this.lblClientDisc.Name = "lblClientDisc";
            // 
            // txtShortcuts
            // 
            this.txtShortcuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.txtShortcuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel8.SetColumnSpan(this.txtShortcuts, 3);
            resources.ApplyResources(this.txtShortcuts, "txtShortcuts");
            this.txtShortcuts.ForeColor = System.Drawing.Color.White;
            this.txtShortcuts.Name = "txtShortcuts";
            // 
            // btnInvoice
            // 
            resources.ApplyResources(this.btnInvoice, "btnInvoice");
            this.btnInvoice.BackColor = System.Drawing.Color.LightGray;
            this.btnInvoice.FlatAppearance.BorderSize = 0;
            this.btnInvoice.ForeColor = System.Drawing.Color.Black;
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.UseVisualStyleBackColor = false;
            // 
            // pnlGrids
            // 
            resources.ApplyResources(this.pnlGrids, "pnlGrids");
            this.pnlGrids.BackColor = System.Drawing.Color.White;
            this.pnlGrids.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrids.Controls.Add(this.ug);
            this.pnlGrids.Name = "pnlGrids";
            // 
            // ug
            // 
            this.ug.AllowUserToAddRows = false;
            this.ug.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.ug.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ug.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ug.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ug.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.ug.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ug.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ug.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ug.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.ug, "ug");
            this.ug.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.ug.Name = "ug";
            this.ug.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ug.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ug.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ug.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ug.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.ug.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.ug.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.ug.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.LightSkyBlue;
            this.ug.RowTemplate.Height = 24;
            this.ug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ug.DataSourceChanged += new System.EventHandler(this.ug_DataSourceChanged);
            this.ug.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ug_CellContentClick);
            this.ug.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ug_CellEndEdit);
            this.ug.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.ug.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ug_CellValidating);
            // 
            // tableLayoutPanel11
            // 
            resources.ApplyResources(this.tableLayoutPanel11, "tableLayoutPanel11");
            this.tableLayoutPanel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.tableLayoutPanel11.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.pnlItems, 0, 1);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.pnlSubCat);
            this.panel1.Controls.Add(this.pnlCategories);
            this.panel1.Controls.Add(this.txt);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Controls.Add(this.lblBarcode);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pnlSubCat
            // 
            resources.ApplyResources(this.pnlSubCat, "pnlSubCat");
            this.pnlSubCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.pnlSubCat.Name = "pnlSubCat";
            // 
            // pnlCategories
            // 
            resources.ApplyResources(this.pnlCategories, "pnlCategories");
            this.pnlCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.pnlCategories.Name = "pnlCategories";
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txt, "txt");
            this.txt.ForeColor = System.Drawing.Color.White;
            this.txt.Name = "txt";
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.Enter += new System.EventHandler(this.txtSearchName_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtt_KeyDown);
            this.txt.Leave += new System.EventHandler(this.txtSearchName_Leave);
            // 
            // txtsearch
            // 
            this.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtsearch.BackColor = System.Drawing.Color.White;
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtsearch.DropDownWidth = 200;
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.ForeColor = System.Drawing.Color.Black;
            this.txtsearch.FormattingEnabled = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.SelectionChangeCommitted += new System.EventHandler(this.txtSearchName_SelectionChangeCommitted);
            // 
            // lblBarcode
            // 
            resources.ApplyResources(this.lblBarcode, "lblBarcode");
            this.lblBarcode.Name = "lblBarcode";
            // 
            // pnlItems
            // 
            resources.ApplyResources(this.pnlItems, "pnlItems");
            this.pnlItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.pnlItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlItems.Controls.Add(this.pnlDrinks);
            this.pnlItems.Controls.Add(this.pnlItems1);
            this.pnlItems.Name = "pnlItems";
            // 
            // pnlDrinks
            // 
            resources.ApplyResources(this.pnlDrinks, "pnlDrinks");
            this.pnlDrinks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.pnlDrinks.Name = "pnlDrinks";
            // 
            // pnlItems1
            // 
            resources.ApplyResources(this.pnlItems1, "pnlItems1");
            this.pnlItems1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.pnlItems1.Name = "pnlItems1";
            // 
            // pnlButtons
            // 
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtons.Controls.Add(this.tableLayoutPanel1);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.tableLayoutPanel5.Controls.Add(this.word_no_order, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblFiscalCount, 1, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // word_no_order
            // 
            this.word_no_order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.word_no_order.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.word_no_order, "word_no_order");
            this.word_no_order.ForeColor = System.Drawing.Color.White;
            this.word_no_order.Name = "word_no_order";
            this.word_no_order.ReadOnly = true;
            this.word_no_order.TabStop = false;
            // 
            // lblFiscalCount
            // 
            resources.ApplyResources(this.lblFiscalCount, "lblFiscalCount");
            this.lblFiscalCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblFiscalCount.ForeColor = System.Drawing.Color.White;
            this.lblFiscalCount.Name = "lblFiscalCount";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.word_print_the_coupon, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.word_cancel_order, 3, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(96)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(121)))), ((int)(((byte)(254)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(138)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // word_print_the_coupon
            // 
            resources.ApplyResources(this.word_print_the_coupon, "word_print_the_coupon");
            this.word_print_the_coupon.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.word_print_the_coupon.FlatAppearance.BorderSize = 0;
            this.word_print_the_coupon.ForeColor = System.Drawing.Color.White;
            this.word_print_the_coupon.Name = "word_print_the_coupon";
            this.word_print_the_coupon.UseVisualStyleBackColor = false;
            this.word_print_the_coupon.Click += new System.EventHandler(this.word_print_the_coupon_Click);
            // 
            // word_cancel_order
            // 
            resources.ApplyResources(this.word_cancel_order, "word_cancel_order");
            this.word_cancel_order.BackColor = System.Drawing.Color.Brown;
            this.word_cancel_order.FlatAppearance.BorderSize = 0;
            this.word_cancel_order.ForeColor = System.Drawing.Color.White;
            this.word_cancel_order.Name = "word_cancel_order";
            this.word_cancel_order.UseVisualStyleBackColor = false;
            this.word_cancel_order.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // paragraph_sale_saved_successfuly
            // 
            resources.ApplyResources(this.paragraph_sale_saved_successfuly, "paragraph_sale_saved_successfuly");
            this.paragraph_sale_saved_successfuly.Name = "paragraph_sale_saved_successfuly";
            this.paragraph_sale_saved_successfuly.UseVisualStyleBackColor = true;
            // 
            // paragraph_invoice_error
            // 
            resources.ApplyResources(this.paragraph_invoice_error, "paragraph_invoice_error");
            this.paragraph_invoice_error.Name = "paragraph_invoice_error";
            this.paragraph_invoice_error.UseVisualStyleBackColor = true;
            // 
            // word_select_the_client
            // 
            resources.ApplyResources(this.word_select_the_client, "word_select_the_client");
            this.word_select_the_client.Name = "word_select_the_client";
            this.word_select_the_client.UseVisualStyleBackColor = true;
            // 
            // paragraph_quantity_num
            // 
            resources.ApplyResources(this.paragraph_quantity_num, "paragraph_quantity_num");
            this.paragraph_quantity_num.Name = "paragraph_quantity_num";
            this.paragraph_quantity_num.UseVisualStyleBackColor = true;
            // 
            // paragraph_change_discount
            // 
            resources.ApplyResources(this.paragraph_change_discount, "paragraph_change_discount");
            this.paragraph_change_discount.Name = "paragraph_change_discount";
            this.paragraph_change_discount.UseVisualStyleBackColor = true;
            // 
            // paragraph_discount_
            // 
            resources.ApplyResources(this.paragraph_discount_, "paragraph_discount_");
            this.paragraph_discount_.Name = "paragraph_discount_";
            this.paragraph_discount_.UseVisualStyleBackColor = true;
            // 
            // paragraph_enter_number_price
            // 
            resources.ApplyResources(this.paragraph_enter_number_price, "paragraph_enter_number_price");
            this.paragraph_enter_number_price.Name = "paragraph_enter_number_price";
            this.paragraph_enter_number_price.UseVisualStyleBackColor = true;
            // 
            // word_error
            // 
            resources.ApplyResources(this.word_error, "word_error");
            this.word_error.Name = "word_error";
            this.word_error.UseVisualStyleBackColor = true;
            // 
            // paragraph_change_price
            // 
            resources.ApplyResources(this.paragraph_change_price, "paragraph_change_price");
            this.paragraph_change_price.Name = "paragraph_change_price";
            this.paragraph_change_price.UseVisualStyleBackColor = true;
            // 
            // paragraph_select_row_change_quant
            // 
            resources.ApplyResources(this.paragraph_select_row_change_quant, "paragraph_select_row_change_quant");
            this.paragraph_select_row_change_quant.Name = "paragraph_select_row_change_quant";
            this.paragraph_select_row_change_quant.UseVisualStyleBackColor = true;
            // 
            // paragraph_sale_save_successful
            // 
            resources.ApplyResources(this.paragraph_sale_save_successful, "paragraph_sale_save_successful");
            this.paragraph_sale_save_successful.Name = "paragraph_sale_save_successful";
            this.paragraph_sale_save_successful.UseVisualStyleBackColor = true;
            // 
            // report_invoici
            // 
            resources.ApplyResources(this.report_invoici, "report_invoici");
            this.report_invoici.Name = "report_invoici";
            this.report_invoici.UseVisualStyleBackColor = true;
            // 
            // word_deleting_the_sales_invoice
            // 
            resources.ApplyResources(this.word_deleting_the_sales_invoice, "word_deleting_the_sales_invoice");
            this.word_deleting_the_sales_invoice.Name = "word_deleting_the_sales_invoice";
            this.word_deleting_the_sales_invoice.UseVisualStyleBackColor = true;
            // 
            // paragraph_invoice_without_item
            // 
            resources.ApplyResources(this.paragraph_invoice_without_item, "paragraph_invoice_without_item");
            this.paragraph_invoice_without_item.Name = "paragraph_invoice_without_item";
            this.paragraph_invoice_without_item.UseVisualStyleBackColor = true;
            // 
            // paragraph_delete_invoice_question
            // 
            resources.ApplyResources(this.paragraph_delete_invoice_question, "paragraph_delete_invoice_question");
            this.paragraph_delete_invoice_question.Name = "paragraph_delete_invoice_question";
            this.paragraph_delete_invoice_question.UseVisualStyleBackColor = true;
            // 
            // paragraph_no_item_invoice
            // 
            resources.ApplyResources(this.paragraph_no_item_invoice, "paragraph_no_item_invoice");
            this.paragraph_no_item_invoice.Name = "paragraph_no_item_invoice";
            this.paragraph_no_item_invoice.UseVisualStyleBackColor = true;
            // 
            // paragraph_invoice_cannotbesaved_
            // 
            resources.ApplyResources(this.paragraph_invoice_cannotbesaved_, "paragraph_invoice_cannotbesaved_");
            this.paragraph_invoice_cannotbesaved_.Name = "paragraph_invoice_cannotbesaved_";
            this.paragraph_invoice_cannotbesaved_.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // word_save_changes
            // 
            resources.ApplyResources(this.word_save_changes, "word_save_changes");
            this.word_save_changes.Name = "word_save_changes";
            this.word_save_changes.UseVisualStyleBackColor = true;
            // 
            // paragraph_fisc_with_zero
            // 
            resources.ApplyResources(this.paragraph_fisc_with_zero, "paragraph_fisc_with_zero");
            this.paragraph_fisc_with_zero.Name = "paragraph_fisc_with_zero";
            this.paragraph_fisc_with_zero.UseVisualStyleBackColor = true;
            // 
            // word_do_you_want_to_delete_all_items
            // 
            resources.ApplyResources(this.word_do_you_want_to_delete_all_items, "word_do_you_want_to_delete_all_items");
            this.word_do_you_want_to_delete_all_items.Name = "word_do_you_want_to_delete_all_items";
            this.word_do_you_want_to_delete_all_items.UseVisualStyleBackColor = true;
            // 
            // word_print_again_ask
            // 
            resources.ApplyResources(this.word_print_again_ask, "word_print_again_ask");
            this.word_print_again_ask.Name = "word_print_again_ask";
            this.word_print_again_ask.UseVisualStyleBackColor = true;
            // 
            // RestaurantPos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.paragraph_no_item_invoice);
            this.Controls.Add(this.paragraph_invoice_cannotbesaved_);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.word_save_changes);
            this.Controls.Add(this.paragraph_fisc_with_zero);
            this.Controls.Add(this.word_do_you_want_to_delete_all_items);
            this.Controls.Add(this.word_print_again_ask);
            this.Controls.Add(this.paragraph_sale_save_successful);
            this.Controls.Add(this.report_invoici);
            this.Controls.Add(this.word_deleting_the_sales_invoice);
            this.Controls.Add(this.paragraph_invoice_without_item);
            this.Controls.Add(this.paragraph_delete_invoice_question);
            this.Controls.Add(this.paragraph_select_row_change_quant);
            this.Controls.Add(this.paragraph_change_price);
            this.Controls.Add(this.word_error);
            this.Controls.Add(this.paragraph_enter_number_price);
            this.Controls.Add(this.paragraph_discount_);
            this.Controls.Add(this.paragraph_change_discount);
            this.Controls.Add(this.paragraph_quantity_num);
            this.Controls.Add(this.word_select_the_client);
            this.Controls.Add(this.paragraph_invoice_error);
            this.Controls.Add(this.paragraph_sale_saved_successfuly);
            this.KeyPreview = true;
            this.Name = "RestaurantPos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PosRestaurant_FormClosing);
            this.Load += new System.EventHandler(this.PosSales_Load);
            this.CursorChanged += new System.EventHandler(this.PosRestaurant_CursorChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pos_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PosRestaurant_KeyPress);
            this.Resize += new System.EventHandler(this.PosRestaurant_Resize);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smlLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tblInfo.ResumeLayout(false);
            this.tblInfo.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.pnlGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ug)).EndInit();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion
        public System.Windows.Forms.Button word_client;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button word_user;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox smlLogo;
        private System.Windows.Forms.Label word_station_branch;

        public System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button paragraph_sale_saved_successfuly;
        private System.Windows.Forms.Button paragraph_invoice_error;
        private System.Windows.Forms.Button word_select_the_client;
        private System.Windows.Forms.Button paragraph_quantity_num;
        private System.Windows.Forms.Button paragraph_change_discount;
        private System.Windows.Forms.Button paragraph_discount_;
        private System.Windows.Forms.Button paragraph_enter_number_price;
        private System.Windows.Forms.Button word_error;
        private System.Windows.Forms.Button paragraph_change_price;
        private System.Windows.Forms.Button paragraph_select_row_change_quant;
        private System.Windows.Forms.Button paragraph_sale_save_successful;
        private System.Windows.Forms.Button report_invoici;
        private System.Windows.Forms.Button word_deleting_the_sales_invoice;
        private System.Windows.Forms.Button paragraph_invoice_without_item;
        private System.Windows.Forms.Button paragraph_delete_invoice_question;
        private System.Windows.Forms.Button paragraph_no_item_invoice;
        private System.Windows.Forms.Button paragraph_invoice_cannotbesaved_;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button word_save_changes;
        private System.Windows.Forms.Button paragraph_fisc_with_zero;
        private System.Windows.Forms.Button word_do_you_want_to_delete_all_items;
        private System.Windows.Forms.Button word_print_again_ask;
        public System.Windows.Forms.Button btnAddClient;
        public System.Windows.Forms.Button btnnInvoice;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.ComboBox txtsearchB;
        public System.Windows.Forms.TextBox txtsrchB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNameAndQuant;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private ComboBox cbPartners;
        private TextBox txtB;
        private SplitContainer splitContainer2;
        private TextBox txt;
        private ComboBox txtsearch;
        private TableLayoutPanel tableLayoutPanel11;
        private Panel panel1;
        private Label lblBarcode;
        private Label lblClientDisc;
        private TableLayoutPanel tblInfo;
        private TextBox eurSymbol;
        public TextBox word_total;
        public TextBox txtTotalSum;
        private TextBox eursymb;
        public TextBox txtTotalWVatSum;
        public TextBox word_discount;
        private TextBox percSymb;
        public TextBox word_totalwithoutVat;
        private TextBox txtDiscount;
        private FlowLayoutPanel pnlSubCat;
        private Panel pnlItems;
        private Panel pnlDrinks;
        private FlowLayoutPanel pnlItems1;
        private TextBox txtShortcuts;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        public TextBox word_no_order;
        private Label lblFiscalCount;
        public Button word_cancel_order;
        public Button word_print_the_coupon;
        public Button button3;
        public Button button2;
        public Button button1;
        private Panel pnlGrids;
        private DataGridView ug;
        private FlowLayoutPanel pnlCategories;
    }
}