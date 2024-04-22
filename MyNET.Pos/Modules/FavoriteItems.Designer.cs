namespace MyNET.Pos.Modules
{
    partial class FavoriteItems
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
            this.dg = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.word_favorite_items = new System.Windows.Forms.Label();
            this.word_save = new System.Windows.Forms.Button();
            this.word_delete = new System.Windows.Forms.Button();
            this.word_choose_all = new System.Windows.Forms.RadioButton();
            this.word_choose_fav_items = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(12, 25);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(417, 531);
            this.dg.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(408, 531);
            this.dataGridView1.TabIndex = 1;
            // 
            // word_favorite_items
            // 
            this.word_favorite_items.AutoSize = true;
            this.word_favorite_items.Location = new System.Drawing.Point(170, 9);
            this.word_favorite_items.Name = "word_favorite_items";
            this.word_favorite_items.Size = new System.Drawing.Size(94, 13);
            this.word_favorite_items.TabIndex = 2;
            this.word_favorite_items.Text = "Produktet Favorite";
            // 
            // word_save
            // 
            this.word_save.BackColor = System.Drawing.Color.SteelBlue;
            this.word_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.word_save.ForeColor = System.Drawing.Color.White;
            this.word_save.Location = new System.Drawing.Point(124, 571);
            this.word_save.Name = "word_save";
            this.word_save.Size = new System.Drawing.Size(108, 34);
            this.word_save.TabIndex = 3;
            this.word_save.Text = "Ruaj";
            this.word_save.UseVisualStyleBackColor = false;
            this.word_save.Click += new System.EventHandler(this.RuajFavorite_Click);
            // 
            // word_delete
            // 
            this.word_delete.BackColor = System.Drawing.Color.SteelBlue;
            this.word_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.word_delete.ForeColor = System.Drawing.Color.White;
            this.word_delete.Location = new System.Drawing.Point(173, 562);
            this.word_delete.Name = "word_delete";
            this.word_delete.Size = new System.Drawing.Size(108, 34);
            this.word_delete.TabIndex = 5;
            this.word_delete.Text = "Fshi";
            this.word_delete.UseVisualStyleBackColor = false;
            this.word_delete.Click += new System.EventHandler(this.button2_Click);
            // 
            // word_choose_all
            // 
            this.word_choose_all.AutoSize = true;
            this.word_choose_all.Location = new System.Drawing.Point(310, 571);
            this.word_choose_all.Name = "word_choose_all";
            this.word_choose_all.Size = new System.Drawing.Size(104, 17);
            this.word_choose_all.TabIndex = 6;
            this.word_choose_all.TabStop = true;
            this.word_choose_all.Text = "Zgjedh Te Gjitha";
            this.word_choose_all.UseVisualStyleBackColor = true;
            this.word_choose_all.CheckedChanged += new System.EventHandler(this.allFavItem_CheckedChanged);
            // 
            // word_choose_fav_items
            // 
            this.word_choose_fav_items.AutoSize = true;
            this.word_choose_fav_items.Location = new System.Drawing.Point(102, 9);
            this.word_choose_fav_items.Name = "word_choose_fav_items";
            this.word_choose_fav_items.Size = new System.Drawing.Size(130, 13);
            this.word_choose_fav_items.TabIndex = 7;
            this.word_choose_fav_items.Text = "Zgjedh Produktet Favorite";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dg);
            this.splitContainer1.Panel1.Controls.Add(this.word_choose_all);
            this.splitContainer1.Panel1.Controls.Add(this.word_choose_fav_items);
            this.splitContainer1.Panel1.Controls.Add(this.word_save);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.word_favorite_items);
            this.splitContainer1.Panel2.Controls.Add(this.word_delete);
            this.splitContainer1.Size = new System.Drawing.Size(864, 599);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 8;
            // 
            // FavoriteItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 614);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(878, 653);
            this.MinimumSize = new System.Drawing.Size(878, 653);
            this.Name = "FavoriteItems";
            this.Load += new System.EventHandler(this.FavoriteItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label word_favorite_items;
        private System.Windows.Forms.Button word_save;
        private System.Windows.Forms.Button word_delete;
        private System.Windows.Forms.RadioButton word_choose_all;
        private System.Windows.Forms.Label word_choose_fav_items;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}