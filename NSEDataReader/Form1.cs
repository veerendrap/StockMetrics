using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO.Compression;
using NSEDataReader.Helpers;
using System.Configuration;

namespace NSEDataReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Common
        public string DBConnectionString
        {
            get
            {
                return cmbConnectionString.Text.Trim();
            }
        }

        private DataSet ExecuteDataSet(string sqlQuery)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(DBConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter ada = new SqlDataAdapter(sqlQuery, conn);
                ada.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Dispose();
            }
            return ds;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            var now = DateTime.Now.AddMonths(-6);
            dtFromDate.Value = new DateTime(now.Year, now.Month, 1);

            // var connectionString = ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString;
            ConnectionStringSettingsCollection conStrs = ConfigurationManager.ConnectionStrings;

            cmbConnectionString.Items.Clear();
            foreach (var cStr in conStrs)
            {
                cmbConnectionString.Items.Add(cStr.ToString());
            }

            if (cmbConnectionString.Items.Count > 0)
                cmbConnectionString.SelectedIndex = 0;

        }


        #region Bhav Copy
        private void btnSyncSelectedBhavCopy_Click(object sender, EventArgs e)
        {
            DownloadBhavCopyAndSync(true);
        }

        private void btnSyncAllBhavCopy_Click(object sender, EventArgs e)
        {
            DownloadBhavCopyAndSync(false);
        }

        private void DownloadBhavCopyAndSync(bool isSyncOnlySelected)
        {
            string path = Directory.GetCurrentDirectory() + @"\Download\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (DataGridViewRow dRow in dataGridView1.Rows)
            {
                if (isSyncOnlySelected == true && dRow.Selected == false)
                {
                    continue; // skip to check next selected record
                }
                else if (dRow.Cells["StatusName"].Value.ToString() == "Synced")
                {
                    continue;//Skip if already Synced
                }

                string syncURL = dRow.Cells["SyncURL"].Value.ToString();
                string SyncFileName = dRow.Cells["SyncFileName"].Value.ToString();
                string bhavCopyfilepath = path + SyncFileName;
                if (!File.Exists(bhavCopyfilepath))
                {
                    using (var client = new WebClient())
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons
                        try
                        {
                            client.DownloadFile(syncURL, bhavCopyfilepath);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                string ExtractPathString = path + @"Extract\";
                try
                {
                    ZipFile.ExtractToDirectory(bhavCopyfilepath, ExtractPathString);
                }
                catch (Exception ex)
                {

                }

                //Data reading

                var dt = ReadCsvFile(ExtractPathString + SyncFileName.Replace(".zip", ""));
                InsertCSVRecords(dt);


            }

            LoadGridForBhovCopy();
        }

        private void InsertCSVRecords(DataTable csvdt)
        {
            if (csvdt == null)
            {
                return;
            }

            SqlConnection conn = new SqlConnection(DBConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EXEC dbo.spSyncBhavCopy @TypeId = 2", conn);
                cmd.ExecuteNonQuery();

                SqlBulkCopy objbulk = new SqlBulkCopy(conn);
                //assigning Destination table name    
                objbulk.DestinationTableName = "BhavCopyCSVStaging";
                objbulk.BulkCopyTimeout = conn.ConnectionTimeout;

                //Mapping Table column    
                objbulk.ColumnMappings.Add("SYMBOL", "SYMBOL");
                objbulk.ColumnMappings.Add("SERIES", "SERIES");
                objbulk.ColumnMappings.Add("OPEN", "OPEN");
                objbulk.ColumnMappings.Add("HIGH", "HIGH");

                objbulk.ColumnMappings.Add("LOW", "LOW");
                objbulk.ColumnMappings.Add("CLOSE", "CLOSE");
                objbulk.ColumnMappings.Add("LAST", "LAST");
                objbulk.ColumnMappings.Add("PREVCLOSE", "PREVCLOSE");
                objbulk.ColumnMappings.Add("TOTTRDQTY", "TOTTRDQTY");

                objbulk.ColumnMappings.Add("TOTTRDVAL", "TOTTRDVAL");
                objbulk.ColumnMappings.Add("TIMESTAMP", "TIMESTAMP");
                objbulk.ColumnMappings.Add("TOTALTRADES", "TOTALTRADES");
                objbulk.ColumnMappings.Add("ISIN", "ISIN");

                objbulk.WriteToServer(csvdt);

                SqlCommand cmdStagToMain = new SqlCommand("EXEC dbo.spSyncBhavCopy @TypeId = 3", conn);
                cmdStagToMain.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Dispose();
            }



        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadGridForBhovCopy();
        }

        private void LoadGridForBhovCopy()
        {
            DataSet ds = ExecuteDataSet("EXEC dbo.spSyncBhavCopy @TypeId = 1");
            dataGridView1.DataSource = ds.Tables[0];
        }

        public DataTable ReadCsvFile(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                return null;
            }

            DataTable dtCsv = new DataTable();
            string Fulltext;

            using (StreamReader sr = new StreamReader(csvFilePath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    dtCsv.Columns.Add(rowValues[j].Trim()); //add headers  
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr); //add other rows  
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }

        #endregion

        #region Delivery Data 
        private void btnDelLoad_Click(object sender, EventArgs e)
        {
            LoadGridDeliveryData();
        }

        private void LoadGridDeliveryData()
        {
            DataSet ds = ExecuteDataSet("EXEC dbo.spSyncDeliveryData @TypeId = 1");
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void btnDelSync_Click(object sender, EventArgs e)
        {
            DownloadDeliveryDataAndSync(false);
        }

        private void DownloadDeliveryDataAndSync(bool isSyncOnlySelected)
        {
            string path = Directory.GetCurrentDirectory() + @"\Download2\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            foreach (DataGridViewRow dRow in dataGridView2.Rows)
            {
                if (isSyncOnlySelected == true && dRow.Selected == false)
                {
                    continue; // skip to check next selected record
                }
                else if (dRow.Cells["StatusName"].Value.ToString() == "Synced")
                {
                    continue;//Skip if already Synced
                }

                string syncURL = dRow.Cells["SyncURL"].Value.ToString();
                string SyncFileName = dRow.Cells["SyncFileName"].Value.ToString();
                string bhavCopyfilepath = path + SyncFileName;
                if (!File.Exists(bhavCopyfilepath))
                {
                    using (var client = new WebClient())
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons
                        try
                        {
                            client.DownloadFile(syncURL, bhavCopyfilepath);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                //Data reading
                var dt = ReadDelDataFile(bhavCopyfilepath);
                InsertDeliveryData(dt);
            }

            LoadGridDeliveryData();
        }


        private void InsertDeliveryData(DataTable csvdt)
        {
            if (csvdt == null)
            {
                return;
            }

            SqlConnection conn = new SqlConnection(DBConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EXEC dbo.spSyncDeliveryData @TypeId = 2", conn);
                cmd.ExecuteNonQuery();//--

                SqlBulkCopy objbulk = new SqlBulkCopy(conn);
                //assigning Destination table name    
                objbulk.DestinationTableName = "DeliveryDataStaging";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("TradeDate", "TradeDate");
                objbulk.ColumnMappings.Add("RecordType", "RecordType");
                objbulk.ColumnMappings.Add("SrNo", "SrNo");
                objbulk.ColumnMappings.Add("NameofSecurity", "NameofSecurity");

                objbulk.ColumnMappings.Add("Series", "Series");
                objbulk.ColumnMappings.Add("QuantityTraded", "QuantityTraded");
                objbulk.ColumnMappings.Add("DeliverableQuantity_GrossAcrossClientLevel", "DeliverableQuantity_GrossAcrossClientLevel");
                objbulk.ColumnMappings.Add("PerofDeliverableQuantityToTradedQuantity", "PerofDeliverableQuantityToTradedQuantity");

                objbulk.WriteToServer(csvdt);

                SqlCommand cmdStagToMain = new SqlCommand("EXEC dbo.spSyncDeliveryData @TypeId = 3", conn);
                cmdStagToMain.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Dispose();
            }



        }

        public DataTable ReadDelDataFile(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                return null;
            }

            DataTable dtCsv = new DataTable();
            dtCsv.Columns.Add("TradeDate");
            dtCsv.Columns.Add("RecordType");
            dtCsv.Columns.Add("SrNo");
            dtCsv.Columns.Add("NameofSecurity");
            dtCsv.Columns.Add("Series");
            dtCsv.Columns.Add("QuantityTraded");
            dtCsv.Columns.Add("DeliverableQuantity_GrossAcrossClientLevel");
            dtCsv.Columns.Add("PerofDeliverableQuantityToTradedQuantity");

            string Fulltext;
            string tradedDate = "";
            using (StreamReader sr = new StreamReader(csvFilePath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {
                            if (i == 2)
                            {
                                tradedDate = rowValues[0].ToString();
                            }
                            else if (i >= 4)
                            {
                                DataRow dr = dtCsv.NewRow();
                                dr[0] = tradedDate;
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k + 1] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr); //add other rows  
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }




        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog fb = new SaveFileDialog();
            fb.FileName = @"StockData_From_" + dtFromDate.Value.ToString("ddMMMyyyy") + ".csv";
            fb.AddExtension = true;
            fb.DefaultExt = ".csv";

            var fbResult = fb.ShowDialog();

            if (DialogResult.OK == fbResult)
            {
                DataSet ds = ExecuteDataSet("EXEC dbo.spGetCompleteData @FromDate = '" + dtFromDate.Value.ToString("yyyy-MMM-dd") + "'");
                ds.Tables[0].DownloadToCSV(fb.FileName);
                MessageBox.Show("Downloaded Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDownloadActionRatioMatrix_Click(object sender, EventArgs e)
        {
            SaveFileDialog fb = new SaveFileDialog();
            fb.FileName = @"StockActionMatrix_From_" + dtFromDate.Value.ToString("ddMMMyyyy") + ".csv";
            fb.AddExtension = true;
            fb.DefaultExt = ".csv";

            var fbResult = fb.ShowDialog();

            if (DialogResult.OK == fbResult)
            {
                DataSet ds = ExecuteDataSet("EXEC dbo.spGetCompleteData @FromDate = '" + dtFromDate.Value.ToString("yyyy-MMM-dd") + "', @TypeId = 2");
                ds.Tables[0].DownloadToCSV(fb.FileName);
                MessageBox.Show("Downloaded Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSyncSelectedDeliveryData_Click(object sender, EventArgs e)
        {
            DownloadDeliveryDataAndSync(true);
        }
        #endregion

        private void btnNseOILoad_Click(object sender, EventArgs e)
        {
            LoadGridNSEOIData();
        }

        private void LoadGridNSEOIData()
        {
            DataSet ds = ExecuteDataSet("EXEC dbo.spSyncNSEOIData @TypeId = 1");
            grdNSEOI.DataSource = ds.Tables[0];
        }

        private void btnSelectedNSEIOSync_Click(object sender, EventArgs e)
        {
            DownloadNseOIDataAndSync(true);
        }

        private void btnSyncAllNSEOIData_Click(object sender, EventArgs e)
        {
            DownloadNseOIDataAndSync(false);
        }


        private void DownloadNseOIDataAndSync(bool isSyncOnlySelected)
        {
            string path = Directory.GetCurrentDirectory() + @"\NseOIDownload\";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            foreach (DataGridViewRow dRow in grdNSEOI.Rows)
            {
                if (isSyncOnlySelected == true && dRow.Selected == false)
                {
                    continue; // skip to check next selected record
                }
                else if (dRow.Cells["StatusName"].Value.ToString() == "Synced")
                {
                    continue;//Skip if already Synced
                }

                string syncURL = dRow.Cells["SyncURL"].Value.ToString();
                string SyncFileName = dRow.Cells["SyncFileName"].Value.ToString();
                string filepath = path + SyncFileName;
                if (!File.Exists(filepath))
                {
                    using (var client = new WebClient())
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons
                        try
                        {
                            client.DownloadFile(syncURL, filepath);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                string ExtractPathString = path + @"Extract\";
                try
                {
                    ZipFile.ExtractToDirectory(filepath, ExtractPathString);
                }
                catch (Exception ex)
                {

                }
                //Data reading
                var dt = ReadCsvFile(ExtractPathString + SyncFileName.Replace(".zip", ".csv"));
                InsertNseOIData(dt);
            }

            LoadGridNSEOIData();
        }

        private void InsertNseOIData(DataTable csvdt)
        {
            if (csvdt == null)
            {
                return;
            }

            SqlConnection conn = new SqlConnection(DBConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EXEC dbo.spSyncNSEOIData @TypeId = 2", conn);
                cmd.ExecuteNonQuery();//--

                SqlBulkCopy objbulk = new SqlBulkCopy(conn);
                //assigning Destination table name    
                objbulk.DestinationTableName = "NseOIDataStaging";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("Date", "Date");
                objbulk.ColumnMappings.Add("ISIN", "ISIN");
                objbulk.ColumnMappings.Add("Scrip Name", "Scrip Name");
                objbulk.ColumnMappings.Add("NSE Symbol", "NSE Symbol");

                objbulk.ColumnMappings.Add("MWPL", "MWPL");
                objbulk.ColumnMappings.Add("NSE Open Interest", "NSE Open Interest");
                objbulk.WriteToServer(csvdt);

                SqlCommand cmdStagToMain = new SqlCommand("EXEC dbo.spSyncNSEOIData @TypeId = 3", conn);
                cmdStagToMain.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Dispose();
            }
        }

    }
}