namespace MyNET.Pos.Modules
{
    partial class PrinterConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinterConfig));
            this.word_printer_type = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.word_path = new System.Windows.Forms.Label();
            this.SyncFiscC = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.word_choose_port = new System.Windows.Forms.Label();
            this.COMcmb = new System.Windows.Forms.ComboBox();
            this.word_bitrate = new System.Windows.Forms.Label();
            this.txtBitrate = new System.Windows.Forms.TextBox();
            this.FindFiscalPrnt = new System.Windows.Forms.Button();
            this.word_print_copy = new System.Windows.Forms.Label();
            this.word_block_settings = new System.Windows.Forms.Label();
            this.chkPrintCopy = new System.Windows.Forms.CheckBox();
            this.chk_BllokoParametrat = new System.Windows.Forms.CheckBox();
            this.word_save = new System.Windows.Forms.Button();
            this.paragraph_choose_printer_type = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbFiscalPrinterType = new System.Windows.Forms.ComboBox();
            this.cmbPrinterType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDatecsType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // word_printer_type
            // 
            this.word_printer_type.AutoSize = true;
            this.word_printer_type.BackColor = System.Drawing.Color.Transparent;
            this.word_printer_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_printer_type.Location = new System.Drawing.Point(299, 116);
            this.word_printer_type.Name = "word_printer_type";
            this.word_printer_type.Size = new System.Drawing.Size(83, 16);
            this.word_printer_type.TabIndex = 0;
            this.word_printer_type.Text = "Tipi i Printerit";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(438, 205);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(157, 22);
            this.txtPath.TabIndex = 9;
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            // 
            // word_path
            // 
            this.word_path.AutoSize = true;
            this.word_path.BackColor = System.Drawing.Color.Transparent;
            this.word_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_path.Location = new System.Drawing.Point(299, 208);
            this.word_path.Name = "word_path";
            this.word_path.Size = new System.Drawing.Size(34, 16);
            this.word_path.TabIndex = 8;
            this.word_path.Text = "Path";
            // 
            // SyncFiscC
            // 
            this.SyncFiscC.BackColor = System.Drawing.Color.SteelBlue;
            this.SyncFiscC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SyncFiscC.ForeColor = System.Drawing.Color.White;
            this.SyncFiscC.Location = new System.Drawing.Point(27, 289);
            this.SyncFiscC.Name = "SyncFiscC";
            this.SyncFiscC.Size = new System.Drawing.Size(121, 36);
            this.SyncFiscC.TabIndex = 11;
            this.SyncFiscC.Text = "Sinkronizo Kuponat";
            this.SyncFiscC.UseVisualStyleBackColor = false;
            this.SyncFiscC.Click += new System.EventHandler(this.btnFindPrinter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MyNET.Pos.Properties.Resources.planet_accounting_logo_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 198);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // word_choose_port
            // 
            this.word_choose_port.AutoSize = true;
            this.word_choose_port.BackColor = System.Drawing.Color.Transparent;
            this.word_choose_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_choose_port.Location = new System.Drawing.Point(299, 254);
            this.word_choose_port.Name = "word_choose_port";
            this.word_choose_port.Size = new System.Drawing.Size(86, 16);
            this.word_choose_port.TabIndex = 13;
            this.word_choose_port.Text = "Zgjedh Portin";
            // 
            // COMcmb
            // 
            this.COMcmb.FormattingEnabled = true;
            this.COMcmb.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.COMcmb.Location = new System.Drawing.Point(438, 253);
            this.COMcmb.Name = "COMcmb";
            this.COMcmb.Size = new System.Drawing.Size(157, 21);
            this.COMcmb.TabIndex = 14;
            // 
            // word_bitrate
            // 
            this.word_bitrate.AutoSize = true;
            this.word_bitrate.BackColor = System.Drawing.Color.Transparent;
            this.word_bitrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_bitrate.Location = new System.Drawing.Point(299, 305);
            this.word_bitrate.Name = "word_bitrate";
            this.word_bitrate.Size = new System.Drawing.Size(45, 16);
            this.word_bitrate.TabIndex = 15;
            this.word_bitrate.Text = "Bitrate";
            // 
            // txtBitrate
            // 
            this.txtBitrate.Location = new System.Drawing.Point(438, 305);
            this.txtBitrate.Name = "txtBitrate";
            this.txtBitrate.Size = new System.Drawing.Size(157, 20);
            this.txtBitrate.TabIndex = 16;
            // 
            // FindFiscalPrnt
            // 
            this.FindFiscalPrnt.BackColor = System.Drawing.Color.SteelBlue;
            this.FindFiscalPrnt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FindFiscalPrnt.ForeColor = System.Drawing.Color.White;
            this.FindFiscalPrnt.Location = new System.Drawing.Point(474, 376);
            this.FindFiscalPrnt.Name = "FindFiscalPrnt";
            this.FindFiscalPrnt.Size = new System.Drawing.Size(121, 36);
            this.FindFiscalPrnt.TabIndex = 17;
            this.FindFiscalPrnt.Text = "Gjej Printerin";
            this.FindFiscalPrnt.UseVisualStyleBackColor = false;
            this.FindFiscalPrnt.Click += new System.EventHandler(this.btnFindPrinterManual_Click);
            // 
            // word_print_copy
            // 
            this.word_print_copy.AutoSize = true;
            this.word_print_copy.BackColor = System.Drawing.Color.Transparent;
            this.word_print_copy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_print_copy.Location = new System.Drawing.Point(299, 453);
            this.word_print_copy.Name = "word_print_copy";
            this.word_print_copy.Size = new System.Drawing.Size(79, 16);
            this.word_print_copy.TabIndex = 18;
            this.word_print_copy.Text = "Printo Kopje";
            // 
            // word_block_settings
            // 
            this.word_block_settings.AutoSize = true;
            this.word_block_settings.BackColor = System.Drawing.Color.Transparent;
            this.word_block_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_block_settings.Location = new System.Drawing.Point(299, 495);
            this.word_block_settings.Name = "word_block_settings";
            this.word_block_settings.Size = new System.Drawing.Size(114, 16);
            this.word_block_settings.TabIndex = 19;
            this.word_block_settings.Text = "Blloko Parametrat";
            // 
            // chkPrintCopy
            // 
            this.chkPrintCopy.AutoSize = true;
            this.chkPrintCopy.BackColor = System.Drawing.Color.Transparent;
            this.chkPrintCopy.Location = new System.Drawing.Point(580, 453);
            this.chkPrintCopy.Name = "chkPrintCopy";
            this.chkPrintCopy.Size = new System.Drawing.Size(15, 14);
            this.chkPrintCopy.TabIndex = 21;
            this.chkPrintCopy.UseVisualStyleBackColor = false;
            this.chkPrintCopy.CheckedChanged += new System.EventHandler(this.chkPrintCopy_CheckedChanged);
            // 
            // chk_BllokoParametrat
            // 
            this.chk_BllokoParametrat.AutoSize = true;
            this.chk_BllokoParametrat.BackColor = System.Drawing.Color.Transparent;
            this.chk_BllokoParametrat.Location = new System.Drawing.Point(580, 495);
            this.chk_BllokoParametrat.Name = "chk_BllokoParametrat";
            this.chk_BllokoParametrat.Size = new System.Drawing.Size(15, 14);
            this.chk_BllokoParametrat.TabIndex = 22;
            this.chk_BllokoParametrat.UseVisualStyleBackColor = false;
            this.chk_BllokoParametrat.CheckedChanged += new System.EventHandler(this.chk_BllokoParametrat_CheckedChanged);
            // 
            // word_save
            // 
            this.word_save.BackColor = System.Drawing.Color.SteelBlue;
            this.word_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_save.ForeColor = System.Drawing.Color.White;
            this.word_save.Location = new System.Drawing.Point(494, 556);
            this.word_save.Name = "word_save";
            this.word_save.Size = new System.Drawing.Size(97, 36);
            this.word_save.TabIndex = 23;
            this.word_save.Text = "Ruaj";
            this.word_save.UseVisualStyleBackColor = false;
            this.word_save.Click += new System.EventHandler(this.btn_SavePrinterSettings_Click);
            // 
            // paragraph_choose_printer_type
            // 
            this.paragraph_choose_printer_type.Location = new System.Drawing.Point(252, 23);
            this.paragraph_choose_printer_type.Name = "paragraph_choose_printer_type";
            this.paragraph_choose_printer_type.Size = new System.Drawing.Size(10, 10);
            this.paragraph_choose_printer_type.TabIndex = 24;
            this.paragraph_choose_printer_type.Text = "button1";
            this.paragraph_choose_printer_type.UseVisualStyleBackColor = true;
            this.paragraph_choose_printer_type.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(27, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 36);
            this.button1.TabIndex = 25;
            this.button1.Text = "Konfig. Printerin\r\n Termal";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbFiscalPrinterType
            // 
            this.cmbFiscalPrinterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiscalPrinterType.FormattingEnabled = true;
            this.cmbFiscalPrinterType.Items.AddRange(new object[] {
            "Datecs",
            "Tremol"});
            this.cmbFiscalPrinterType.Location = new System.Drawing.Point(438, 113);
            this.cmbFiscalPrinterType.Name = "cmbFiscalPrinterType";
            this.cmbFiscalPrinterType.Size = new System.Drawing.Size(157, 24);
            this.cmbFiscalPrinterType.TabIndex = 10;
            this.cmbFiscalPrinterType.SelectedIndexChanged += new System.EventHandler(this.cmbFiscalPrinterType_SelectedIndexChanged);
            // 
            // cmbPrinterType
            // 
            this.cmbPrinterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrinterType.FormattingEnabled = true;
            this.cmbPrinterType.Items.AddRange(new object[] {
            "Printer Fiskal",
            "Printer Termal"});
            this.cmbPrinterType.Location = new System.Drawing.Point(438, 68);
            this.cmbPrinterType.Name = "cmbPrinterType";
            this.cmbPrinterType.Size = new System.Drawing.Size(157, 24);
            this.cmbPrinterType.TabIndex = 54;
            this.cmbPrinterType.Text = "Printer Fiskal";
            this.cmbPrinterType.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Lloji i Printimit:";
            // 
            // cmbDatecsType
            // 
            this.cmbDatecsType.Enabled = false;
            this.cmbDatecsType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatecsType.FormattingEnabled = true;
            this.cmbDatecsType.Items.AddRange(new object[] {
            "FP-700",
            "FP-60"});
            this.cmbDatecsType.Location = new System.Drawing.Point(438, 159);
            this.cmbDatecsType.Name = "cmbDatecsType";
            this.cmbDatecsType.Size = new System.Drawing.Size(157, 24);
            this.cmbDatecsType.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "Lloji i Printerit";
            // 
            // PrinterConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(676, 645);
            this.Controls.Add(this.cmbDatecsType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPrinterType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.paragraph_choose_printer_type);
            this.Controls.Add(this.word_save);
            this.Controls.Add(this.chk_BllokoParametrat);
            this.Controls.Add(this.chkPrintCopy);
            this.Controls.Add(this.word_block_settings);
            this.Controls.Add(this.word_print_copy);
            this.Controls.Add(this.FindFiscalPrnt);
            this.Controls.Add(this.txtBitrate);
            this.Controls.Add(this.word_bitrate);
            this.Controls.Add(this.COMcmb);
            this.Controls.Add(this.word_choose_port);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SyncFiscC);
            this.Controls.Add(this.cmbFiscalPrinterType);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.word_path);
            this.Controls.Add(this.word_printer_type);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(692, 489);
            this.Name = "PrinterConfig";
            this.Text = "PrinterConfig";
            this.Load += new System.EventHandler(this.PrinterConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label word_printer_type;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label word_path;
        private System.Windows.Forms.Button SyncFiscC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label word_choose_port;
        private System.Windows.Forms.ComboBox COMcmb;
        private System.Windows.Forms.Label word_bitrate;
        private System.Windows.Forms.TextBox txtBitrate;
        private System.Windows.Forms.Button FindFiscalPrnt;
        private System.Windows.Forms.Label word_print_copy;
        private System.Windows.Forms.Label word_block_settings;
        private System.Windows.Forms.CheckBox chkPrintCopy;
        private System.Windows.Forms.CheckBox chk_BllokoParametrat;
        private System.Windows.Forms.Button word_save;
        private System.Windows.Forms.Button paragraph_choose_printer_type;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbFiscalPrinterType;
        private System.Windows.Forms.ComboBox cmbPrinterType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDatecsType;
        private System.Windows.Forms.Label label2;
    }
}