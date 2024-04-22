namespace MyNET.Pos
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.word_company_data = new System.Windows.Forms.GroupBox();
            this.txtFiscalNumber = new System.Windows.Forms.TextBox();
            this.word_no_fiscal = new System.Windows.Forms.Label();
            this.txtVatNumber = new System.Windows.Forms.TextBox();
            this.word_no_vat = new System.Windows.Forms.Label();
            this.word_company_name = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtBusinessNumber = new System.Windows.Forms.TextBox();
            this.paragraph_unique_business_number = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.word_choose = new System.Windows.Forms.Button();
            this.word_choose_fav_items = new System.Windows.Forms.Label();
            this.word_country = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.word_city = new System.Windows.Forms.Label();
            this.word_address = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.word_others = new System.Windows.Forms.GroupBox();
            this.word_config_fiscal_printer = new System.Windows.Forms.Button();
            this.word_save = new System.Windows.Forms.Button();
            this.word_languages = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.checkboxDisc = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.word_company_data.SuspendLayout();
            this.word_others.SuspendLayout();
            this.SuspendLayout();
            // 
            // word_company_data
            // 
            this.word_company_data.BackColor = System.Drawing.Color.Transparent;
            this.word_company_data.Controls.Add(this.txtFiscalNumber);
            this.word_company_data.Controls.Add(this.word_no_fiscal);
            this.word_company_data.Controls.Add(this.txtVatNumber);
            this.word_company_data.Controls.Add(this.word_no_vat);
            this.word_company_data.Controls.Add(this.word_company_name);
            this.word_company_data.Controls.Add(this.txtCompanyName);
            this.word_company_data.Controls.Add(this.txtBusinessNumber);
            this.word_company_data.Controls.Add(this.paragraph_unique_business_number);
            this.word_company_data.Location = new System.Drawing.Point(9, 21);
            this.word_company_data.Margin = new System.Windows.Forms.Padding(2);
            this.word_company_data.Name = "word_company_data";
            this.word_company_data.Padding = new System.Windows.Forms.Padding(2);
            this.word_company_data.Size = new System.Drawing.Size(388, 277);
            this.word_company_data.TabIndex = 4;
            this.word_company_data.TabStop = false;
            this.word_company_data.Text = "Të dhënat e kompanisë";
            // 
            // txtFiscalNumber
            // 
            this.txtFiscalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiscalNumber.Location = new System.Drawing.Point(116, 103);
            this.txtFiscalNumber.Name = "txtFiscalNumber";
            this.txtFiscalNumber.ReadOnly = true;
            this.txtFiscalNumber.Size = new System.Drawing.Size(231, 23);
            this.txtFiscalNumber.TabIndex = 40;
            // 
            // word_no_fiscal
            // 
            this.word_no_fiscal.AutoSize = true;
            this.word_no_fiscal.BackColor = System.Drawing.Color.Transparent;
            this.word_no_fiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_no_fiscal.Location = new System.Drawing.Point(4, 103);
            this.word_no_fiscal.Name = "word_no_fiscal";
            this.word_no_fiscal.Size = new System.Drawing.Size(61, 15);
            this.word_no_fiscal.TabIndex = 41;
            this.word_no_fiscal.Text = "Nr. Fiskal:";
            // 
            // txtVatNumber
            // 
            this.txtVatNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatNumber.Location = new System.Drawing.Point(116, 144);
            this.txtVatNumber.Name = "txtVatNumber";
            this.txtVatNumber.ReadOnly = true;
            this.txtVatNumber.Size = new System.Drawing.Size(231, 23);
            this.txtVatNumber.TabIndex = 38;
            // 
            // word_no_vat
            // 
            this.word_no_vat.AutoSize = true;
            this.word_no_vat.BackColor = System.Drawing.Color.Transparent;
            this.word_no_vat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_no_vat.Location = new System.Drawing.Point(4, 144);
            this.word_no_vat.Name = "word_no_vat";
            this.word_no_vat.Size = new System.Drawing.Size(60, 15);
            this.word_no_vat.TabIndex = 39;
            this.word_no_vat.Text = "Nr. TVSH:";
            // 
            // word_company_name
            // 
            this.word_company_name.AutoSize = true;
            this.word_company_name.BackColor = System.Drawing.Color.Transparent;
            this.word_company_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_company_name.Location = new System.Drawing.Point(4, 35);
            this.word_company_name.Name = "word_company_name";
            this.word_company_name.Size = new System.Drawing.Size(106, 15);
            this.word_company_name.TabIndex = 27;
            this.word_company_name.Text = "Emri i kompanisë:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(116, 32);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(231, 23);
            this.txtCompanyName.TabIndex = 26;
            // 
            // txtBusinessNumber
            // 
            this.txtBusinessNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusinessNumber.Location = new System.Drawing.Point(116, 68);
            this.txtBusinessNumber.Name = "txtBusinessNumber";
            this.txtBusinessNumber.ReadOnly = true;
            this.txtBusinessNumber.Size = new System.Drawing.Size(231, 23);
            this.txtBusinessNumber.TabIndex = 28;
            // 
            // paragraph_unique_business_number
            // 
            this.paragraph_unique_business_number.AutoSize = true;
            this.paragraph_unique_business_number.BackColor = System.Drawing.Color.Transparent;
            this.paragraph_unique_business_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paragraph_unique_business_number.Location = new System.Drawing.Point(4, 68);
            this.paragraph_unique_business_number.Name = "paragraph_unique_business_number";
            this.paragraph_unique_business_number.Size = new System.Drawing.Size(36, 15);
            this.paragraph_unique_business_number.TabIndex = 30;
            this.paragraph_unique_business_number.Text = "NRB:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 381);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 17);
            this.checkBox1.TabIndex = 107;
            this.checkBox1.Text = "Shfaq Butonin \"Pagesë Direkte\"";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // word_choose
            // 
            this.word_choose.BackColor = System.Drawing.Color.SteelBlue;
            this.word_choose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_choose.ForeColor = System.Drawing.Color.White;
            this.word_choose.Location = new System.Drawing.Point(10, 471);
            this.word_choose.Name = "word_choose";
            this.word_choose.Size = new System.Drawing.Size(107, 23);
            this.word_choose.TabIndex = 107;
            this.word_choose.Text = "Zgjedh";
            this.word_choose.UseVisualStyleBackColor = false;
            this.word_choose.Click += new System.EventHandler(this.ZgjedhFavorite_Click);
            // 
            // word_choose_fav_items
            // 
            this.word_choose_fav_items.AutoSize = true;
            this.word_choose_fav_items.BackColor = System.Drawing.Color.Transparent;
            this.word_choose_fav_items.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_choose_fav_items.Location = new System.Drawing.Point(6, 433);
            this.word_choose_fav_items.Name = "word_choose_fav_items";
            this.word_choose_fav_items.Size = new System.Drawing.Size(174, 16);
            this.word_choose_fav_items.TabIndex = 105;
            this.word_choose_fav_items.Text = "Zgjedhni Produktet Favorite:";
            // 
            // word_country
            // 
            this.word_country.AutoSize = true;
            this.word_country.BackColor = System.Drawing.Color.Transparent;
            this.word_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_country.Location = new System.Drawing.Point(32, 146);
            this.word_country.Name = "word_country";
            this.word_country.Size = new System.Drawing.Size(41, 15);
            this.word_country.TabIndex = 37;
            this.word_country.Text = "Vendi:";
            // 
            // txtCountry
            // 
            this.txtCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountry.Location = new System.Drawing.Point(145, 146);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.ReadOnly = true;
            this.txtCountry.Size = new System.Drawing.Size(210, 23);
            this.txtCountry.TabIndex = 36;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(145, 35);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(210, 23);
            this.txtPhoneNumber.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Tel:";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(145, 110);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(210, 23);
            this.txtCity.TabIndex = 32;
            // 
            // word_city
            // 
            this.word_city.AutoSize = true;
            this.word_city.BackColor = System.Drawing.Color.Transparent;
            this.word_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_city.Location = new System.Drawing.Point(32, 110);
            this.word_city.Name = "word_city";
            this.word_city.Size = new System.Drawing.Size(40, 15);
            this.word_city.TabIndex = 33;
            this.word_city.Text = "Qyteti:";
            // 
            // word_address
            // 
            this.word_address.AutoSize = true;
            this.word_address.BackColor = System.Drawing.Color.Transparent;
            this.word_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_address.Location = new System.Drawing.Point(32, 74);
            this.word_address.Name = "word_address";
            this.word_address.Size = new System.Drawing.Size(48, 15);
            this.word_address.TabIndex = 35;
            this.word_address.Text = "Adresa:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(145, 74);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(210, 23);
            this.txtAddress.TabIndex = 34;
            // 
            // word_others
            // 
            this.word_others.BackColor = System.Drawing.Color.Transparent;
            this.word_others.Controls.Add(this.label3);
            this.word_others.Controls.Add(this.txtAddress);
            this.word_others.Controls.Add(this.word_address);
            this.word_others.Controls.Add(this.word_city);
            this.word_others.Controls.Add(this.txtCity);
            this.word_others.Controls.Add(this.word_country);
            this.word_others.Controls.Add(this.txtPhoneNumber);
            this.word_others.Controls.Add(this.txtCountry);
            this.word_others.Location = new System.Drawing.Point(418, 21);
            this.word_others.Margin = new System.Windows.Forms.Padding(2);
            this.word_others.Name = "word_others";
            this.word_others.Padding = new System.Windows.Forms.Padding(2);
            this.word_others.Size = new System.Drawing.Size(399, 277);
            this.word_others.TabIndex = 5;
            this.word_others.TabStop = false;
            this.word_others.Text = "Tjera";
            // 
            // word_config_fiscal_printer
            // 
            this.word_config_fiscal_printer.BackColor = System.Drawing.Color.SteelBlue;
            this.word_config_fiscal_printer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_config_fiscal_printer.ForeColor = System.Drawing.Color.White;
            this.word_config_fiscal_printer.Location = new System.Drawing.Point(9, 514);
            this.word_config_fiscal_printer.Name = "word_config_fiscal_printer";
            this.word_config_fiscal_printer.Size = new System.Drawing.Size(107, 23);
            this.word_config_fiscal_printer.TabIndex = 39;
            this.word_config_fiscal_printer.Text = "Konfiguro Printerin";
            this.word_config_fiscal_printer.UseVisualStyleBackColor = false;
            this.word_config_fiscal_printer.Click += new System.EventHandler(this.btn_printerConfig_Click);
            // 
            // word_save
            // 
            this.word_save.BackColor = System.Drawing.Color.SteelBlue;
            this.word_save.FlatAppearance.BorderSize = 0;
            this.word_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_save.ForeColor = System.Drawing.Color.White;
            this.word_save.Location = new System.Drawing.Point(692, 718);
            this.word_save.Margin = new System.Windows.Forms.Padding(2);
            this.word_save.Name = "word_save";
            this.word_save.Size = new System.Drawing.Size(125, 34);
            this.word_save.TabIndex = 104;
            this.word_save.Text = "Ruaj";
            this.word_save.UseVisualStyleBackColor = false;
            this.word_save.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // word_languages
            // 
            this.word_languages.AutoSize = true;
            this.word_languages.BackColor = System.Drawing.Color.Transparent;
            this.word_languages.Location = new System.Drawing.Point(6, 317);
            this.word_languages.Name = "word_languages";
            this.word_languages.Size = new System.Drawing.Size(77, 13);
            this.word_languages.TabIndex = 106;
            this.word_languages.Text = "Zgjedh Gjuhen";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "Shqip",
            "English"});
            this.cmbLanguage.Location = new System.Drawing.Point(107, 314);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 105;
            // 
            // checkboxDisc
            // 
            this.checkboxDisc.AutoSize = true;
            this.checkboxDisc.Location = new System.Drawing.Point(9, 358);
            this.checkboxDisc.Name = "checkboxDisc";
            this.checkboxDisc.Size = new System.Drawing.Size(185, 17);
            this.checkboxDisc.TabIndex = 108;
            this.checkboxDisc.Text = "Mos Shfaq Kolonën e Zbritjes (%) ";
            this.checkboxDisc.UseVisualStyleBackColor = true;
            this.checkboxDisc.CheckedChanged += new System.EventHandler(this.checkboxDisc_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(9, 404);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 17);
            this.checkBox2.TabIndex = 109;
            this.checkBox2.Text = "Barcode Mode";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 763);
            this.Controls.Add(this.word_config_fiscal_printer);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkboxDisc);
            this.Controls.Add(this.word_choose);
            this.Controls.Add(this.word_choose_fav_items);
            this.Controls.Add(this.word_languages);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.word_save);
            this.Controls.Add(this.word_company_data);
            this.Controls.Add(this.word_others);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(847, 392);
            this.Name = "frmSettings";
            this.Text = "Konfigurimet";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.word_company_data.ResumeLayout(false);
            this.word_company_data.PerformLayout();
            this.word_others.ResumeLayout(false);
            this.word_others.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox word_company_data;
        private System.Windows.Forms.TextBox txtFiscalNumber;
        private System.Windows.Forms.Label word_no_fiscal;
        private System.Windows.Forms.TextBox txtVatNumber;
        private System.Windows.Forms.Label word_no_vat;
        private System.Windows.Forms.Label word_company_name;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtBusinessNumber;
        private System.Windows.Forms.Label word_country;
        private System.Windows.Forms.Label paragraph_unique_business_number;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label word_city;
        private System.Windows.Forms.Label word_address;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox word_others;
        private System.Windows.Forms.Button word_save;
        private System.Windows.Forms.Label word_choose_fav_items;
        private System.Windows.Forms.Button word_choose;
        private System.Windows.Forms.Button word_config_fiscal_printer;
        private System.Windows.Forms.Label word_languages;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkboxDisc;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}