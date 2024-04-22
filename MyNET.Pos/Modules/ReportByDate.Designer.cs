namespace MyNET.Pos.Modules
{
    partial class ReportByDate
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
            this.word_to = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotal = new System.Windows.Forms.Label();
            this.word_total_sales = new System.Windows.Forms.Label();
            this.dFDate = new System.Windows.Forms.DateTimePicker();
            this.word_from = new System.Windows.Forms.Label();
            this.word_show = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // word_to
            // 
            this.word_to.AutoSize = true;
            this.word_to.BackColor = System.Drawing.Color.Transparent;
            this.word_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_to.ForeColor = System.Drawing.Color.Black;
            this.word_to.Location = new System.Drawing.Point(409, 30);
            this.word_to.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_to.Name = "word_to";
            this.word_to.Size = new System.Drawing.Size(42, 20);
            this.word_to.TabIndex = 87;
            this.word_to.Text = "Deri";
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(413, 88);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(191, 26);
            this.dtDate.TabIndex = 86;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(623, 408);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(79, 20);
            this.lblTotal.TabIndex = 84;
            this.lblTotal.Text = "__ __ __";
            // 
            // word_total_sales
            // 
            this.word_total_sales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.word_total_sales.AutoSize = true;
            this.word_total_sales.BackColor = System.Drawing.Color.Transparent;
            this.word_total_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_total_sales.ForeColor = System.Drawing.Color.Black;
            this.word_total_sales.Location = new System.Drawing.Point(460, 408);
            this.word_total_sales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_total_sales.Name = "word_total_sales";
            this.word_total_sales.Size = new System.Drawing.Size(133, 20);
            this.word_total_sales.TabIndex = 83;
            this.word_total_sales.Text = "Totali i shitjeve:";
            // 
            // dFDate
            // 
            this.dFDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dFDate.Location = new System.Drawing.Point(86, 88);
            this.dFDate.Margin = new System.Windows.Forms.Padding(2);
            this.dFDate.Name = "dFDate";
            this.dFDate.Size = new System.Drawing.Size(187, 26);
            this.dFDate.TabIndex = 82;
            // 
            // word_from
            // 
            this.word_from.AutoSize = true;
            this.word_from.BackColor = System.Drawing.Color.Transparent;
            this.word_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_from.ForeColor = System.Drawing.Color.Black;
            this.word_from.Location = new System.Drawing.Point(82, 30);
            this.word_from.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_from.Name = "word_from";
            this.word_from.Size = new System.Drawing.Size(40, 20);
            this.word_from.TabIndex = 81;
            this.word_from.Text = "Prej";
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
            this.word_show.Location = new System.Drawing.Point(663, 149);
            this.word_show.Margin = new System.Windows.Forms.Padding(2);
            this.word_show.Name = "word_show";
            this.word_show.Size = new System.Drawing.Size(110, 34);
            this.word_show.TabIndex = 80;
            this.word_show.Text = "Shfaq";
            this.word_show.UseVisualStyleBackColor = false;
            this.word_show.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(86, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(518, 210);
            this.dataGridView1.TabIndex = 88;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nr.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 50;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_print.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_print.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_print.Location = new System.Drawing.Point(1, 424);
            this.btn_print.Margin = new System.Windows.Forms.Padding(2);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(53, 25);
            this.btn_print.TabIndex = 89;
            this.btn_print.Text = "Printo";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // ReportByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyNET.Pos.Properties.Resources.backgroundfull;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.word_to);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.word_total_sales);
            this.Controls.Add(this.dFDate);
            this.Controls.Add(this.word_from);
            this.Controls.Add(this.word_show);
            this.Name = "ReportByDate";
            this.Text = "ReportByDate";
            this.Load += new System.EventHandler(this.ReportByDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label word_to;
        private System.Windows.Forms.DateTimePicker dtDate;
        public System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label word_total_sales;
        private System.Windows.Forms.DateTimePicker dFDate;
        private System.Windows.Forms.Label word_from;
        private System.Windows.Forms.Button word_show;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btn_print;
    }
}