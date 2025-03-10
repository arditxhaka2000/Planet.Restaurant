﻿using System;
using System.Windows.Forms;

namespace MyNET.Pos
{
    partial class CloseChashbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseChashbox));
            this.txtOpenAmount = new System.Windows.Forms.TextBox();
            this.word_complete = new System.Windows.Forms.Button();
            this.paragraph_initail_balance_sheet = new System.Windows.Forms.Label();
            this.word_cancel = new System.Windows.Forms.Button();
            this.word_total_in_cashbox = new System.Windows.Forms.Label();
            this.txtTotali = new System.Windows.Forms.TextBox();
            this.txtKesh = new System.Windows.Forms.TextBox();
            this.word_cash = new System.Windows.Forms.Label();
            this.word_total_sales = new System.Windows.Forms.Label();
            this.txtNrKuponav = new System.Windows.Forms.TextBox();
            this.txtTotaliShitje = new System.Windows.Forms.TextBox();
            this.word_nr_kuponav = new System.Windows.Forms.Label();
            this.txtBankat = new System.Windows.Forms.TextBox();
            this.word_totalpaid_wBanks = new System.Windows.Forms.Label();
            this.word_delivery = new System.Windows.Forms.Label();
            this.txtDorzimi = new System.Windows.Forms.TextBox();
            this.word_amount_left_in_cashbox = new System.Windows.Forms.Label();
            this.txtGjendjaMomentale = new System.Windows.Forms.TextBox();
            this.paragraph_print_the_report = new System.Windows.Forms.Button();
            this.closeChashboxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.paragraph_choose_small_amount_cashbox = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.closeChashboxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOpenAmount
            // 
            this.txtOpenAmount.BackColor = System.Drawing.Color.White;
            this.txtOpenAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOpenAmount.Enabled = false;
            this.txtOpenAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpenAmount.Location = new System.Drawing.Point(352, 191);
            this.txtOpenAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtOpenAmount.MaxLength = 9;
            this.txtOpenAmount.Name = "txtOpenAmount";
            this.txtOpenAmount.ReadOnly = true;
            this.txtOpenAmount.Size = new System.Drawing.Size(285, 35);
            this.txtOpenAmount.TabIndex = 68;
            this.txtOpenAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // word_complete
            // 
            this.word_complete.BackColor = System.Drawing.Color.SteelBlue;
            this.word_complete.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.word_complete.FlatAppearance.BorderSize = 0;
            this.word_complete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.word_complete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.word_complete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.word_complete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_complete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.word_complete.Location = new System.Drawing.Point(500, 543);
            this.word_complete.Margin = new System.Windows.Forms.Padding(2);
            this.word_complete.Name = "word_complete";
            this.word_complete.Size = new System.Drawing.Size(136, 47);
            this.word_complete.TabIndex = 70;
            this.word_complete.Text = "Përfundo";
            this.word_complete.UseVisualStyleBackColor = false;
            this.word_complete.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // paragraph_initail_balance_sheet
            // 
            this.paragraph_initail_balance_sheet.AutoSize = true;
            this.paragraph_initail_balance_sheet.BackColor = System.Drawing.Color.Transparent;
            this.paragraph_initail_balance_sheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paragraph_initail_balance_sheet.ForeColor = System.Drawing.Color.Black;
            this.paragraph_initail_balance_sheet.Location = new System.Drawing.Point(34, 201);
            this.paragraph_initail_balance_sheet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paragraph_initail_balance_sheet.Name = "paragraph_initail_balance_sheet";
            this.paragraph_initail_balance_sheet.Size = new System.Drawing.Size(136, 20);
            this.paragraph_initail_balance_sheet.TabIndex = 72;
            this.paragraph_initail_balance_sheet.Text = "Bilanci Fillestar:";
            // 
            // word_cancel
            // 
            this.word_cancel.BackColor = System.Drawing.Color.SteelBlue;
            this.word_cancel.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.word_cancel.FlatAppearance.BorderSize = 0;
            this.word_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.word_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.word_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.word_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_cancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.word_cancel.Location = new System.Drawing.Point(297, 543);
            this.word_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.word_cancel.Name = "word_cancel";
            this.word_cancel.Size = new System.Drawing.Size(136, 47);
            this.word_cancel.TabIndex = 74;
            this.word_cancel.Text = "Anulo";
            this.word_cancel.UseVisualStyleBackColor = false;
            this.word_cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // word_total_in_cashbox
            // 
            this.word_total_in_cashbox.AutoSize = true;
            this.word_total_in_cashbox.BackColor = System.Drawing.Color.Transparent;
            this.word_total_in_cashbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_total_in_cashbox.ForeColor = System.Drawing.Color.Black;
            this.word_total_in_cashbox.Location = new System.Drawing.Point(34, 333);
            this.word_total_in_cashbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_total_in_cashbox.Name = "word_total_in_cashbox";
            this.word_total_in_cashbox.Size = new System.Drawing.Size(120, 20);
            this.word_total_in_cashbox.TabIndex = 78;
            this.word_total_in_cashbox.Text = "Totali në Arkë";
            // 
            // txtTotali
            // 
            this.txtTotali.BackColor = System.Drawing.Color.White;
            this.txtTotali.Enabled = false;
            this.txtTotali.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotali.Location = new System.Drawing.Point(352, 323);
            this.txtTotali.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotali.MaxLength = 9;
            this.txtTotali.Name = "txtTotali";
            this.txtTotali.ReadOnly = true;
            this.txtTotali.Size = new System.Drawing.Size(285, 35);
            this.txtTotali.TabIndex = 77;
            this.txtTotali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKesh
            // 
            this.txtKesh.BackColor = System.Drawing.Color.White;
            this.txtKesh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKesh.Enabled = false;
            this.txtKesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKesh.Location = new System.Drawing.Point(352, 258);
            this.txtKesh.Margin = new System.Windows.Forms.Padding(2);
            this.txtKesh.MaxLength = 9;
            this.txtKesh.Name = "txtKesh";
            this.txtKesh.ReadOnly = true;
            this.txtKesh.Size = new System.Drawing.Size(285, 35);
            this.txtKesh.TabIndex = 79;
            this.txtKesh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // word_cash
            // 
            this.word_cash.AutoSize = true;
            this.word_cash.BackColor = System.Drawing.Color.Transparent;
            this.word_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_cash.ForeColor = System.Drawing.Color.Black;
            this.word_cash.Location = new System.Drawing.Point(34, 268);
            this.word_cash.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_cash.Name = "word_cash";
            this.word_cash.Size = new System.Drawing.Size(54, 20);
            this.word_cash.TabIndex = 80;
            this.word_cash.Text = "Kesh:";
            // 
            // word_total_sales
            // 
            this.word_total_sales.AutoSize = true;
            this.word_total_sales.BackColor = System.Drawing.Color.Transparent;
            this.word_total_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_total_sales.ForeColor = System.Drawing.Color.Black;
            this.word_total_sales.Location = new System.Drawing.Point(34, 92);
            this.word_total_sales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_total_sales.Name = "word_total_sales";
            this.word_total_sales.Size = new System.Drawing.Size(105, 20);
            this.word_total_sales.TabIndex = 81;
            this.word_total_sales.Text = "Total Shitje:";
            // 
            // txtNrKuponav
            // 
            this.txtNrKuponav.BackColor = System.Drawing.Color.White;
            this.txtNrKuponav.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNrKuponav.Enabled = false;
            this.txtNrKuponav.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNrKuponav.Location = new System.Drawing.Point(352, 18);
            this.txtNrKuponav.Margin = new System.Windows.Forms.Padding(2);
            this.txtNrKuponav.MaxLength = 9;
            this.txtNrKuponav.Name = "txtNrKuponav";
            this.txtNrKuponav.ReadOnly = true;
            this.txtNrKuponav.Size = new System.Drawing.Size(285, 35);
            this.txtNrKuponav.TabIndex = 83;
            this.txtNrKuponav.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaliShitje
            // 
            this.txtTotaliShitje.BackColor = System.Drawing.Color.White;
            this.txtTotaliShitje.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotaliShitje.Enabled = false;
            this.txtTotaliShitje.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotaliShitje.Location = new System.Drawing.Point(352, 82);
            this.txtTotaliShitje.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotaliShitje.MaxLength = 9;
            this.txtTotaliShitje.Name = "txtTotaliShitje";
            this.txtTotaliShitje.ReadOnly = true;
            this.txtTotaliShitje.Size = new System.Drawing.Size(285, 35);
            this.txtTotaliShitje.TabIndex = 84;
            this.txtTotaliShitje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // word_nr_kuponav
            // 
            this.word_nr_kuponav.AutoSize = true;
            this.word_nr_kuponav.BackColor = System.Drawing.Color.Transparent;
            this.word_nr_kuponav.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_nr_kuponav.ForeColor = System.Drawing.Color.Black;
            this.word_nr_kuponav.Location = new System.Drawing.Point(34, 28);
            this.word_nr_kuponav.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_nr_kuponav.Name = "word_nr_kuponav";
            this.word_nr_kuponav.Size = new System.Drawing.Size(167, 20);
            this.word_nr_kuponav.TabIndex = 85;
            this.word_nr_kuponav.Text = "Nr. i Kuponav Fiskal";
            // 
            // txtBankat
            // 
            this.txtBankat.BackColor = System.Drawing.Color.White;
            this.txtBankat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBankat.Enabled = false;
            this.txtBankat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankat.Location = new System.Drawing.Point(352, 136);
            this.txtBankat.Margin = new System.Windows.Forms.Padding(2);
            this.txtBankat.MaxLength = 9;
            this.txtBankat.Name = "txtBankat";
            this.txtBankat.ReadOnly = true;
            this.txtBankat.Size = new System.Drawing.Size(285, 35);
            this.txtBankat.TabIndex = 90;
            this.txtBankat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // word_totalpaid_wBanks
            // 
            this.word_totalpaid_wBanks.AutoSize = true;
            this.word_totalpaid_wBanks.BackColor = System.Drawing.Color.Transparent;
            this.word_totalpaid_wBanks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_totalpaid_wBanks.ForeColor = System.Drawing.Color.Black;
            this.word_totalpaid_wBanks.Location = new System.Drawing.Point(34, 146);
            this.word_totalpaid_wBanks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_totalpaid_wBanks.Name = "word_totalpaid_wBanks";
            this.word_totalpaid_wBanks.Size = new System.Drawing.Size(116, 20);
            this.word_totalpaid_wBanks.TabIndex = 89;
            this.word_totalpaid_wBanks.Text = "Total Bankat:";
            // 
            // word_delivery
            // 
            this.word_delivery.AutoSize = true;
            this.word_delivery.BackColor = System.Drawing.Color.Transparent;
            this.word_delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_delivery.ForeColor = System.Drawing.Color.Black;
            this.word_delivery.Location = new System.Drawing.Point(34, 392);
            this.word_delivery.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_delivery.Name = "word_delivery";
            this.word_delivery.Size = new System.Drawing.Size(79, 20);
            this.word_delivery.TabIndex = 92;
            this.word_delivery.Text = "Dorëzimi\r\n";
            // 
            // txtDorzimi
            // 
            this.txtDorzimi.BackColor = System.Drawing.Color.White;
            this.txtDorzimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDorzimi.Location = new System.Drawing.Point(352, 382);
            this.txtDorzimi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDorzimi.MaxLength = 9;
            this.txtDorzimi.Name = "txtDorzimi";
            this.txtDorzimi.Size = new System.Drawing.Size(285, 35);
            this.txtDorzimi.TabIndex = 91;
            this.txtDorzimi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDorzimi.TextChanged += new System.EventHandler(this.txtDorzimi_TextChanged);
            // 
            // word_amount_left_in_cashbox
            // 
            this.word_amount_left_in_cashbox.AutoSize = true;
            this.word_amount_left_in_cashbox.BackColor = System.Drawing.Color.Transparent;
            this.word_amount_left_in_cashbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_amount_left_in_cashbox.ForeColor = System.Drawing.Color.Black;
            this.word_amount_left_in_cashbox.Location = new System.Drawing.Point(34, 448);
            this.word_amount_left_in_cashbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_amount_left_in_cashbox.Name = "word_amount_left_in_cashbox";
            this.word_amount_left_in_cashbox.Size = new System.Drawing.Size(164, 20);
            this.word_amount_left_in_cashbox.TabIndex = 94;
            this.word_amount_left_in_cashbox.Text = "Gjendja Momentale";
            // 
            // txtGjendjaMomentale
            // 
            this.txtGjendjaMomentale.BackColor = System.Drawing.Color.White;
            this.txtGjendjaMomentale.Enabled = false;
            this.txtGjendjaMomentale.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGjendjaMomentale.Location = new System.Drawing.Point(352, 438);
            this.txtGjendjaMomentale.Margin = new System.Windows.Forms.Padding(2);
            this.txtGjendjaMomentale.MaxLength = 9;
            this.txtGjendjaMomentale.Name = "txtGjendjaMomentale";
            this.txtGjendjaMomentale.ReadOnly = true;
            this.txtGjendjaMomentale.Size = new System.Drawing.Size(285, 35);
            this.txtGjendjaMomentale.TabIndex = 93;
            this.txtGjendjaMomentale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // paragraph_print_the_report
            // 
            this.paragraph_print_the_report.BackColor = System.Drawing.Color.SteelBlue;
            this.paragraph_print_the_report.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.paragraph_print_the_report.FlatAppearance.BorderSize = 0;
            this.paragraph_print_the_report.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.paragraph_print_the_report.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.paragraph_print_the_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paragraph_print_the_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paragraph_print_the_report.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.paragraph_print_the_report.Location = new System.Drawing.Point(38, 545);
            this.paragraph_print_the_report.Margin = new System.Windows.Forms.Padding(2);
            this.paragraph_print_the_report.Name = "paragraph_print_the_report";
            this.paragraph_print_the_report.Size = new System.Drawing.Size(65, 47);
            this.paragraph_print_the_report.TabIndex = 95;
            this.paragraph_print_the_report.Text = "Shtyp Raportin";
            this.paragraph_print_the_report.UseVisualStyleBackColor = false;
            this.paragraph_print_the_report.Click += new System.EventHandler(this.btn_PrintRaport_Click);
            // 
            // closeChashboxBindingSource
            // 
            this.closeChashboxBindingSource.DataSource = typeof(MyNET.Pos.CloseChashbox);
            // 
            // paragraph_choose_small_amount_cashbox
            // 
            this.paragraph_choose_small_amount_cashbox.Location = new System.Drawing.Point(0, 0);
            this.paragraph_choose_small_amount_cashbox.Name = "paragraph_choose_small_amount_cashbox";
            this.paragraph_choose_small_amount_cashbox.Size = new System.Drawing.Size(10, 10);
            this.paragraph_choose_small_amount_cashbox.TabIndex = 96;
            this.paragraph_choose_small_amount_cashbox.Text = "Vendosni nje shume me te vogel";
            this.paragraph_choose_small_amount_cashbox.UseVisualStyleBackColor = true;
            this.paragraph_choose_small_amount_cashbox.Visible = false;
            // 
            // CloseChashbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(690, 612);
            this.Controls.Add(this.paragraph_choose_small_amount_cashbox);
            this.Controls.Add(this.paragraph_print_the_report);
            this.Controls.Add(this.word_amount_left_in_cashbox);
            this.Controls.Add(this.txtGjendjaMomentale);
            this.Controls.Add(this.word_delivery);
            this.Controls.Add(this.txtDorzimi);
            this.Controls.Add(this.txtBankat);
            this.Controls.Add(this.word_totalpaid_wBanks);
            this.Controls.Add(this.word_nr_kuponav);
            this.Controls.Add(this.txtTotaliShitje);
            this.Controls.Add(this.txtNrKuponav);
            this.Controls.Add(this.word_total_sales);
            this.Controls.Add(this.word_cash);
            this.Controls.Add(this.txtKesh);
            this.Controls.Add(this.word_total_in_cashbox);
            this.Controls.Add(this.txtTotali);
            this.Controls.Add(this.word_cancel);
            this.Controls.Add(this.paragraph_initail_balance_sheet);
            this.Controls.Add(this.word_complete);
            this.Controls.Add(this.txtOpenAmount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(589, 393);
            this.Name = "CloseChashbox";
            this.Text = "Mbyllja e arkes";
            this.Load += new System.EventHandler(this.CloseChashbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.closeChashboxBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

       

        
       

        #endregion
        private System.Windows.Forms.Button word_complete;
        private System.Windows.Forms.Label paragraph_initail_balance_sheet;
        private System.Windows.Forms.Button word_cancel;
        private System.Windows.Forms.Label word_total_in_cashbox;
        private BindingSource closeChashboxBindingSource;
        private Label word_cash;
        private Label word_total_sales;
        private Label word_nr_kuponav;
        private Label word_totalpaid_wBanks;
        public TextBox txtTotali;
        private Label word_delivery;
        public TextBox txtDorzimi;
        private Label word_amount_left_in_cashbox;
        public TextBox txtGjendjaMomentale;
        private Button paragraph_print_the_report;
        public TextBox txtOpenAmount;
        public TextBox txtKesh;
        public TextBox txtNrKuponav;
        public TextBox txtTotaliShitje;
        public TextBox txtBankat;
        private Timer timer1;
        private Button paragraph_choose_small_amount_cashbox;
    }
}