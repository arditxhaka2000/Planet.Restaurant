namespace ServerManifest
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //NOTE: The following procedure is required by the Windows Form Designer 
        //It can be modified using the Windows Form Designer. 
        //Do not modify it using the code editor. 
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtPath;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button btnCreateList;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1; 

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
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnCreateList = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.ListBox();
            this.lblList = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewVersion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(29, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(196, 25);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Folderi i ndryshimeve";
            // 
            // txtPath
            // 
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(206, 23);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(444, 30);
            this.txtPath.TabIndex = 1;
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Location = new System.Drawing.Point(656, 23);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(46, 30);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "...";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnCreateList
            // 
            this.btnCreateList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCreateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateList.Location = new System.Drawing.Point(567, 128);
            this.btnCreateList.Name = "btnCreateList";
            this.btnCreateList.Size = new System.Drawing.Size(135, 39);
            this.btnCreateList.TabIndex = 3;
            this.btnCreateList.Text = "Formo listen";
            this.btnCreateList.UseVisualStyleBackColor = false;
            this.btnCreateList.Click += new System.EventHandler(this.btnCreateList_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(29, 545);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(673, 47);
            this.lblStatus.TabIndex = 4;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(29, 494);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(673, 34);
            this.pb.TabIndex = 5;
            this.pb.Visible = false;
            // 
            // txtVersion
            // 
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.Location = new System.Drawing.Point(206, 119);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(273, 30);
            this.txtVersion.TabIndex = 6;
            this.txtVersion.Text = "1.0.0.0";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(29, 124);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(136, 25);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Version aktual";
            // 
            // lb
            // 
            this.lb.FormattingEnabled = true;
            this.lb.ItemHeight = 16;
            this.lb.Location = new System.Drawing.Point(29, 235);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(450, 116);
            this.lb.TabIndex = 8;
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.ForeColor = System.Drawing.Color.White;
            this.lblList.Location = new System.Drawing.Point(29, 207);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(53, 25);
            this.lblList.TabIndex = 9;
            this.lblList.Text = "Lista";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(567, 437);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(135, 39);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Dergo";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(29, 77);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(106, 25);
            this.lblAppName.TabIndex = 12;
            this.lblAppName.Text = "Aplikacioni";
            // 
            // txtAppName
            // 
            this.txtAppName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppName.Location = new System.Drawing.Point(206, 72);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(273, 30);
            this.txtAppName.TabIndex = 11;
            this.txtAppName.Text = "planetpos";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(29, 393);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(450, 83);
            this.txtDescription.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Pershkrimi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Version i ri";
            // 
            // txtNewVersion
            // 
            this.txtNewVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewVersion.Location = new System.Drawing.Point(206, 166);
            this.txtNewVersion.Name = "txtNewVersion";
            this.txtNewVersion.Size = new System.Drawing.Size(273, 30);
            this.txtNewVersion.TabIndex = 15;
            // 
            // Main
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(757, 628);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.txtAppName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCreateList);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.Label1);
            this.Name = "Main";
            this.Text = "Server Manifest Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb;
        internal System.Windows.Forms.TextBox txtVersion;
        internal System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ListBox lb;
        internal System.Windows.Forms.Label lblList;
        internal System.Windows.Forms.Button btnSend;
        internal System.Windows.Forms.Label lblAppName;
        internal System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtNewVersion;
    }
}

