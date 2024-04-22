namespace MyNET.Pos.Modules
{
    partial class DisplayInfo
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numTotal = new System.Windows.Forms.TextBox();
            this.word_cash = new System.Windows.Forms.Label();
            this.word_total_for_payment = new System.Windows.Forms.Label();
            this.word_to_return_amount = new System.Windows.Forms.Label();
            this.ucb1 = new System.Windows.Forms.ComboBox();
            this.numReturn = new System.Windows.Forms.TextBox();
            this.numPos1 = new System.Windows.Forms.TextBox();
            this.numTotalForPayment = new System.Windows.Forms.TextBox();
            this.numCash = new System.Windows.Forms.TextBox();
            this.word_amount_paid = new System.Windows.Forms.Label();
            this.pnlInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.panel1);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(461, 450);
            this.pnlInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numTotal);
            this.panel1.Controls.Add(this.word_cash);
            this.panel1.Controls.Add(this.word_total_for_payment);
            this.panel1.Controls.Add(this.word_to_return_amount);
            this.panel1.Controls.Add(this.ucb1);
            this.panel1.Controls.Add(this.numReturn);
            this.panel1.Controls.Add(this.numPos1);
            this.panel1.Controls.Add(this.numTotalForPayment);
            this.panel1.Controls.Add(this.numCash);
            this.panel1.Controls.Add(this.word_amount_paid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 450);
            this.panel1.TabIndex = 102;
            // 
            // numTotal
            // 
            this.numTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotal.Location = new System.Drawing.Point(280, 190);
            this.numTotal.Name = "numTotal";
            this.numTotal.ReadOnly = true;
            this.numTotal.Size = new System.Drawing.Size(138, 26);
            this.numTotal.TabIndex = 110;
            this.numTotal.Text = "0";
            // 
            // word_cash
            // 
            this.word_cash.AutoSize = true;
            this.word_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_cash.ForeColor = System.Drawing.Color.Black;
            this.word_cash.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_cash.Location = new System.Drawing.Point(3, 63);
            this.word_cash.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.word_cash.Name = "word_cash";
            this.word_cash.Size = new System.Drawing.Size(202, 26);
            this.word_cash.TabIndex = 58;
            this.word_cash.Text = "Të gatshme (Kesh):";
            // 
            // word_total_for_payment
            // 
            this.word_total_for_payment.AutoSize = true;
            this.word_total_for_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_total_for_payment.ForeColor = System.Drawing.Color.Black;
            this.word_total_for_payment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_total_for_payment.Location = new System.Drawing.Point(3, 5);
            this.word_total_for_payment.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.word_total_for_payment.Name = "word_total_for_payment";
            this.word_total_for_payment.Size = new System.Drawing.Size(196, 26);
            this.word_total_for_payment.TabIndex = 61;
            this.word_total_for_payment.Text = "Shuma për pagesë";
            // 
            // word_to_return_amount
            // 
            this.word_to_return_amount.AutoSize = true;
            this.word_to_return_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_to_return_amount.ForeColor = System.Drawing.Color.Black;
            this.word_to_return_amount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_to_return_amount.Location = new System.Drawing.Point(3, 240);
            this.word_to_return_amount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.word_to_return_amount.Name = "word_to_return_amount";
            this.word_to_return_amount.Size = new System.Drawing.Size(105, 26);
            this.word_to_return_amount.TabIndex = 115;
            this.word_to_return_amount.Text = "Për kthim";
            // 
            // ucb1
            // 
            this.ucb1.FormattingEnabled = true;
            this.ucb1.Location = new System.Drawing.Point(3, 121);
            this.ucb1.Name = "ucb1";
            this.ucb1.Size = new System.Drawing.Size(235, 21);
            this.ucb1.TabIndex = 102;
            this.ucb1.Visible = false;
            // 
            // numReturn
            // 
            this.numReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numReturn.Location = new System.Drawing.Point(280, 247);
            this.numReturn.Name = "numReturn";
            this.numReturn.ReadOnly = true;
            this.numReturn.Size = new System.Drawing.Size(138, 26);
            this.numReturn.TabIndex = 114;
            this.numReturn.Text = "0";
            // 
            // numPos1
            // 
            this.numPos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPos1.Location = new System.Drawing.Point(280, 121);
            this.numPos1.Name = "numPos1";
            this.numPos1.ReadOnly = true;
            this.numPos1.Size = new System.Drawing.Size(138, 26);
            this.numPos1.TabIndex = 103;
            this.numPos1.Text = "0";
            this.numPos1.Visible = false;
            // 
            // numTotalForPayment
            // 
            this.numTotalForPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalForPayment.Location = new System.Drawing.Point(280, 12);
            this.numTotalForPayment.Name = "numTotalForPayment";
            this.numTotalForPayment.ReadOnly = true;
            this.numTotalForPayment.Size = new System.Drawing.Size(138, 26);
            this.numTotalForPayment.TabIndex = 113;
            this.numTotalForPayment.Text = "0";
            // 
            // numCash
            // 
            this.numCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCash.Location = new System.Drawing.Point(280, 64);
            this.numCash.Name = "numCash";
            this.numCash.ReadOnly = true;
            this.numCash.Size = new System.Drawing.Size(138, 26);
            this.numCash.TabIndex = 112;
            this.numCash.Text = "0";
            // 
            // word_amount_paid
            // 
            this.word_amount_paid.AutoSize = true;
            this.word_amount_paid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_amount_paid.ForeColor = System.Drawing.Color.Black;
            this.word_amount_paid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_amount_paid.Location = new System.Drawing.Point(3, 183);
            this.word_amount_paid.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.word_amount_paid.Name = "word_amount_paid";
            this.word_amount_paid.Size = new System.Drawing.Size(173, 26);
            this.word_amount_paid.TabIndex = 111;
            this.word_amount_paid.Text = "Shuma e paguar";
            // 
            // DisplayInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 450);
            this.Controls.Add(this.pnlInfo);
            this.Name = "DisplayInfo";
            this.Text = "DisplayInfo";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayInfo_FormClosing);
            this.Load += new System.EventHandler(this.DisplayInfo_Load);
            this.pnlInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox numTotal;
        private System.Windows.Forms.Label word_cash;
        private System.Windows.Forms.Label word_total_for_payment;
        private System.Windows.Forms.Label word_to_return_amount;
        private System.Windows.Forms.ComboBox ucb1;
        private System.Windows.Forms.TextBox numReturn;
        public System.Windows.Forms.TextBox numPos1;
        public System.Windows.Forms.TextBox numTotalForPayment;
        private System.Windows.Forms.TextBox numCash;
        private System.Windows.Forms.Label word_amount_paid;
    }
}