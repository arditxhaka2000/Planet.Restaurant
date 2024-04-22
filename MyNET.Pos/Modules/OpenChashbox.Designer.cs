namespace MyNET.Pos
{
    partial class OpenChashbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenChashbox));
            this.word_time = new System.Windows.Forms.Label();
            this.txtOpenAmount = new System.Windows.Forms.TextBox();
            this.word_start = new System.Windows.Forms.Button();
            this.paragraph_initail_balance_sheet = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.word_cancel = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.word_user = new System.Windows.Forms.Label();
            this.paragraph_put_valid_value = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // word_time
            // 
            this.word_time.AutoSize = true;
            this.word_time.BackColor = System.Drawing.Color.Transparent;
            this.word_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_time.ForeColor = System.Drawing.Color.Black;
            this.word_time.Location = new System.Drawing.Point(34, 90);
            this.word_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_time.Name = "word_time";
            this.word_time.Size = new System.Drawing.Size(43, 20);
            this.word_time.TabIndex = 69;
            this.word_time.Text = "Ora:";
            // 
            // txtOpenAmount
            // 
            this.txtOpenAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpenAmount.Location = new System.Drawing.Point(220, 135);
            this.txtOpenAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtOpenAmount.Name = "txtOpenAmount";
            this.txtOpenAmount.Size = new System.Drawing.Size(285, 35);
            this.txtOpenAmount.TabIndex = 68;
            this.txtOpenAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOpenAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOpenAmount_KeyDown);
            // 
            // word_start
            // 
            this.word_start.BackColor = System.Drawing.Color.SteelBlue;
            this.word_start.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.word_start.FlatAppearance.BorderSize = 0;
            this.word_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.word_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.word_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_start.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.word_start.Location = new System.Drawing.Point(368, 240);
            this.word_start.Margin = new System.Windows.Forms.Padding(2);
            this.word_start.Name = "word_start";
            this.word_start.Size = new System.Drawing.Size(136, 47);
            this.word_start.TabIndex = 70;
            this.word_start.Text = "Fillo";
            this.word_start.UseVisualStyleBackColor = false;
            this.word_start.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // paragraph_initail_balance_sheet
            // 
            this.paragraph_initail_balance_sheet.AutoSize = true;
            this.paragraph_initail_balance_sheet.BackColor = System.Drawing.Color.Transparent;
            this.paragraph_initail_balance_sheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paragraph_initail_balance_sheet.ForeColor = System.Drawing.Color.Black;
            this.paragraph_initail_balance_sheet.Location = new System.Drawing.Point(34, 145);
            this.paragraph_initail_balance_sheet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paragraph_initail_balance_sheet.Name = "paragraph_initail_balance_sheet";
            this.paragraph_initail_balance_sheet.Size = new System.Drawing.Size(136, 20);
            this.paragraph_initail_balance_sheet.TabIndex = 72;
            this.paragraph_initail_balance_sheet.Text = "Bilanci Fillestar:";
            // 
            // txtDateTime
            // 
            this.txtDateTime.BackColor = System.Drawing.Color.White;
            this.txtDateTime.Enabled = false;
            this.txtDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTime.Location = new System.Drawing.Point(220, 80);
            this.txtDateTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(285, 35);
            this.txtDateTime.TabIndex = 73;
            // 
            // word_cancel
            // 
            this.word_cancel.BackColor = System.Drawing.Color.SteelBlue;
            this.word_cancel.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.word_cancel.FlatAppearance.BorderSize = 0;
            this.word_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.word_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.word_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_cancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.word_cancel.Location = new System.Drawing.Point(220, 240);
            this.word_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.word_cancel.Name = "word_cancel";
            this.word_cancel.Size = new System.Drawing.Size(136, 47);
            this.word_cancel.TabIndex = 74;
            this.word_cancel.Text = "Anulo";
            this.word_cancel.UseVisualStyleBackColor = false;
            this.word_cancel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Enabled = false;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(220, 26);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(285, 35);
            this.txtUser.TabIndex = 76;
            // 
            // word_user
            // 
            this.word_user.AutoSize = true;
            this.word_user.BackColor = System.Drawing.Color.Transparent;
            this.word_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_user.ForeColor = System.Drawing.Color.Black;
            this.word_user.Location = new System.Drawing.Point(34, 26);
            this.word_user.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.word_user.Name = "word_user";
            this.word_user.Size = new System.Drawing.Size(114, 20);
            this.word_user.TabIndex = 75;
            this.word_user.Text = "Shfrytëzuesi:";
            // 
            // paragraph_put_valid_value
            // 
            this.paragraph_put_valid_value.Location = new System.Drawing.Point(12, 322);
            this.paragraph_put_valid_value.Name = "paragraph_put_valid_value";
            this.paragraph_put_valid_value.Size = new System.Drawing.Size(10, 10);
            this.paragraph_put_valid_value.TabIndex = 77;
            this.paragraph_put_valid_value.Text = "button1";
            this.paragraph_put_valid_value.UseVisualStyleBackColor = true;
            this.paragraph_put_valid_value.Visible = false;
            // 
            // OpenChashbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.paragraph_put_valid_value);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.word_user);
            this.Controls.Add(this.word_cancel);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.paragraph_initail_balance_sheet);
            this.Controls.Add(this.word_start);
            this.Controls.Add(this.word_time);
            this.Controls.Add(this.txtOpenAmount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OpenChashbox";
            this.Text = "Hapja e arkes";
            this.Load += new System.EventHandler(this.OpenChashbox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label word_time;
        private System.Windows.Forms.Button word_start;
        private System.Windows.Forms.Label paragraph_initail_balance_sheet;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.Button word_cancel;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label word_user;
        public System.Windows.Forms.TextBox txtOpenAmount;
        private System.Windows.Forms.Button paragraph_put_valid_value;
    }
}