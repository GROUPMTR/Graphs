using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace DataCollect
{
    public partial class Survey_Report : DevExpress.XtraEditors.XtraForm
    {
        public Survey_Report()
        {
            InitializeComponent();
          
        }


        private void bt_LIST_RAPOR_Click(object sender, EventArgs e)
        {
            gridView_RAPOR.Columns.Clear();
                
            DATA_LOAD();
        }

        private void bt_PIVOT_RAPOR_Click(object sender, EventArgs e)
        {
            gridView_RAPOR.Columns.Clear();
            DATA_LOAD_PIVOT();
        }
        private void DATA_LOAD_PIVOT()
        {
            using (SqlConnection connection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet dsPLAN_ROW = new DataSet();
                connection.Open();

                string SQLS = @"SELECT  REPORT_ITEM FROM         dbo.ScoreCard GROUP BY REPORT_ITEM ORDER BY REPORT_ITEM ";
                command = new SqlCommand(SQLS, connection);
                command.CommandTimeout = 0;
                adapter.SelectCommand = command;
                adapter.Fill(dsPLAN_ROW, "LIST_TABLE");
                string sql = "";
                for (int i = 0; i <= dsPLAN_ROW.Tables["LIST_TABLE"].Rows.Count - 1; i++)
                {

                    sql += " MIN( CASE  SCD.REPORT_ITEM WHEN  '" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["REPORT_ITEM"].ToString() + "'  THEN SC.SCORE  END )  AS ["+ dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["REPORT_ITEM"].ToString().Replace(" ", "").Replace("&", "") + "], ";

                }
                sql = sql.ToString().Substring(0, sql.Length - 2).ToString();


                string SQL = " SELECT   dbo.SCORE_CARD_URUNLER.URUNLER, SC.COLUM_NAME, " + sql + "  FROM            dbo.ScoreCard AS SCD INNER JOIN   dbo.SCORE_CARD_SCORE AS SC ON SCD.SETID = SC.SETID AND SCD.GUID = SC.GUID INNER JOIN    dbo.SCORE_CARD_URUNLER ON SC.SETID = dbo.SCORE_CARD_URUNLER.ID GROUP BY SC.COLUM_NAME, dbo.SCORE_CARD_URUNLER.URUNLER ORDER BY dbo.SCORE_CARD_URUNLER.URUNLER";
                adapter.SelectCommand.CommandText = SQL;
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(dsPLAN_ROW, "CHART_TABLE");
                DataViewManager dvManager = new DataViewManager(dsPLAN_ROW);
                DataView DW_CHART = dvManager.CreateDataView(dsPLAN_ROW.Tables["CHART_TABLE"]);
                GRD_RAPOR.DataSource = DW_CHART;
            }
        }


        private void DATA_LOAD()
        {
            using (SqlConnection connection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet dsPLAN_ROW = new DataSet();
                connection.Open();
                string SQLS = @" SELECT   dbo.SCORE_CARD_URUNLER.URUNLER, dbo.SCORE_CARD_SCORE.COLUM_NAME,dbo.SCORE_CARD_URUNLER.ID
                                    FROM  dbo.SCORE_CARD_SCORE INNER JOIN
                                          dbo.SCORE_CARD_URUNLER ON dbo.SCORE_CARD_SCORE.SETID = dbo.SCORE_CARD_URUNLER.ID
                                    GROUP BY dbo.SCORE_CARD_URUNLER.URUNLER, dbo.SCORE_CARD_SCORE.COLUM_NAME,dbo.SCORE_CARD_URUNLER.ID
                                    ORDER BY dbo.SCORE_CARD_URUNLER.URUNLER ";
                command = new SqlCommand(SQLS, connection);                
                command.CommandTimeout = 0;
                adapter.SelectCommand = command;
                adapter.Fill(dsPLAN_ROW, "LIST_TABLE");
                string sql = "";
                for (int i = 0; i <= dsPLAN_ROW.Tables["LIST_TABLE"].Rows.Count -1 ; i++)
                {
                       //MIN(CASE WHEN SC.COLUM_NAME = 'Gliss' AND SC.SETID = '13' THEN SC.METRIC END) AS METRIC_Gliss_Dove, 

                    sql += "  MIN( CASE WHEN SC.COLUM_NAME='" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["COLUM_NAME"].ToString() + "' AND SC.SETID ='" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["ID"] + "'  THEN SC.METRIC  END ) AS METRIC_" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["COLUM_NAME"].ToString().Replace(" ", "").Replace("&", "") + "_" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["URUNLER"].ToString().Replace(" ", "").Replace("&", "") +
                           " ,MIN( CASE WHEN SC.COLUM_NAME='" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["COLUM_NAME"].ToString() + "' AND SC.SETID ='" +  dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["ID"]+ "'  THEN SC.Score  END )  AS SCORE_" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["COLUM_NAME"].ToString().Replace(" ", "").Replace("&", "") + "_" + dsPLAN_ROW.Tables["LIST_TABLE"].Rows[i]["URUNLER"].ToString().Replace(" ", "").Replace("&", "") + "  , ";
                    
                }
                sql = sql.ToString().Substring(0, sql.Length - 2).ToString();
                string SQL = " SELECT    SCD.TYPE, SCD.ROLE, SCD.REPORT_ITEM , " + sql + "    FROM            dbo.ScoreCard AS SCD INNER JOIN          dbo.SCORE_CARD_SCORE AS SC ON SCD.SETID = SC.SETID AND SCD.GUID = SC.GUID INNER JOIN     dbo.SCORE_CARD_URUNLER ON SC.SETID = dbo.SCORE_CARD_URUNLER.ID GROUP BY SCD.TYPE, SCD.ROLE, SCD.REPORT_ITEM  ORDER BY SCD.TYPE ";
                adapter.SelectCommand.CommandText = SQL;
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(dsPLAN_ROW, "CHART_TABLE");
                DataViewManager dvManager = new DataViewManager(dsPLAN_ROW);
                DataView DW_CHART = dvManager.CreateDataView(dsPLAN_ROW.Tables["CHART_TABLE"]);

                GRD_RAPOR.DataSource = DW_CHART;


            }

 
        
        }
        private string ShowSaveFileDialog(string title, string filter)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                string name = Application.ProductName;
                int n = name.LastIndexOf(".") + 1;
                if (n > 0)
                    name = name.Substring(n, name.Length - n);
                dlg.Title = String.Format("Export To {0}", title);
                dlg.FileName = name;
                dlg.Filter = filter;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.FileName;
            }
            return "";
        }
        private void bt_KAYDET_Click(object sender, EventArgs e)
        {
             

            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xlsx");
            if (fileName != "")
            {
                gridView_RAPOR.ExportToXlsx(fileName);
                OpenFile(fileName);
            }
        }
        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                    {
                        process.StartInfo.FileName = fileName;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bt_KAPAT_Click(object sender, EventArgs e)
        {
            Close();
        }

   


    }
}