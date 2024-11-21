namespace MyNET.Pos.Modules
{
    partial class Manage_Tables
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
            this.dg_openTables = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCloseTable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOpenTable = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_openTables)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_openTables
            // 
            this.dg_openTables.AllowUserToAddRows = false;
            this.dg_openTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_openTables.BackgroundColor = System.Drawing.Color.White;
            this.dg_openTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_openTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colWorkerName,
            this.colTotal,
            this.colTimer,
            this.colCloseTable,
            this.colOpenTable});
            this.dg_openTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_openTables.Location = new System.Drawing.Point(0, 0);
            this.dg_openTables.Name = "dg_openTables";
            this.dg_openTables.ReadOnly = true;
            this.dg_openTables.Size = new System.Drawing.Size(800, 450);
            this.dg_openTables.TabIndex = 0;
            this.dg_openTables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_openTables_CellContentClick);
            this.dg_openTables.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Emri i Tavolines";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colWorkerName
            // 
            this.colWorkerName.HeaderText = "Puntori";
            this.colWorkerName.Name = "colWorkerName";
            this.colWorkerName.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Shuma";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colTimer
            // 
            this.colTimer.HeaderText = "Koha";
            this.colTimer.Name = "colTimer";
            this.colTimer.ReadOnly = true;
            // 
            // colCloseTable
            // 
            this.colCloseTable.HeaderText = "Mbyll Tavolinen";
            this.colCloseTable.Name = "colCloseTable";
            this.colCloseTable.ReadOnly = true;
            // 
            // colOpenTable
            // 
            this.colOpenTable.HeaderText = "Hape Tavolinen";
            this.colOpenTable.Name = "colOpenTable";
            this.colOpenTable.ReadOnly = true;
            // 
            // Manage_Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dg_openTables);
            this.Name = "Manage_Tables";
            this.Text = "Manage_Tables";
            this.Load += new System.EventHandler(this.Manage_Tables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_openTables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_openTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimer;
        private System.Windows.Forms.DataGridViewButtonColumn colCloseTable;
        private System.Windows.Forms.DataGridViewButtonColumn colOpenTable;
    }
}