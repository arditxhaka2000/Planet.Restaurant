namespace MyNET.Pos.Modules
{
    partial class EnterPin
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
            this.word_save = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // word_save
            // 
            this.word_save.BackColor = System.Drawing.Color.SteelBlue;
            this.word_save.FlatAppearance.BorderSize = 0;
            this.word_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.word_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_save.ForeColor = System.Drawing.Color.White;
            this.word_save.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_save.Location = new System.Drawing.Point(202, 76);
            this.word_save.Margin = new System.Windows.Forms.Padding(2);
            this.word_save.Name = "word_save";
            this.word_save.Size = new System.Drawing.Size(89, 29);
            this.word_save.TabIndex = 5;
            this.word_save.Text = "Log In";
            this.word_save.UseVisualStyleBackColor = false;
            this.word_save.Click += new System.EventHandler(this.word_save_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(161, 32);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(130, 20);
            this.txtPin.TabIndex = 4;
            this.txtPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPin_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter PIN for Configuration:";
            // 
            // EnterPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 172);
            this.Controls.Add(this.word_save);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.label1);
            this.Name = "EnterPin";
            this.Text = "EnterPin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button word_save;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label1;
    }
}