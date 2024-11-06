namespace MyNET.Pos.Modules
{
    partial class ItemDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgItemsDetails = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemsDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kërkoni Artikullin:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(245, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // dgItemsDetails
            // 
            this.dgItemsDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItemsDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgItemsDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgItemsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemsDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colBarcode,
            this.colQuantity,
            this.PriceCol,
            this.colDisable});
            this.dgItemsDetails.Location = new System.Drawing.Point(58, 112);
            this.dgItemsDetails.Name = "dgItemsDetails";
            this.dgItemsDetails.Size = new System.Drawing.Size(722, 448);
            this.dgItemsDetails.TabIndex = 2;
            this.dgItemsDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemsDetails_CellValueChanged);
            this.dgItemsDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgItemsDetails_CurrentCellDirtyStateChanged);
            // 
            // colName
            // 
            this.colName.HeaderText = "Emri";
            this.colName.Name = "colName";
            // 
            // colBarcode
            // 
            this.colBarcode.HeaderText = "Barkodi";
            this.colBarcode.Name = "colBarcode";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Sasia";
            this.colQuantity.Name = "colQuantity";
            // 
            // PriceCol
            // 
            this.PriceCol.HeaderText = "Çmimi";
            this.PriceCol.Name = "PriceCol";
            // 
            // colDisable
            // 
            this.colDisable.HeaderText = "Artikull Pasiv";
            this.colDisable.Name = "colDisable";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(486, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 24);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Kerko";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 641);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgItemsDetails);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemDetails";
            this.Text = "ItemDetails";
            this.Load += new System.EventHandler(this.ItemDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemsDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgItemsDetails;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDisable;
    }
}