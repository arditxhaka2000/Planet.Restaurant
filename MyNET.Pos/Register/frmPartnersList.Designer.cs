namespace T3.Pos
{
    partial class frmPartnersList
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            this.grSearch = new System.Windows.Forms.GroupBox();
            this.cbCusSup = new System.Windows.Forms.CheckBox();
            this.cbSupplier = new System.Windows.Forms.CheckBox();
            this.cbCustomer = new System.Windows.Forms.CheckBox();
            this.txtFiscal = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblFiscal = new System.Windows.Forms.Label();
            this.grUg = new System.Windows.Forms.GroupBox();
            this.ug = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.grChart = new System.Windows.Forms.GroupBox();
            this.grSearch.SuspendLayout();
            this.grUg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ug)).BeginInit();
            this.SuspendLayout();
            // 
            // grSearch
            // 
            this.grSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grSearch.AutoSize = true;
            this.grSearch.Controls.Add(this.cbCusSup);
            this.grSearch.Controls.Add(this.cbSupplier);
            this.grSearch.Controls.Add(this.cbCustomer);
            this.grSearch.Controls.Add(this.txtFiscal);
            this.grSearch.Controls.Add(this.btnSearch);
            this.grSearch.Controls.Add(this.lblFiscal);
            this.grSearch.Location = new System.Drawing.Point(12, 73);
            this.grSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grSearch.Name = "grSearch";
            this.grSearch.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grSearch.Size = new System.Drawing.Size(1132, 167);
            this.grSearch.TabIndex = 13;
            this.grSearch.TabStop = false;
            // 
            // cbCusSup
            // 
            this.cbCusSup.AutoSize = true;
            this.cbCusSup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCusSup.Location = new System.Drawing.Point(251, 70);
            this.cbCusSup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCusSup.Name = "cbCusSup";
            this.cbCusSup.Size = new System.Drawing.Size(153, 24);
            this.cbCusSup.TabIndex = 106;
            this.cbCusSup.Tag = "1";
            this.cbCusSup.Text = "Blerës / Furnitor";
            this.cbCusSup.UseVisualStyleBackColor = true;
            this.cbCusSup.Click += new System.EventHandler(this.cbCusSup_Click);
            // 
            // cbSupplier
            // 
            this.cbSupplier.AutoSize = true;
            this.cbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSupplier.Location = new System.Drawing.Point(133, 70);
            this.cbSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(89, 24);
            this.cbSupplier.TabIndex = 105;
            this.cbSupplier.Tag = "1";
            this.cbSupplier.Text = "Furnitor";
            this.cbSupplier.UseVisualStyleBackColor = true;
            this.cbSupplier.Click += new System.EventHandler(this.cbSupplier_Click);
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoSize = true;
            this.cbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Location = new System.Drawing.Point(19, 70);
            this.cbCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(80, 24);
            this.cbCustomer.TabIndex = 104;
            this.cbCustomer.Tag = "1";
            this.cbCustomer.Text = "Blerës";
            this.cbCustomer.UseVisualStyleBackColor = true;
            this.cbCustomer.Click += new System.EventHandler(this.cbCustomer_Click);
            // 
            // txtFiscal
            // 
            this.txtFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiscal.Location = new System.Drawing.Point(19, 33);
            this.txtFiscal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFiscal.Name = "txtFiscal";
            this.txtFiscal.Size = new System.Drawing.Size(377, 27);
            this.txtFiscal.TabIndex = 101;
            this.txtFiscal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiscal_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(19, 110);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(203, 33);
            this.btnSearch.TabIndex = 98;
            this.btnSearch.Text = "Kërko";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblFiscal
            // 
            this.lblFiscal.AutoSize = true;
            this.lblFiscal.BackColor = System.Drawing.Color.Transparent;
            this.lblFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiscal.Location = new System.Drawing.Point(13, 7);
            this.lblFiscal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiscal.Name = "lblFiscal";
            this.lblFiscal.Size = new System.Drawing.Size(52, 20);
            this.lblFiscal.TabIndex = 93;
            this.lblFiscal.Text = "Kërko";
            // 
            // grUg
            // 
            this.grUg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grUg.AutoSize = true;
            this.grUg.Controls.Add(this.ug);
            this.grUg.Location = new System.Drawing.Point(12, 245);
            this.grUg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grUg.Name = "grUg";
            this.grUg.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grUg.Size = new System.Drawing.Size(1132, 427);
            this.grUg.TabIndex = 14;
            this.grUg.TabStop = false;
            // 
            // ug
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ug.DisplayLayout.Appearance = appearance1;
            this.ug.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ug.DisplayLayout.CaptionAppearance = appearance14;
            this.ug.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ug.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ug.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.ug.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ug.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.ug.DisplayLayout.MaxColScrollRegions = 1;
            this.ug.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ug.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ug.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ug.DisplayLayout.Override.AddRowAppearance = appearance15;
            this.ug.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ug.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.ug.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ug.DisplayLayout.Override.CellAppearance = appearance8;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ug.DisplayLayout.Override.CellButtonAppearance = appearance19;
            this.ug.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ug.DisplayLayout.Override.CellPadding = 0;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ug.DisplayLayout.Override.EditCellAppearance = appearance20;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ug.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.ug.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.ug.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ug.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.ug.DisplayLayout.Override.RowAppearance = appearance11;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ug.DisplayLayout.Override.RowSelectorAppearance = appearance21;
            this.ug.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ug.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            appearance16.BackColor = System.Drawing.Color.Silver;
            appearance16.BackColor2 = System.Drawing.Color.Silver;
            appearance16.BackColorDisabled = System.Drawing.Color.Silver;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.BackHatchStyle = Infragistics.Win.BackHatchStyle.Vertical;
            appearance16.BorderColor = System.Drawing.Color.SteelBlue;
            appearance16.BorderColor2 = System.Drawing.Color.SteelBlue;
            appearance16.BorderColor3DBase = System.Drawing.Color.SteelBlue;
            scrollBarLook1.Appearance = appearance16;
            appearance13.BackColor = System.Drawing.Color.SkyBlue;
            appearance13.BackColor2 = System.Drawing.Color.SkyBlue;
            appearance13.BackColorDisabled = System.Drawing.Color.SkyBlue;
            appearance13.BackColorDisabled2 = System.Drawing.Color.SkyBlue;
            appearance13.BorderColor = System.Drawing.Color.SkyBlue;
            appearance13.BorderColor2 = System.Drawing.Color.SkyBlue;
            appearance13.BorderColor3DBase = System.Drawing.Color.SkyBlue;
            scrollBarLook1.ButtonAppearance = appearance13;
            appearance17.BackColor = System.Drawing.Color.SkyBlue;
            appearance17.BackColor2 = System.Drawing.Color.SkyBlue;
            appearance17.BackColorDisabled = System.Drawing.Color.SkyBlue;
            appearance17.BackColorDisabled2 = System.Drawing.Color.SkyBlue;
            appearance17.BorderColor = System.Drawing.Color.SkyBlue;
            appearance17.BorderColor2 = System.Drawing.Color.SkyBlue;
            appearance17.BorderColor3DBase = System.Drawing.Color.SkyBlue;
            scrollBarLook1.ThumbAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.Silver;
            appearance18.BackColor2 = System.Drawing.Color.Silver;
            appearance18.BackColorDisabled = System.Drawing.Color.Silver;
            appearance18.BackColorDisabled2 = System.Drawing.Color.Silver;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.BackHatchStyle = Infragistics.Win.BackHatchStyle.Horizontal;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.BorderColor2 = System.Drawing.Color.Silver;
            appearance18.BorderColor3DBase = System.Drawing.Color.Silver;
            scrollBarLook1.TrackAppearance = appearance18;
            this.ug.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.ug.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ug.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ug.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ug.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ug.Location = new System.Drawing.Point(5, 22);
            this.ug.Margin = new System.Windows.Forms.Padding(4);
            this.ug.Name = "ug";
            this.ug.Size = new System.Drawing.Size(585, 378);
            this.ug.TabIndex = 31;
            this.ug.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ug_InitializeLayout_1);
            // 
            // grChart
            // 
            this.grChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grChart.AutoSize = true;
            this.grChart.Location = new System.Drawing.Point(12, 687);
            this.grChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grChart.Name = "grChart";
            this.grChart.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grChart.Size = new System.Drawing.Size(1132, 121);
            this.grChart.TabIndex = 15;
            this.grChart.TabStop = false;
            // 
            // frmPartnersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1156, 834);
            this.Controls.Add(this.grChart);
            this.Controls.Add(this.grSearch);
            this.Controls.Add(this.grUg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmPartnersList";
            this.ShowMainToolbar = true;
            this.Text = "Lista e Blerësve";
            this.VisibleDelete = true;
            this.VisibleExportImport = true;
            this.VisibleNew = true;
            this.VisibleOpenMenu = true;
            this.VisiblePrintMenu = true;
            this.Load += new System.EventHandler(this.frmPartnerList_Load);
            this.Controls.SetChildIndex(this.grUg, 0);
            this.Controls.SetChildIndex(this.grSearch, 0);
            this.Controls.SetChildIndex(this.grChart, 0);
            this.grSearch.ResumeLayout(false);
            this.grSearch.PerformLayout();
            this.grUg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grSearch;
        private System.Windows.Forms.TextBox txtFiscal;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblFiscal;
        private System.Windows.Forms.GroupBox grUg;
        public Infragistics.Win.UltraWinGrid.UltraGrid ug;
        private System.Windows.Forms.GroupBox grChart;
        private System.Windows.Forms.CheckBox cbSupplier;
        private System.Windows.Forms.CheckBox cbCustomer;
        private System.Windows.Forms.CheckBox cbCusSup;
    }
}