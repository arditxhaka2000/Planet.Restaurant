namespace MyNET.Pos.Modules
{
    partial class BonusCardForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.chckDiscount = new System.Windows.Forms.CheckBox();
            this.cmbBonuscard = new System.Windows.Forms.ComboBox();
            this.txt_bonusCard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bonus Kartela";
            // 
            // chckDiscount
            // 
            this.chckDiscount.AutoSize = true;
            this.chckDiscount.Location = new System.Drawing.Point(12, 172);
            this.chckDiscount.Name = "chckDiscount";
            this.chckDiscount.Size = new System.Drawing.Size(91, 17);
            this.chckDiscount.TabIndex = 2;
            this.chckDiscount.Text = "Apliko zbritjen";
            this.chckDiscount.UseVisualStyleBackColor = true;
            this.chckDiscount.Visible = false;
            this.chckDiscount.CheckedChanged += new System.EventHandler(this.chckDiscount_CheckedChanged);
            // 
            // cmbBonuscard
            // 
            this.cmbBonuscard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBonuscard.FormattingEnabled = true;
            this.cmbBonuscard.Location = new System.Drawing.Point(100, 117);
            this.cmbBonuscard.Name = "cmbBonuscard";
            this.cmbBonuscard.Size = new System.Drawing.Size(248, 32);
            this.cmbBonuscard.TabIndex = 3;
            this.cmbBonuscard.Visible = false;
            this.cmbBonuscard.SelectionChangeCommitted += new System.EventHandler(this.cmbBonuscard_SelectionChangeCommitted);
            this.cmbBonuscard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBonuscard_KeyDown);
            // 
            // txt_bonusCard
            // 
            this.txt_bonusCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bonusCard.Location = new System.Drawing.Point(100, 67);
            this.txt_bonusCard.Name = "txt_bonusCard";
            this.txt_bonusCard.Size = new System.Drawing.Size(248, 29);
            this.txt_bonusCard.TabIndex = 4;
            this.txt_bonusCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbonusCard_KeyDown);
            // 
            // BonusCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 201);
            this.Controls.Add(this.txt_bonusCard);
            this.Controls.Add(this.cmbBonuscard);
            this.Controls.Add(this.chckDiscount);
            this.Controls.Add(this.label1);
            this.Name = "BonusCardForm";
            this.Text = "BonusCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chckDiscount;
        private System.Windows.Forms.ComboBox cmbBonuscard;
        private System.Windows.Forms.TextBox txt_bonusCard;
    }
}