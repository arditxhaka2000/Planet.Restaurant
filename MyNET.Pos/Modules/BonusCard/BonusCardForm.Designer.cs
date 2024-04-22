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
            this.txt_bonuscard = new System.Windows.Forms.TextBox();
            this.chckDiscount = new System.Windows.Forms.CheckBox();
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
            // txt_bonuscard
            // 
            this.txt_bonuscard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bonuscard.Location = new System.Drawing.Point(95, 72);
            this.txt_bonuscard.Name = "txt_bonuscard";
            this.txt_bonuscard.Size = new System.Drawing.Size(263, 31);
            this.txt_bonuscard.TabIndex = 1;
            this.txt_bonuscard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbonusCard_KeyDown);
            // 
            // chckDiscount
            // 
            this.chckDiscount.AutoSize = true;
            this.chckDiscount.Location = new System.Drawing.Point(12, 142);
            this.chckDiscount.Name = "chckDiscount";
            this.chckDiscount.Size = new System.Drawing.Size(91, 17);
            this.chckDiscount.TabIndex = 2;
            this.chckDiscount.Text = "Apliko zbritjen";
            this.chckDiscount.UseVisualStyleBackColor = true;
            this.chckDiscount.CheckedChanged += new System.EventHandler(this.chckDiscount_CheckedChanged);
            this.chckDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chckDiscount_KeyDown);
            // 
            // BonusCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 171);
            this.Controls.Add(this.chckDiscount);
            this.Controls.Add(this.txt_bonuscard);
            this.Controls.Add(this.label1);
            this.Name = "BonusCardForm";
            this.Text = "BonusCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bonuscard;
        private System.Windows.Forms.CheckBox chckDiscount;
    }
}