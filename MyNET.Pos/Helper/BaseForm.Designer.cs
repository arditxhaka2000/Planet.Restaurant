namespace MyNET.Pos
{
    partial class BaseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbRegister = new System.Windows.Forms.ToolStripButton();
            this.tsseperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMoveBack = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForward = new System.Windows.Forms.ToolStripButton();
            this.tsseperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbExportPDF = new System.Windows.Forms.ToolStripButton();
            this.tsbExportXML = new System.Windows.Forms.ToolStripButton();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbPrint
            // 
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(41, 35);
            this.tsbPrint.Text = "Shtyp";
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts
            // 
            this.ts.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbRegister,
            this.tsseperator1,
            this.tsbMoveBack,
            this.tsbMoveForward,
            this.tsseperator2,
            this.tsbExportExcel,
            this.tsbExportPDF,
            this.tsbExportXML});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ts.Size = new System.Drawing.Size(898, 27);
            this.ts.TabIndex = 2;
            this.ts.Visible = false;
            this.ts.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ts_ItemClicked);
            // 
            // tsbNew
            // 
            this.tsbNew.Enabled = false;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(30, 24);
            this.tsbNew.Text = "I ri";
            this.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbOpen
            // 
            this.tsbOpen.Enabled = false;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(49, 24);
            this.tsbOpen.Text = "Hape";
            this.tsbOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbSave
            // 
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(42, 24);
            this.tsbSave.Text = "Ruaj";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(38, 24);
            this.tsbDelete.Text = "Fshi";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(75, 24);
            this.tsbRefresh.Text = "Aktualizo";
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbRegister
            // 
            this.tsbRegister.Enabled = false;
            this.tsbRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegister.Name = "tsbRegister";
            this.tsbRegister.Size = new System.Drawing.Size(72, 24);
            this.tsbRegister.Text = "Regjistro";
            this.tsbRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRegister.Visible = false;
            // 
            // tsseperator1
            // 
            this.tsseperator1.Name = "tsseperator1";
            this.tsseperator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbMoveBack
            // 
            this.tsbMoveBack.Enabled = false;
            this.tsbMoveBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveBack.Name = "tsbMoveBack";
            this.tsbMoveBack.Size = new System.Drawing.Size(51, 24);
            this.tsbMoveBack.Text = "Prapa";
            this.tsbMoveBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveBack.Click += new System.EventHandler(this.tsbMoveBack_Click);
            // 
            // tsbMoveForward
            // 
            this.tsbMoveForward.Enabled = false;
            this.tsbMoveForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveForward.Name = "tsbMoveForward";
            this.tsbMoveForward.Size = new System.Drawing.Size(41, 24);
            this.tsbMoveForward.Text = "Para";
            this.tsbMoveForward.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsseperator2
            // 
            this.tsseperator2.Name = "tsseperator2";
            this.tsseperator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbExportExcel
            // 
            this.tsbExportExcel.Enabled = false;
            this.tsbExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcel.Name = "tsbExportExcel";
            this.tsbExportExcel.Size = new System.Drawing.Size(47, 24);
            this.tsbExportExcel.Text = "Excel";
            this.tsbExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbExportPDF
            // 
            this.tsbExportPDF.Enabled = false;
            this.tsbExportPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportPDF.Name = "tsbExportPDF";
            this.tsbExportPDF.Size = new System.Drawing.Size(39, 24);
            this.tsbExportPDF.Text = "PDF";
            this.tsbExportPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbExportXML
            // 
            this.tsbExportXML.Enabled = false;
            this.tsbExportXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportXML.Name = "tsbExportXML";
            this.tsbExportXML.Size = new System.Drawing.Size(42, 24);
            this.tsbExportXML.Text = "XML";
            this.tsbExportXML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 476);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseForm_KeyDown);
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator tsseperator1;
        private System.Windows.Forms.ToolStripButton tsbMoveBack;
        private System.Windows.Forms.ToolStripSeparator tsseperator2;
        private System.Windows.Forms.ToolStripButton tsbExportExcel;
        private System.Windows.Forms.ToolStripButton tsbExportPDF;
        private System.Windows.Forms.ToolStripButton tsbExportXML;
        //public Infragistics.Win.Misc.UltraGroupBox ugb;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbMoveForward;
        public System.Windows.Forms.ToolStrip ts;
                   

    }
}