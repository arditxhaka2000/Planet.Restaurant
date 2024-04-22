namespace MyNET.Shops
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.word_cash = new System.Windows.Forms.Label();
            this.word_total_for_payment = new System.Windows.Forms.Label();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnBackSpace = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnPoint = new System.Windows.Forms.Button();
            this.btn00 = new System.Windows.Forms.Button();
            this.ucb1 = new System.Windows.Forms.ComboBox();
            this.numPos1 = new System.Windows.Forms.TextBox();
            this.numPos2 = new System.Windows.Forms.TextBox();
            this.numPosBonusCard = new System.Windows.Forms.TextBox();
            this.numPos4 = new System.Windows.Forms.TextBox();
            this.numTotal = new System.Windows.Forms.TextBox();
            this.word_amount_paid = new System.Windows.Forms.Label();
            this.numCash = new System.Windows.Forms.TextBox();
            this.numTotalForPayment = new System.Windows.Forms.TextBox();
            this.word_to_return_amount = new System.Windows.Forms.Label();
            this.numReturn = new System.Windows.Forms.TextBox();
            this.paragraph_pay_error = new System.Windows.Forms.Button();
            this.paragraph_pay_error_2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_bonusCard = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // word_cash
            // 
            this.word_cash.AutoSize = true;
            this.word_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_cash.ForeColor = System.Drawing.Color.Black;
            this.word_cash.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_cash.Location = new System.Drawing.Point(5, 70);
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
            // lblTotalPayment
            // 
            this.lblTotalPayment.AutoSize = true;
            this.lblTotalPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayment.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalPayment.Location = new System.Drawing.Point(11, 413);
            this.lblTotalPayment.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(163, 26);
            this.lblTotalPayment.TabIndex = 70;
            this.lblTotalPayment.Text = "Totali i pagesës";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(11, 466);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 26);
            this.label5.TabIndex = 72;
            this.label5.Text = "Për kthim";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.Controls.Add(this.btnDel, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.btnBackSpace, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.btnEnter, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.btn9, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn8, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btn5, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btn6, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.btn3, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.btn2, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.btn1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.btn0, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnPoint, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.btn00, 0, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(461, 599);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnDel
            // 
            this.btnDel.BackgroundImage = global::MyNET.Pos.Properties.Resources.trash;
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(83)))), ((int)(((byte)(108)))));
            this.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(16, 486);
            this.btnDel.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(121, 108);
            this.btnDel.TabIndex = 9;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackSpace.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(83)))), ((int)(((byte)(108)))));
            this.btnBackSpace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackSpace.Location = new System.Drawing.Point(169, 486);
            this.btnBackSpace.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(121, 108);
            this.btnBackSpace.TabIndex = 12;
            this.btnBackSpace.Text = "Fshij";
            this.btnBackSpace.UseVisualStyleBackColor = true;
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpace_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.White;
            this.btnEnter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnter.BackgroundImage")));
            this.btnEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(219)))), ((int)(((byte)(131)))));
            this.btnEnter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(322, 486);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(123, 108);
            this.btnEnter.TabIndex = 11;
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.Silver;
            this.btn9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn9.FlatAppearance.BorderSize = 0;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(322, 10);
            this.btn9.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(123, 104);
            this.btn9.TabIndex = 8;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.Silver;
            this.btn8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn8.FlatAppearance.BorderSize = 0;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(169, 10);
            this.btn8.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(121, 104);
            this.btn8.TabIndex = 7;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.Silver;
            this.btn7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn7.FlatAppearance.BorderSize = 0;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(16, 10);
            this.btn7.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(121, 104);
            this.btn7.TabIndex = 6;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.Silver;
            this.btn4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn4.FlatAppearance.BorderSize = 0;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(16, 129);
            this.btn4.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(121, 104);
            this.btn4.TabIndex = 3;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.Silver;
            this.btn5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(169, 129);
            this.btn5.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(121, 104);
            this.btn5.TabIndex = 4;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.Silver;
            this.btn6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn6.FlatAppearance.BorderSize = 0;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(322, 129);
            this.btn6.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(123, 104);
            this.btn6.TabIndex = 5;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Silver;
            this.btn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn3.FlatAppearance.BorderSize = 0;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(322, 248);
            this.btn3.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(123, 104);
            this.btn3.TabIndex = 2;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.Silver;
            this.btn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2.FlatAppearance.BorderSize = 0;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(169, 248);
            this.btn2.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(121, 104);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Silver;
            this.btn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(16, 248);
            this.btn1.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(121, 104);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.Silver;
            this.btn0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn0.FlatAppearance.BorderSize = 0;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(169, 367);
            this.btn0.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(121, 104);
            this.btn0.TabIndex = 10;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btnPoint
            // 
            this.btnPoint.BackColor = System.Drawing.Color.Silver;
            this.btnPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPoint.FlatAppearance.BorderSize = 0;
            this.btnPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoint.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoint.Location = new System.Drawing.Point(322, 367);
            this.btnPoint.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(123, 104);
            this.btnPoint.TabIndex = 10;
            this.btnPoint.Text = ".";
            this.btnPoint.UseVisualStyleBackColor = false;
            this.btnPoint.Click += new System.EventHandler(this.btnNoClick);
            // 
            // btn00
            // 
            this.btn00.BackColor = System.Drawing.Color.Silver;
            this.btn00.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn00.FlatAppearance.BorderSize = 0;
            this.btn00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn00.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn00.Location = new System.Drawing.Point(16, 367);
            this.btn00.Margin = new System.Windows.Forms.Padding(16, 10, 16, 5);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(121, 104);
            this.btn00.TabIndex = 10;
            this.btn00.Text = "00";
            this.btn00.UseVisualStyleBackColor = false;
            this.btn00.Click += new System.EventHandler(this.btnNoClick);
            // 
            // ucb1
            // 
            this.ucb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ucb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucb1.FormattingEnabled = true;
            this.ucb1.Location = new System.Drawing.Point(3, 121);
            this.ucb1.Name = "ucb1";
            this.ucb1.Size = new System.Drawing.Size(235, 28);
            this.ucb1.TabIndex = 102;
            this.ucb1.Visible = false;
            // 
            // numPos1
            // 
            this.numPos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPos1.Location = new System.Drawing.Point(280, 121);
            this.numPos1.Name = "numPos1";
            this.numPos1.Size = new System.Drawing.Size(138, 26);
            this.numPos1.TabIndex = 103;
            this.numPos1.Text = "0";
            this.numPos1.Visible = false;
            this.numPos1.Click += new System.EventHandler(this.numPos1_Click);
            this.numPos1.TextChanged += new System.EventHandler(this.total_ValueChanged);
            this.numPos1.Enter += new System.EventHandler(this.num_Enter);
            this.numPos1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numPos1_KeyPress);
            // 
            // numPos2
            // 
            this.numPos2.Location = new System.Drawing.Point(302, 176);
            this.numPos2.Name = "numPos2";
            this.numPos2.Size = new System.Drawing.Size(105, 23);
            this.numPos2.TabIndex = 105;
            this.numPos2.Text = "0";
            this.numPos2.Visible = false;
            this.numPos2.TextChanged += new System.EventHandler(this.total_ValueChanged);
            this.numPos2.Enter += new System.EventHandler(this.num_Enter);
            // 
            // numPosBonusCard
            // 
            this.numPosBonusCard.Location = new System.Drawing.Point(302, 231);
            this.numPosBonusCard.Name = "numPosBonusCard";
            this.numPosBonusCard.ReadOnly = true;
            this.numPosBonusCard.Size = new System.Drawing.Size(105, 23);
            this.numPosBonusCard.TabIndex = 107;
            this.numPosBonusCard.Text = "0";
            this.numPosBonusCard.TextChanged += new System.EventHandler(this.numPosBonusCard_TextChanged);
            this.numPosBonusCard.Enter += new System.EventHandler(this.num_Enter);
            // 
            // numPos4
            // 
            this.numPos4.Location = new System.Drawing.Point(302, 286);
            this.numPos4.Name = "numPos4";
            this.numPos4.Size = new System.Drawing.Size(105, 23);
            this.numPos4.TabIndex = 109;
            this.numPos4.Text = "0";
            this.numPos4.Visible = false;
            this.numPos4.TextChanged += new System.EventHandler(this.total_ValueChanged);
            this.numPos4.Enter += new System.EventHandler(this.num_Enter);
            // 
            // numTotal
            // 
            this.numTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotal.Location = new System.Drawing.Point(280, 348);
            this.numTotal.Name = "numTotal";
            this.numTotal.ReadOnly = true;
            this.numTotal.Size = new System.Drawing.Size(138, 26);
            this.numTotal.TabIndex = 110;
            this.numTotal.Text = "0";
            // 
            // word_amount_paid
            // 
            this.word_amount_paid.AutoSize = true;
            this.word_amount_paid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_amount_paid.ForeColor = System.Drawing.Color.Black;
            this.word_amount_paid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_amount_paid.Location = new System.Drawing.Point(3, 341);
            this.word_amount_paid.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.word_amount_paid.Name = "word_amount_paid";
            this.word_amount_paid.Size = new System.Drawing.Size(173, 26);
            this.word_amount_paid.TabIndex = 111;
            this.word_amount_paid.Text = "Shuma e paguar";
            // 
            // numCash
            // 
            this.numCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCash.Location = new System.Drawing.Point(280, 60);
            this.numCash.Name = "numCash";
            this.numCash.Size = new System.Drawing.Size(138, 40);
            this.numCash.TabIndex = 112;
            this.numCash.Text = "0";
            this.numCash.Click += new System.EventHandler(this.numCash_Click);
            this.numCash.TextChanged += new System.EventHandler(this.total_ValueChanged);
            this.numCash.Enter += new System.EventHandler(this.num_Enter);
            this.numCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numCash_KeyPress);
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
            // word_to_return_amount
            // 
            this.word_to_return_amount.AutoSize = true;
            this.word_to_return_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_to_return_amount.ForeColor = System.Drawing.Color.Black;
            this.word_to_return_amount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.word_to_return_amount.Location = new System.Drawing.Point(3, 407);
            this.word_to_return_amount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.word_to_return_amount.Name = "word_to_return_amount";
            this.word_to_return_amount.Size = new System.Drawing.Size(105, 26);
            this.word_to_return_amount.TabIndex = 115;
            this.word_to_return_amount.Text = "Për kthim";
            // 
            // numReturn
            // 
            this.numReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numReturn.Location = new System.Drawing.Point(280, 405);
            this.numReturn.Name = "numReturn";
            this.numReturn.ReadOnly = true;
            this.numReturn.Size = new System.Drawing.Size(138, 40);
            this.numReturn.TabIndex = 114;
            this.numReturn.Text = "0";
            this.numReturn.TextChanged += new System.EventHandler(this.total_ValueChanged);
            // 
            // paragraph_pay_error
            // 
            this.paragraph_pay_error.Location = new System.Drawing.Point(69, 549);
            this.paragraph_pay_error.Name = "paragraph_pay_error";
            this.paragraph_pay_error.Size = new System.Drawing.Size(10, 10);
            this.paragraph_pay_error.TabIndex = 116;
            this.paragraph_pay_error.Text = "Totali per pages eshte me i madh se totali per te paguar! Ju lutem barazoni shume" +
    "n.";
            this.paragraph_pay_error.UseVisualStyleBackColor = true;
            this.paragraph_pay_error.Visible = false;
            // 
            // paragraph_pay_error_2
            // 
            this.paragraph_pay_error_2.Location = new System.Drawing.Point(85, 549);
            this.paragraph_pay_error_2.Name = "paragraph_pay_error_2";
            this.paragraph_pay_error_2.Size = new System.Drawing.Size(10, 10);
            this.paragraph_pay_error_2.TabIndex = 117;
            this.paragraph_pay_error_2.Text = "Shuma e paguar eshte me vogel se totali per pages! Ju lutem barazoni shumen.";
            this.paragraph_pay_error_2.UseVisualStyleBackColor = true;
            this.paragraph_pay_error_2.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(897, 599);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 118;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_bonusCard);
            this.panel1.Controls.Add(this.numTotal);
            this.panel1.Controls.Add(this.word_cash);
            this.panel1.Controls.Add(this.word_total_for_payment);
            this.panel1.Controls.Add(this.word_to_return_amount);
            this.panel1.Controls.Add(this.ucb1);
            this.panel1.Controls.Add(this.numReturn);
            this.panel1.Controls.Add(this.numPos1);
            this.panel1.Controls.Add(this.numTotalForPayment);
            this.panel1.Controls.Add(this.numPos2);
            this.panel1.Controls.Add(this.numCash);
            this.panel1.Controls.Add(this.numPosBonusCard);
            this.panel1.Controls.Add(this.word_amount_paid);
            this.panel1.Controls.Add(this.numPos4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 599);
            this.panel1.TabIndex = 101;
            // 
            // txt_bonusCard
            // 
            this.txt_bonusCard.Location = new System.Drawing.Point(12, 231);
            this.txt_bonusCard.Name = "txt_bonusCard";
            this.txt_bonusCard.ReadOnly = true;
            this.txt_bonusCard.Size = new System.Drawing.Size(141, 23);
            this.txt_bonusCard.TabIndex = 116;
            this.txt_bonusCard.Text = "Bonus Kartela";
            this.txt_bonusCard.Click += new System.EventHandler(this.txt_bonusCard_Click);
            this.txt_bonusCard.TextChanged += new System.EventHandler(this.txt_bonusCard_TextChanged);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 599);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.paragraph_pay_error_2);
            this.Controls.Add(this.paragraph_pay_error);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.ShowIcon = false;
            this.Text = "Pagesa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPayment_FormClosing);
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.Shown += new System.EventHandler(this.frmPayment_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPayment_KeyDown);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label word_cash;
        private System.Windows.Forms.Label word_total_for_payment;
       
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnBackSpace;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnPoint;
        private System.Windows.Forms.Button btn00;
        private System.Windows.Forms.ComboBox ucb1;
        private System.Windows.Forms.TextBox numTotal;
        private System.Windows.Forms.Label word_amount_paid;
        private System.Windows.Forms.TextBox numCash;
        private System.Windows.Forms.Label word_to_return_amount;
        private System.Windows.Forms.TextBox numReturn;
        public System.Windows.Forms.TextBox numTotalForPayment;
        public System.Windows.Forms.TextBox numPos1;
        public System.Windows.Forms.TextBox numPos2;
        public System.Windows.Forms.TextBox numPosBonusCard;
        public System.Windows.Forms.TextBox numPos4;
        private System.Windows.Forms.Button paragraph_pay_error;
        private System.Windows.Forms.Button paragraph_pay_error_2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_bonusCard;
    }
}