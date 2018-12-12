using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCollect
{
    public partial class Masters : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Masters()
        {
            InitializeComponent();
            //GLOBAL_PARAMETRELER._CONNECTION_STRING = "Data Source=10.219.168.94;Initial Catalog=DAS;Persist Security Info=True;User ID=login;Password=tr1net784;";
            GLOBAL_PARAMETRELER._CONNECTION_STRING = "Data Source=.;Initial Catalog=MEDLINEREPORT;Persist Security Info=True;User ID=login;Password=tr1net784;";
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_DATA_YUKLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataLoad FDataYukle = new DataLoad(); 
            FDataYukle.MdiParent = this;
            FDataYukle.Show(); 
        }

        private void BR_SCORE_CARD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Survey FDataYukle = new Survey();
            FDataYukle.MdiParent = this;
            FDataYukle.Show(); 
        }

        private void BR_SCORE_CARD_REPORT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Survey_Report SurveyReport = new Survey_Report();
            SurveyReport.MdiParent = this;
            SurveyReport.Show(); 
        }
    }
}
