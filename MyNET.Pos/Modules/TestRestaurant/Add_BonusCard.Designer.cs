namespace MyNET.Pos.Modules
{
    partial class Add_BonusCard
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_BonusCardType = new System.Windows.Forms.ComboBox();
            this.txt_bonusCPoints = new System.Windows.Forms.TextBox();
            this.btn_saveBonusCard = new System.Windows.Forms.Button();
            this.txt_bonusCDiscount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_pointValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PetrolDiscount = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.14441F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.85559F));
            this.tableLayoutPanel1.Controls.Add(this.txt_PetrolDiscount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmb_BonusCardType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_bonusCPoints, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_bonusCDiscount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_pointValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_saveBonusCard, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(43, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(638, 279);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vlera e pikeve per 1 euro :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipi i karteles :";
            // 
            // cmb_BonusCardType
            // 
            this.cmb_BonusCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_BonusCardType.FormattingEnabled = true;
            this.cmb_BonusCardType.Items.AddRange(new object[] {
            "Pikë",
            "Zbritje",
            "Derivate"});
            this.cmb_BonusCardType.Location = new System.Drawing.Point(265, 3);
            this.cmb_BonusCardType.Name = "cmb_BonusCardType";
            this.cmb_BonusCardType.Size = new System.Drawing.Size(246, 28);
            this.cmb_BonusCardType.TabIndex = 3;
            this.cmb_BonusCardType.SelectedIndexChanged += new System.EventHandler(this.cmb_BonusCardType_SelectedIndexChanged);
            // 
            // txt_bonusCPoints
            // 
            this.txt_bonusCPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bonusCPoints.Location = new System.Drawing.Point(265, 54);
            this.txt_bonusCPoints.Name = "txt_bonusCPoints";
            this.txt_bonusCPoints.Size = new System.Drawing.Size(246, 29);
            this.txt_bonusCPoints.TabIndex = 7;
            // 
            // btn_saveBonusCard
            // 
            this.btn_saveBonusCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_saveBonusCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveBonusCard.Location = new System.Drawing.Point(265, 231);
            this.btn_saveBonusCard.Name = "btn_saveBonusCard";
            this.btn_saveBonusCard.Size = new System.Drawing.Size(370, 45);
            this.btn_saveBonusCard.TabIndex = 5;
            this.btn_saveBonusCard.Text = "Ruaj ";
            this.btn_saveBonusCard.UseVisualStyleBackColor = true;
            this.btn_saveBonusCard.Click += new System.EventHandler(this.btn_saveBonusCard_Click);
            // 
            // txt_bonusCDiscount
            // 
            this.txt_bonusCDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bonusCDiscount.Location = new System.Drawing.Point(265, 154);
            this.txt_bonusCDiscount.Name = "txt_bonusCDiscount";
            this.txt_bonusCDiscount.Size = new System.Drawing.Size(246, 29);
            this.txt_bonusCDiscount.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "Vlera e zbritjes (në %) :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 54);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vlera e nje pike :";
            // 
            // txt_pointValue
            // 
            this.txt_pointValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pointValue.Location = new System.Drawing.Point(265, 100);
            this.txt_pointValue.Name = "txt_pointValue";
            this.txt_pointValue.Size = new System.Drawing.Size(246, 29);
            this.txt_pointValue.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 39);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vlera e zbritjes (në Euro) :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txt_PetrolDiscount
            // 
            this.txt_PetrolDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PetrolDiscount.Location = new System.Drawing.Point(265, 192);
            this.txt_PetrolDiscount.Name = "txt_PetrolDiscount";
            this.txt_PetrolDiscount.Size = new System.Drawing.Size(246, 29);
            this.txt_PetrolDiscount.TabIndex = 13;
            // 
            // Add_BonusCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Add_BonusCard";
            this.Text = "Add_BonusCard";
            this.Load += new System.EventHandler(this.Add_BonusCard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_BonusCardType;
        private System.Windows.Forms.Button btn_saveBonusCard;
        private System.Windows.Forms.TextBox txt_bonusCDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_bonusCPoints;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_pointValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PetrolDiscount;
    }
}