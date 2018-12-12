using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace DataCollect
{
    public partial class Survey : DevExpress.XtraEditors.XtraForm
    {
        public Survey()
        {
            InitializeComponent();

            DATA_LOAD();
           
        }

        private void DATA_LOAD()
        {

            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                string SQL = "SELECT *  FROM [dbo].[SCORE_CARD_URUNLER]";

                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                DataSet DS = new DataSet();
                MySqlDataAdapter.Fill(DS, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(DS);
                DataView dv = dvManager.CreateDataView(DS.Tables[0]);
                grd_URUNLER.DataSource = dv;
                for (int i = 0; i <= 5; i++)
                {

                    dv.AddNew();
                }

            }




            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                string SQL = "SELECT *  FROM [dbo].[ScoreCard]";

                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                DataSet DS = new DataSet();
                MySqlDataAdapter.Fill(DS, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(DS);
                DataView dv = dvManager.CreateDataView(DS.Tables[0]);
                grd_ScoreCard.DataSource = dv;
                for (int i = 0; i <= 5; i++)
                {

                    dv.AddNew();
                }

            }

            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                string SQL = "SELECT *  FROM [dbo].[ScoreCard_Metric]";

                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                DataSet DS = new DataSet();
                MySqlDataAdapter.Fill(DS, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(DS);
                DataView dv = dvManager.CreateDataView(DS.Tables[0]);
                grd_METRIC.DataSource = dv;
                for (int i = 0; i <= 5; i++)
                {

                    dv.AddNew();
                }

            }
        
        }

        private void bt_KAPAT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MN_KAYDET_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= gridView_URUNLER.RowCount; i++)
                URUNLER(gridView_URUNLER.GetDataRow(i));  

            DATA_LOAD();

            MessageBox.Show("Güncellendi.", "Uyari",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void URUNLER(DataRow dr)
        {

            if (dr != null)
            {

                if (dr["ID"].ToString() == "")
                {
                    if (dr["URUNLER"].ToString() != "")
                    {

                        SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                        string myInsertQuery = "INSERT INTO dbo.SCORE_CARD_URUNLER (URUNLER,COLUMNS)Values(@URUNLER,@COLUMNS)";
                        SqlCommand myCommand = new SqlCommand(myInsertQuery);
                        myCommand.Parameters.AddWithValue("@URUNLER", dr["URUNLER"]);
                        myCommand.Parameters.AddWithValue("@COLUMNS", dr["COLUMNS"]);
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();
                    }
                }
                if (dr["ID"].ToString() != "")
                { 
                    SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());  
                    string myInsertQuery = "UPDATE  dbo.SCORE_CARD_URUNLER SET URUNLER=@URUNLER, COLUMNS=@COLUMNS WHERE ID=@ID ";
                    SqlCommand myCommand = new SqlCommand(myInsertQuery);
                    myCommand.Parameters.AddWithValue("@URUNLER", dr["URUNLER"]);
                    myCommand.Parameters.AddWithValue("@COLUMNS", dr["COLUMNS"]);
                    myCommand.Parameters.AddWithValue("@ID", dr["ID"]);
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();
                    
                }

            }
        }



        private void ScoreCard(DataRow dr)
        {

            if (dr != null)
            {


                if (dr["ID"].ToString() == "")
                {
                    if (dr["TYPE"].ToString() != "")
                    {
                        SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                        string myInsertQuery = "INSERT INTO dbo.ScoreCard (TYPE, ROLE)  Values(@TYPE,@ROLE)";
                        SqlCommand myCommand = new SqlCommand(myInsertQuery);
                        myCommand.Parameters.AddWithValue("@TYPE", dr["TYPE"]);
                        myCommand.Parameters.AddWithValue("@ROLE", dr["ROLE"]);
                        myCommand.Parameters.AddWithValue("@REPORT_ITEM", dr["REPORT_ITEM"]);
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();
                    }
                }
                if (dr["ID"].ToString() != "")
                {
                    SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                    string myInsertQuery = "UPDATE dbo.ScoreCard  SET TYPE=@TYPE,ROLE=@ROLE WHERE ID=@ID";
                    SqlCommand myCommand = new SqlCommand(myInsertQuery);
                    myCommand.Parameters.AddWithValue("@TYPE", dr["TYPE"]);
                    myCommand.Parameters.AddWithValue("@ROLE", dr["ROLE"]);
                    myCommand.Parameters.AddWithValue("@REPORT_ITEM", dr["REPORT_ITEM"]);
                    myCommand.Parameters.AddWithValue("@ID", dr["ID"]);
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                }




             
            }
        }


        private void ScoreCard_Metric(DataRow dr)
        {

            if (dr != null)
            {

                if (dr["ID"].ToString() == "")
                {
                    if (dr["REPORT_ITEM"].ToString() != "")
                    {
                        SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                        string myInsertQuery = "INSERT INTO dbo.ScoreCard_Metric (REPORT_ITEM, METRIC,SCORE)  Values(@REPORT_ITEM,@METRIC,@SCORE)";
                        SqlCommand myCommand = new SqlCommand(myInsertQuery);
                        myCommand.Parameters.AddWithValue("@REPORT_ITEM", dr["REPORT_ITEM"]);
                        myCommand.Parameters.AddWithValue("@METRIC", dr["METRIC"]);
                        myCommand.Parameters.AddWithValue("@SCORE", dr["SCORE"]);
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();
                    }
                }
                if (dr["ID"].ToString() != "")
                {
                    SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                    string myInsertQuery = "UPDATE dbo.ScoreCard_Metric SET REPORT_ITEM=@REPORT_ITEM, METRIC=@METRIC,SCORE=@SCORE WHERE ID=@";
                    SqlCommand myCommand = new SqlCommand(myInsertQuery);
                    myCommand.Parameters.AddWithValue("@REPORT_ITEM", dr["REPORT_ITEM"]);
                    myCommand.Parameters.AddWithValue("@METRIC", dr["METRIC"]);
                    myCommand.Parameters.AddWithValue("@SCORE", dr["SCORE"]);
                    myCommand.Parameters.AddWithValue("@ID", dr["ID"]);
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                }




            }
        }

        private void MN_SIL_Click(object sender, EventArgs e)
        {
            int[] ROW = gridView_URUNLER.GetSelectedRows();
            for (int i = 0; i < ROW.Length; i++)
            {
                DataRow dr = gridView_URUNLER.GetDataRow(ROW[i]);
                SqlConnection myConnectionTable = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = " DELETE  dbo.SCORE_CARD_URUNLER WHERE ID=@ID      ";

                myCmd.Parameters.AddWithValue("@ID", dr["ID"].ToString());
                myCmd.Connection = myConnectionTable;
                myCmd.ExecuteNonQuery();
                myCmd.Connection.Close();

            }

            DATA_LOAD();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
            for (int i = 0; i <= grdView_ScoreCard.RowCount; i++)
                ScoreCard(grdView_ScoreCard.GetDataRow(i));



      


            DATA_LOAD();

            MessageBox.Show("Güncellendi.", "Uyari",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i <= grdView_METRIC.RowCount; i++)
                ScoreCard_Metric(grdView_METRIC.GetDataRow(i));


            DATA_LOAD();

            MessageBox.Show("Güncellendi.", "Uyari",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            int[] ROW = grdView_METRIC.GetSelectedRows();
            for (int i = 0; i < ROW.Length; i++)
            {
                DataRow dr = grdView_METRIC.GetDataRow(ROW[i]);
                SqlConnection myConnectionTable = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = " DELETE  dbo.ScoreCard_Metric WHERE ID=@ID      ";

                myCmd.Parameters.AddWithValue("@ID", dr["ID"].ToString());
                myCmd.Connection = myConnectionTable;
                myCmd.ExecuteNonQuery();
                myCmd.Connection.Close();

            }

            DATA_LOAD();


          
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int[] ROW = grdView_ScoreCard.GetSelectedRows();
            for (int i = 0; i < ROW.Length; i++)
            {
                DataRow dr = grdView_ScoreCard.GetDataRow(ROW[i]);
                SqlConnection myConnectionTable = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString());
                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = " DELETE  dbo.ScoreCard WHERE ID=@ID      ";

                myCmd.Parameters.AddWithValue("@ID", dr["ID"].ToString());
                myCmd.Connection = myConnectionTable;
                myCmd.ExecuteNonQuery();
                myCmd.Connection.Close(); 
            } 
            DATA_LOAD();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
      } 
}