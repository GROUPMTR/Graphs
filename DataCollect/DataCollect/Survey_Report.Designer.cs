namespace DataCollect
{
    partial class Survey_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Survey_Report));
            this.toolStrips = new System.Windows.Forms.ToolStrip();
            this.bt_KAPAT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_KAYDET = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GRD_RAPOR = new DevExpress.XtraGrid.GridControl();
            this.gridView_RAPOR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bt_LIST_RAPOR = new System.Windows.Forms.ToolStripButton();
            this.bt_PIVOT_RAPOR = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_RAPOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_RAPOR)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrips
            // 
            this.toolStrips.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_KAPAT,
            this.toolStripSeparator2,
            this.bt_LIST_RAPOR,
            this.toolStripSeparator3,
            this.bt_PIVOT_RAPOR,
            this.toolStripSeparator4,
            this.bt_KAYDET,
            this.toolStripSeparator1});
            this.toolStrips.Location = new System.Drawing.Point(0, 0);
            this.toolStrips.Name = "toolStrips";
            this.toolStrips.Size = new System.Drawing.Size(1224, 25);
            this.toolStrips.TabIndex = 18;
            this.toolStrips.Text = "toolStrip1";
            // 
            // bt_KAPAT
            // 
            this.bt_KAPAT.Image = ((System.Drawing.Image)(resources.GetObject("bt_KAPAT.Image")));
            this.bt_KAPAT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_KAPAT.Name = "bt_KAPAT";
            this.bt_KAPAT.Size = new System.Drawing.Size(57, 22);
            this.bt_KAPAT.Text = "Kapat";
            this.bt_KAPAT.Click += new System.EventHandler(this.bt_KAPAT_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bt_KAYDET
            // 
            this.bt_KAYDET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_KAYDET.Name = "bt_KAYDET";
            this.bt_KAYDET.Size = new System.Drawing.Size(47, 22);
            this.bt_KAYDET.Text = "Kaydet";
            this.bt_KAYDET.Click += new System.EventHandler(this.bt_KAYDET_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // GRD_RAPOR
            // 
            this.GRD_RAPOR.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRD_RAPOR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_RAPOR.Location = new System.Drawing.Point(0, 25);
            this.GRD_RAPOR.MainView = this.gridView_RAPOR;
            this.GRD_RAPOR.Name = "GRD_RAPOR";
            this.GRD_RAPOR.Size = new System.Drawing.Size(1224, 741);
            this.GRD_RAPOR.TabIndex = 19;
            this.GRD_RAPOR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_RAPOR});
            // 
            // gridView_RAPOR
            // 
            this.gridView_RAPOR.ColumnPanelRowHeight = 40;
            this.gridView_RAPOR.GridControl = this.GRD_RAPOR;
            this.gridView_RAPOR.Name = "gridView_RAPOR";
            this.gridView_RAPOR.OptionsView.ColumnAutoWidth = false;
            this.gridView_RAPOR.OptionsView.ShowFooter = true;
            this.gridView_RAPOR.OptionsView.ShowGroupPanel = false;
            // 
            // bt_LIST_RAPOR
            // 
            this.bt_LIST_RAPOR.Image = ((System.Drawing.Image)(resources.GetObject("bt_LIST_RAPOR.Image")));
            this.bt_LIST_RAPOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_LIST_RAPOR.Name = "bt_LIST_RAPOR";
            this.bt_LIST_RAPOR.Size = new System.Drawing.Size(79, 22);
            this.bt_LIST_RAPOR.Text = "List Rapor";
            this.bt_LIST_RAPOR.Click += new System.EventHandler(this.bt_LIST_RAPOR_Click);
            // 
            // bt_PIVOT_RAPOR
            // 
            this.bt_PIVOT_RAPOR.Image = ((System.Drawing.Image)(resources.GetObject("bt_PIVOT_RAPOR.Image")));
            this.bt_PIVOT_RAPOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_PIVOT_RAPOR.Name = "bt_PIVOT_RAPOR";
            this.bt_PIVOT_RAPOR.Size = new System.Drawing.Size(88, 22);
            this.bt_PIVOT_RAPOR.Text = "Pivot Rapor";
            this.bt_PIVOT_RAPOR.Click += new System.EventHandler(this.bt_PIVOT_RAPOR_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Survey_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 766);
            this.Controls.Add(this.GRD_RAPOR);
            this.Controls.Add(this.toolStrips);
            this.Name = "Survey_Report";
            this.Text = "Survey_Report";
            this.toolStrips.ResumeLayout(false);
            this.toolStrips.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_RAPOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_RAPOR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrips;
        private System.Windows.Forms.ToolStripButton bt_KAPAT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bt_KAYDET;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraGrid.GridControl GRD_RAPOR;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_RAPOR;
        private System.Windows.Forms.ToolStripButton bt_LIST_RAPOR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bt_PIVOT_RAPOR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}