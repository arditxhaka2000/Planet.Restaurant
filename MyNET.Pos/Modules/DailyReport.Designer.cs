namespace MyNET.Pos.Modules
{
    partial class DailyReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyReport));
            this.word_show = new System.Windows.Forms.Button();
            this.word_date = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.dg = new System.Windows.Forms.DataGridView();
            this.word_total_sales = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // word_show
            // 
            this.word_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.word_show.BackColor = System.Drawing.Color.SteelBlue;
            this.word_show.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.word_show.FlatAppearance.BorderSize = 0;
            this.word_show.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.word_show.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.word_show.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_show.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_show.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.word_show.Location = new System.Drawing.Point(425, 33);
            this.word_show.Margin = new System.Windows.Forms.Padding(2);
            this.word_show.Name = "word_show";
            this.word_show.Size = new System.Drawing.Size(110, 34);
            this.word_show.TabIndex = 71;
            this.word_show.Text = "Shfaq";
            this.word_show.UseVisualStyleBackColor = false;
            this.word_show.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // word_date
            // 
            this.word_date.AutoSize = true;
            this.word_date.BackColor = System.Drawing.Color.Transparent;
            this.word_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_date.ForeColor = System.Drawing.Color.Black;
            this.word_date.Location = new System.Drawing.Point(27, 7);
            this.word_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_date.Name = "word_date";
            this.word_date.Size = new System.Drawing.Size(53, 20);
            this.word_date.TabIndex = 72;
            this.word_date.Text = "Data:";
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(31, 37);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(191, 26);
            this.dtDate.TabIndex = 73;
            // 
            // dg
            // 
            this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg.BackgroundColor = System.Drawing.Color.White;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(31, 85);
            this.dg.Margin = new System.Windows.Forms.Padding(2);
            this.dg.Name = "dg";
            this.dg.RowHeadersWidth = 51;
            this.dg.RowTemplate.Height = 24;
            this.dg.Size = new System.Drawing.Size(507, 225);
            this.dg.TabIndex = 74;
            // 
            // word_total_sales
            // 
            this.word_total_sales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.word_total_sales.AutoSize = true;
            this.word_total_sales.BackColor = System.Drawing.Color.Transparent;
            this.word_total_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_total_sales.ForeColor = System.Drawing.Color.Black;
            this.word_total_sales.Location = new System.Drawing.Point(307, 333);
            this.word_total_sales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_total_sales.Name = "word_total_sales";
            this.word_total_sales.Size = new System.Drawing.Size(133, 20);
            this.word_total_sales.TabIndex = 75;
            this.word_total_sales.Text = "Totali i shitjeve:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(463, 333);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(79, 20);
            this.lblTotal.TabIndex = 76;
            this.lblTotal.Text = "__ __ __";
            // 
            // DailyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(605, 393);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.word_total_sales);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.word_date);
            this.Controls.Add(this.word_show);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(621, 432);
            this.MinimumSize = new System.Drawing.Size(621, 432);
            this.Name = "DailyReport";
            this.Text = "Raporti Ditor";
            this.Load += new System.EventHandler(this.DailyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button word_show;
        private System.Windows.Forms.Label word_date;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Label word_total_sales;
        public System.Windows.Forms.Label lblTotal;
    }
}