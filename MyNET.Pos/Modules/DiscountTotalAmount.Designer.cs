namespace MyNET.Pos.Modules
{
    partial class DiscountTotalAmount
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDiscountPercentage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 124);
            this.button1.MaximumSize = new System.Drawing.Size(110, 30);
            this.button1.MinimumSize = new System.Drawing.Size(110, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Vazhdo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Shkruani vleren e Zbritjes";
            // 
            // txtTotalDiscountPercentage
            // 
            this.txtTotalDiscountPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscountPercentage.Location = new System.Drawing.Point(107, 71);
            this.txtTotalDiscountPercentage.MaxLength = 10;
            this.txtTotalDiscountPercentage.Name = "txtTotalDiscountPercentage";
            this.txtTotalDiscountPercentage.Size = new System.Drawing.Size(160, 26);
            this.txtTotalDiscountPercentage.TabIndex = 3;
            this.txtTotalDiscountPercentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTotalDiscountPercentage_KeyDown);
            // 
            // DiscountTotalAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 186);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalDiscountPercentage);
            this.Name = "DiscountTotalAmount";
            this.Text = "Zbritje me vlerë";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalDiscountPercentage;
    }
}