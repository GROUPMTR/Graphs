namespace DataCollect
{
    partial class Masters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Masters));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BR_DATA_YUKLE = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.BR_SCORE_CARD = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManagers = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BR_SCORE_CARD_REPORT = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BR_DATA_YUKLE,
            this.BTN_KAPAT,
            this.BR_SCORE_CARD,
            this.BR_SCORE_CARD_REPORT});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1192, 144);
            // 
            // BR_DATA_YUKLE
            // 
            this.BR_DATA_YUKLE.Caption = "Data Yükle";
            this.BR_DATA_YUKLE.Glyph = ((System.Drawing.Image)(resources.GetObject("BR_DATA_YUKLE.Glyph")));
            this.BR_DATA_YUKLE.Id = 1;
            this.BR_DATA_YUKLE.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BR_DATA_YUKLE.LargeGlyph")));
            this.BR_DATA_YUKLE.Name = "BR_DATA_YUKLE";
            this.BR_DATA_YUKLE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_DATA_YUKLE_ItemClick);
            // 
            // BTN_KAPAT
            // 
            this.BTN_KAPAT.Caption = "Kapat";
            this.BTN_KAPAT.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAPAT.Glyph")));
            this.BTN_KAPAT.Id = 2;
            this.BTN_KAPAT.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAPAT.LargeGlyph")));
            this.BTN_KAPAT.Name = "BTN_KAPAT";
            this.BTN_KAPAT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_KAPAT_ItemClick);
            // 
            // BR_SCORE_CARD
            // 
            this.BR_SCORE_CARD.Caption = "Score Card";
            this.BR_SCORE_CARD.Glyph = ((System.Drawing.Image)(resources.GetObject("BR_SCORE_CARD.Glyph")));
            this.BR_SCORE_CARD.Id = 3;
            this.BR_SCORE_CARD.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BR_SCORE_CARD.LargeGlyph")));
            this.BR_SCORE_CARD.Name = "BR_SCORE_CARD";
            this.BR_SCORE_CARD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_SCORE_CARD_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Data Manager";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.BTN_KAPAT);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Kapat";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.BR_DATA_YUKLE);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Data Yükle";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.BR_SCORE_CARD);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Score Card Manager";
            // 
            // xtraTabbedMdiManagers
            // 
            this.xtraTabbedMdiManagers.MdiParent = this;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.BR_SCORE_CARD_REPORT);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Score Card Report";
            // 
            // BR_SCORE_CARD_REPORT
            // 
            this.BR_SCORE_CARD_REPORT.Caption = "Score Card Report";
            this.BR_SCORE_CARD_REPORT.Glyph = ((System.Drawing.Image)(resources.GetObject("BR_SCORE_CARD_REPORT.Glyph")));
            this.BR_SCORE_CARD_REPORT.Id = 4;
            this.BR_SCORE_CARD_REPORT.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BR_SCORE_CARD_REPORT.LargeGlyph")));
            this.BR_SCORE_CARD_REPORT.Name = "BR_SCORE_CARD_REPORT";
            this.BR_SCORE_CARD_REPORT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_SCORE_CARD_REPORT_ItemClick);
            // 
            // Masters
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 802);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "Masters";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManagers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BR_DATA_YUKLE;
        private DevExpress.XtraBars.BarButtonItem BTN_KAPAT;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManagers;
        private DevExpress.XtraBars.BarButtonItem BR_SCORE_CARD;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem BR_SCORE_CARD_REPORT;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}

