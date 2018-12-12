using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DataCollect
{
    public partial class DataLoad : DevExpress.XtraEditors.XtraForm
    {
        ArrayList Array_LIST_FILED = null;
        ArrayList Array_LIST_HEADER = null;


        DataView dvAcik;
        DataTable tbl = new DataTable("DATA_TEMP");
        static DataSet TRADEDATESET;
        OpenFileDialog fDialog = new OpenFileDialog();
        public DataLoad()
        {
            InitializeComponent();
            TABLE_READ();
            dateEditStrt.Text = DateTime.Now.AddDays(-30).ToShortDateString();
            dateEditEnd.Text = DateTime.Now.ToShortDateString();
        }
        private void TABLE_READ()
        {
            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter("select * from ADM_TABLE_LIST", myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LIST.DataSource = dv;
            }
        }

        private void btn_KAYDET_Click(object sender, EventArgs e)
        {
            Array_LIST_FILED = new ArrayList();
            Array_LIST_HEADER = new ArrayList();

            string TargetNameField = "";
            if (text_DOSYAADI.Text != "")
            {
                for (int i = 0; i <= grdView_FIELD.RowCount; i++)
                {
                    DataRow dr = grdView_FIELD.GetDataRow(i);
                    if (dr != null)
                    {
                        if (dr["TYPE"].ToString() == "nvarchar")
                        {
                            TargetNameField += "[" + dr["FIELD"].ToString() + "] [" + dr["TYPE"].ToString() + "]  (" + dr["SIZE"].ToString() + ") NULL , ";
                        }
                        else
                        {
                            TargetNameField += "[" + dr["FIELD"].ToString() + "] [" + dr["TYPE"].ToString() + "] NULL , ";
                        }
                        Array_LIST_FILED.Add(dr["FIELD"].ToString());
                    }
                } 

                if (TargetNameField == "")
                {
                    for (int i = 0; i <= grdView_DEFAULT_FIELD.RowCount; i++)
                    {
                        DataRow dr = grdView_DEFAULT_FIELD.GetDataRow(i);
                        if (dr != null)
                        {
                            if (dr["DATA_TYPE"].ToString() == "nvarchar")
                            {
                                TargetNameField += "[" + dr["COLUMN_NAME"].ToString() + "] [" + dr["DATA_TYPE"].ToString() + "]  (" + dr["CHARACTER_MAXIMUM_LENGTH"].ToString() + ") NULL , ";
                            }
                            else
                            {
                                TargetNameField += "[" + dr["COLUMN_NAME"].ToString() + "] [" + dr["DATA_TYPE"].ToString() + "] NULL , ";
                            }
                            Array_LIST_FILED.Add(dr["COLUMN_NAME"].ToString());
                        }
                    }
                } 

                for (int i = 0; i <= dvAcik.Table.Columns.Count - 1; i++)
                {
                    Array_LIST_HEADER.Add(dvAcik.Table.Columns[i].ColumnName);
                }
                if (RD_DATASIL.Checked)
                {
                    using (SqlConnection myConnectionTable = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
                    {
                        myConnectionTable.Open();
                        SqlCommand myCmd = new SqlCommand();
                        myCmd.CommandText = " DELETE dbo. ADM_TABLE_LIST WHERE TABLE_NAME=@TABLE_NAME ;INSERT INTO dbo. ADM_TABLE_LIST (TABLE_NAME) VALUES (@TABLE_NAME)";
                        myCmd.Parameters.Add("@TABLE_NAME", SqlDbType.NVarChar); myCmd.Parameters["@TABLE_NAME"].Value = text_DOSYAADI.Text;
                        myCmd.Connection = myConnectionTable;
                        myCmd.ExecuteNonQuery();
                        myCmd.Connection.Close();
                    }
                    using (SqlConnection myConnectionTable = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
                    {
                        string myInsertQuery = " IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + text_DOSYAADI.Text + "]') AND TYPE IN (N'U')) DROP TABLE [dbo].[" + text_DOSYAADI.Text + "] ;   CREATE TABLE  [dbo].[" + text_DOSYAADI.Text + "] (" + TargetNameField + " )  ";//[ID] [int] IDENTITY (1, 1) NOT NULL , 
                        SqlCommand myCommandTable = new SqlCommand(myInsertQuery);
                        myCommandTable.Connection = myConnectionTable;
                        myConnectionTable.Open();
                        myCommandTable.ExecuteNonQuery();
                        myCommandTable.Connection.Close();
                        myConnectionTable.Close();
                    }
                }
                if (RD_DATASIL.Checked || RD_DATAADD.Checked)
                {
                    using (SqlConnection cn = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
                    {
                        cn.Open();
                        using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                        {
                            copy.ColumnMappings.Clear();
                            for (int i = 0; i <= TRADEDATESET.Tables[0].Columns.Count - 1; i++)
                            {
                                copy.ColumnMappings.Add(i, i);
                            }
                            copy.DestinationTableName = text_DOSYAADI.Text;
                            copy.BulkCopyTimeout = 0;
                            for (int i = 0; i <= TRADEDATESET.Tables[0].Columns.Count - 1; i++)
                            {
                                if (dvAcik.Table.Columns[i].DataType.ToString() == "System.DateTime")
                                {
                                    for (int ix = 0; ix <= TRADEDATESET.Tables[0].Rows.Count - 1; ix++)
                                    {
                                        if (TRADEDATESET.Tables[0].Rows[ix][i] != DBNull.Value)
                                        {
                                            TRADEDATESET.Tables[0].Rows[ix][i] = TRADEDATESET.Tables[0].Rows[ix][i].ToString().Replace("1899", "1910");
                                        }
                                    }
                                }
                            }
                            copy.WriteToServer(TRADEDATESET.Tables[0]);
                        }
                    }
                    MessageBox.Show("Dosya Yüklendi.");
                }
                else
                { MessageBox.Show("Yükleme yöntemi seçiniz."); }  
            }
            else
            { MessageBox.Show("DOSYA ADI GİRİNİZ"); }
        }

        private void bt_KAPAT_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GRD_LIST_Click(object sender, EventArgs e)
        {
            int[] selectedRows = GRD_VIEW_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                DataRow dr = GRD_VIEW_LIST.GetDataRow(selectedRows[ix]);
                text_DOSYAADI.Text = dr["TABLE_NAME"].ToString();
            }
            string SQL = "select COLUMN_NAME,DATA_TYPE, CHARACTER_MAXIMUM_LENGTH  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + text_DOSYAADI.Text + "'";
            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                grd_DEFAULT_FIELD.DataSource = dv;
            }
        }
        private void bt_DOSYA_Click(object sender, EventArgs e)
        {
            fDialog.Title = "Open XLS/XLSX File";
            fDialog.Filter = "XLSX Files|*.xlsx|XLSX Files|*.xlsx";
            fDialog.InitialDirectory = Application.ExecutablePath;// @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                grdView_DATA.Columns.Clear();
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fDialog.FileName.ToString() + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";             
                string SQL = "  select  * From  [Sheet1$]";
                OleDbConnection myConnection = new OleDbConnection(strConn.ToString());
                OleDbDataAdapter MySqlDataAdapter = new OleDbDataAdapter(SQL, myConnection);
                TRADEDATESET = new DataSet();
                MySqlDataAdapter.Fill(TRADEDATESET, "dbo_Talepler");
                using (DataViewManager dvManager = new DataViewManager(TRADEDATESET))
                {
                    dvAcik = dvManager.CreateDataView(TRADEDATESET.Tables[0]);
                    toolProgress.ProgressBar.Maximum = dvAcik.Count - 1;
                    toolProgress.ProgressBar.Refresh();
                    grd_DATA.DataSource = dvAcik;
                }
                grd_DATA.RefreshDataSource();
                myConnection.Close();
                myConnection.Dispose();

                DataTable tbl = new DataTable();
                tbl = new DataTable("tbl_HedefKitleler");
                tbl.Columns.Add("FIELD", typeof(string));
                tbl.Columns.Add("TYPE", typeof(string));
                tbl.Columns.Add("SIZE", typeof(string));
                for (int i = 0; i <= dvAcik.Table.Columns.Count - 1; i++)
                {
                    string FIELDS = dvAcik.Table.Columns[i].ColumnName.Replace(".", "").Replace("#", "").Replace("*", "").Replace("\"", "").Replace(")", "").Replace("(", "").Replace("+", "p").Replace("\\", "");
                    string TYPES = null;
                    string SIZES = null;
                    if (dvAcik.Table.Columns[i].DataType.ToString() == "System.String") { TYPES = "nvarchar"; SIZES = "500"; }
                    if (dvAcik.Table.Columns[i].DataType.ToString() == "System.DateTime") TYPES = "smalldatetime";
                    if (dvAcik.Table.Columns[i].DataType.ToString() == "System.Double") TYPES = "float";
                    tbl.Rows.Add(new object[] { FIELDS, TYPES.ToString(), SIZES });
                }
                grd_FIELD.DataSource = tbl;
                //re_Progress.Maximum = gridView_VeriAL.RowCount - 1;
            }
        }

        private void GRD_LIST_DoubleClick(object sender, EventArgs e)
        {

            grd_DATA.DataSource = null;
            grdView_DATA.Columns.Clear();

            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                string SQL = "select top 0 *  from dbo.[" + text_DOSYAADI.Text + "]";

                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                TRADEDATESET = new DataSet();
                MySqlDataAdapter.Fill(TRADEDATESET, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(TRADEDATESET);
                dvAcik = dvManager.CreateDataView(TRADEDATESET.Tables[0]);
                grd_DATA.DataSource = dvAcik;
            }


            grd_DATA_ONIZLEME.DataSource = null;
            grdView_DATA_ONIZLEME.Columns.Clear();

            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                string SQL = "select top 100 *  from dbo.[" + text_DOSYAADI.Text + "]";

                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                TRADEDATESET = new DataSet();
                MySqlDataAdapter.Fill(TRADEDATESET, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(TRADEDATESET);
                dvAcik = dvManager.CreateDataView(TRADEDATESET.Tables[0]);
                grd_DATA_ONIZLEME.DataSource = dvAcik;
            } 

            CmBx_TABLO.Properties.Items.Clear();
            CmBx_TABLO.Text = "";

            using (SqlConnection myConnection = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
            {
                string mySelectQuery = "  SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + text_DOSYAADI.Text + "' AND DATA_TYPE='smalldatetime'";
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                //myCommand.Parameters.Add("@MAIL_ADRESI", SqlDbType.NVarChar); myCommand.Parameters["@MAIL_ADRESI"].Value = "%" + KullaniciKodu.ToString() + "%";
                myConnection.Open();
                using (SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (myReader.Read())
                    {
                        CmBx_TABLO.Properties.Items.Add(myReader["COLUMN_NAME"].ToString());
                        CmBx_TABLO.Text = myReader["COLUMN_NAME"].ToString();
                    }
                }
                myConnection.Close();
            }


        }

        private void MN_TABLO_SIL_Click(object sender, EventArgs e)
        {
            if (text_DOSYAADI.Text.Length > 0)
            {
                using (SqlConnection myConnectionTable = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
                {
                    myConnectionTable.Open();
                    SqlCommand myCmd = new SqlCommand();
                    myCmd.CommandText = " DELETE dbo. ADM_TABLE_LIST WHERE TABLE_NAME=@TABLE_NAME ";
                    myCmd.Parameters.Add("@TABLE_NAME", SqlDbType.NVarChar); myCmd.Parameters["@TABLE_NAME"].Value = text_DOSYAADI.Text;
                    myCmd.Connection = myConnectionTable;
                    myCmd.ExecuteNonQuery();
                    myCmd.Connection.Close();
                }
                using (SqlConnection myConnectionTable = new SqlConnection(GLOBAL_PARAMETRELER._CONNECTION_STRING.ToString()))
                {
                    string myInsertQuery =
                         " IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + text_DOSYAADI.Text + "]') AND TYPE IN (N'U')) DROP TABLE [dbo].[" + text_DOSYAADI.Text + "] ;   ";//[ID] [int] IDENTITY (1, 1) NOT NULL , 

                    SqlCommand myCommandTable = new SqlCommand(myInsertQuery);
                    myCommandTable.Connection = myConnectionTable;
                    myConnectionTable.Open();
                    myCommandTable.ExecuteNonQuery();
                    myCommandTable.Connection.Close();
                    myConnectionTable.Close();
                }

                TABLE_READ();
                text_DOSYAADI.Text = "";
                MessageBox.Show("TAMAMLANDI");
            }
        }

        private void CN_MN_TOOL_KOPYALA_Click(object sender, EventArgs e)
        {
            grdView_DATA.CopyToClipboard();
        }
        string ClipboardData
        {
            get
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData == null) return "";

                if (iData.GetDataPresent(DataFormats.Text))
                    return (string)iData.GetData(DataFormats.Text);
                return "";
            }
            set { Clipboard.SetDataObject(value); }
        }

        //DataTable tbl;
        private void _PASTE()
        {
            tbl = null;
            tbl = new DataTable();
            tbl.TableName = "ImportedTable";
            List<string> data = new List<string>(ClipboardData.Split('\n'));
            bool firstRow = true;

            if (data.Count > 0 && string.IsNullOrWhiteSpace(data[data.Count - 1]))
            {
                data.RemoveAt(data.Count - 1);
            }

            foreach (string iterationRow in data)
            {
                string row = iterationRow;
                if (row.EndsWith("\r"))
                {
                    row = row.Substring(0, row.Length - "\r".Length);
                }

                string[] rowData = row.Split(new char[] { '\r', '\x09' });
                DataRow newRow = tbl.NewRow();
                if (firstRow)
                {
                    int colNumber = 0;
                    foreach (string value in rowData)
                    {
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            tbl.Columns.Add(string.Format("[BLANK{0}]", colNumber));
                        }
                        else if (!tbl.Columns.Contains(value))
                        {
                            tbl.Columns.Add(value);
                        }
                        else
                        {
                            tbl.Columns.Add(string.Format("Column {0}", colNumber));
                        }
                        colNumber++;
                    }
                    firstRow = false;
                }
                else
                {
                    for (int i = 0; i < rowData.Length; i++)
                    {
                        if (i >= tbl.Columns.Count) break;
                        newRow[i] = rowData[i];
                    }
                    tbl.Rows.Add(newRow);
                }
            }

        }
        private void CN_MN_TOOL_YAPISTIR_Click(object sender, EventArgs e)
        {
            _PASTE();
            try
            {
                for (int x = 0; x <= tbl.Rows.Count - 1; x++)
                {
                    DataRow rowm = tbl.Rows[x];
                    DataRow rows = dvAcik.Table.NewRow();

                    for (int XZ = 0; XZ <= tbl.Columns.Count - 1; XZ++)
                    {
                        //if (tbl.Columns[XZ].ColumnName != "Prg End time")
                        //{
                        ///  DateTime tm= DateTime.Parse(rowm[tbl.Columns[XZ].ColumnName].ToString ()); 
                        ///  

                        if (rowm[tbl.Columns[XZ].ColumnName].ToString() != string.Empty) rows[tbl.Columns[XZ].ColumnName.Trim()] = rowm[tbl.Columns[XZ].ColumnName].ToString().Replace("24:", "00:").Replace("25:", "02:").Replace("26:", "03:");

                        //}
                    }
                    dvAcik.Table.Rows.Add(rows);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            grd_DATA.DataSource = dvAcik.Table;

            grdView_DATA.RefreshData();
        }
    }
}