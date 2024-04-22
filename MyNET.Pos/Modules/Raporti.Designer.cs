namespace MyNET.Pos.Modules
{
    partial class Raporti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raporti));
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.report_closing_of_the_day_fast_food = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg = new System.Windows.Forms.DataGridView();
            this.FiscalCoupNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIscalCoupAmnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBanks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalInCashbox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel2 = new System.Windows.Forms.Panel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(504, 3);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(0, 31);
            this.lblCompanyName.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(1106, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "Printo";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // report_closing_of_the_day_fast_food
            // 
            this.report_closing_of_the_day_fast_food.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.report_closing_of_the_day_fast_food.AutoSize = true;
            this.report_closing_of_the_day_fast_food.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_closing_of_the_day_fast_food.Location = new System.Drawing.Point(516, 46);
            this.report_closing_of_the_day_fast_food.Name = "report_closing_of_the_day_fast_food";
            this.report_closing_of_the_day_fast_food.Size = new System.Drawing.Size(103, 18);
            this.report_closing_of_the_day_fast_food.TabIndex = 2;
            this.report_closing_of_the_day_fast_food.Text = "Mbyllja e Ditës";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.report_closing_of_the_day_fast_food);
            this.panel1.Controls.Add(this.lblCompanyName);
            this.panel1.Controls.Add(this.dg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 941);
            this.panel1.TabIndex = 3;
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.Color.White;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FiscalCoupNr,
            this.FIscalCoupAmnt,
            this.Column1,
            this.Cash,
            this.TotalBanks,
            this.TotalSales,
            this.OpenBalance,
            this.TotalInCashbox,
            this.Column7,
            this.Column8});
            this.dg.Location = new System.Drawing.Point(64, 91);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(1048, 251);
            this.dg.TabIndex = 107;
            // 
            // FiscalCoupNr
            // 
            this.FiscalCoupNr.HeaderText = "Nr.Kuponav Fiscal";
            this.FiscalCoupNr.Name = "FiscalCoupNr";
            // 
            // FIscalCoupAmnt
            // 
            this.FIscalCoupAmnt.HeaderText = "Vlera E Kuponav Fiskal";
            this.FIscalCoupAmnt.Name = "FIscalCoupAmnt";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Vlera e Konsumit te mbrendshem";
            this.Column1.Name = "Column1";
            // 
            // Cash
            // 
            this.Cash.HeaderText = "Kesh";
            this.Cash.Name = "Cash";
            // 
            // TotalBanks
            // 
            this.TotalBanks.HeaderText = "Total Banka";
            this.TotalBanks.Name = "TotalBanks";
            // 
            // TotalSales
            // 
            this.TotalSales.HeaderText = "Total Shitje";
            this.TotalSales.Name = "TotalSales";
            // 
            // OpenBalance
            // 
            this.OpenBalance.HeaderText = "Bilanci Fillestar";
            this.OpenBalance.Name = "OpenBalance";
            // 
            // TotalInCashbox
            // 
            this.TotalInCashbox.HeaderText = "Totali ne Arke";
            this.TotalInCashbox.Name = "TotalInCashbox";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Dorezimi";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Gjendja Momentale";
            this.Column8.Name = "Column8";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1181, 23);
            this.panel2.TabIndex = 4;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Raporti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 941);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Raporti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Raporti";
            this.Load += new System.EventHandler(this.Raporti_Load);
            this.Move += new System.EventHandler(this.Raporti_Move);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label report_closing_of_the_day_fast_food;
        private System.Windows.Forms.Panel panel1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.DataGridViewTextBoxColumn FiscalCoupNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIscalCoupAmnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBanks;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalInCashbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}