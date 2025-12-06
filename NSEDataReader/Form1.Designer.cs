namespace NSEDataReader
{
    partial class Form1
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
            this.tblMain = new System.Windows.Forms.TabControl();
            this.tabBhavCopy = new System.Windows.Forms.TabPage();
            this.btnSyncSelectedBhavCopy = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSyncAllBhavCopy = new System.Windows.Forms.Button();
            this.tabDeliveryData = new System.Windows.Forms.TabPage();
            this.btnSyncSelectedDeliveryData = new System.Windows.Forms.Button();
            this.btnDelLoad = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnDelSync = new System.Windows.Forms.Button();
            this.tabNSEOI = new System.Windows.Forms.TabPage();
            this.btnSelectedNSEIOSync = new System.Windows.Forms.Button();
            this.btnNseOILoad = new System.Windows.Forms.Button();
            this.grdNSEOI = new System.Windows.Forms.DataGridView();
            this.btnSyncAllNSEOIData = new System.Windows.Forms.Button();
            this.tabDBConnection = new System.Windows.Forms.TabPage();
            this.grpDBConnectionString = new System.Windows.Forms.GroupBox();
            this.cmbConnectionString = new System.Windows.Forms.ComboBox();
            this.btnGetAllBhavCopySync = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnDownloadActionRatioMatrix = new System.Windows.Forms.Button();
            this.tblMain.SuspendLayout();
            this.tabBhavCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabDeliveryData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabNSEOI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNSEOI)).BeginInit();
            this.tabDBConnection.SuspendLayout();
            this.grpDBConnectionString.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMain.Controls.Add(this.tabBhavCopy);
            this.tblMain.Controls.Add(this.tabDeliveryData);
            this.tblMain.Controls.Add(this.tabNSEOI);
            this.tblMain.Controls.Add(this.tabDBConnection);
            this.tblMain.Location = new System.Drawing.Point(13, 101);
            this.tblMain.Name = "tblMain";
            this.tblMain.SelectedIndex = 0;
            this.tblMain.Size = new System.Drawing.Size(716, 407);
            this.tblMain.TabIndex = 0;
            // 
            // tabBhavCopy
            // 
            this.tabBhavCopy.Controls.Add(this.btnSyncSelectedBhavCopy);
            this.tabBhavCopy.Controls.Add(this.btnLoad);
            this.tabBhavCopy.Controls.Add(this.dataGridView1);
            this.tabBhavCopy.Controls.Add(this.btnSyncAllBhavCopy);
            this.tabBhavCopy.Location = new System.Drawing.Point(4, 22);
            this.tabBhavCopy.Name = "tabBhavCopy";
            this.tabBhavCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tabBhavCopy.Size = new System.Drawing.Size(708, 381);
            this.tabBhavCopy.TabIndex = 0;
            this.tabBhavCopy.Text = "BhavCopy Sync";
            this.tabBhavCopy.UseVisualStyleBackColor = true;
            // 
            // btnSyncSelectedBhavCopy
            // 
            this.btnSyncSelectedBhavCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncSelectedBhavCopy.Location = new System.Drawing.Point(299, 6);
            this.btnSyncSelectedBhavCopy.Name = "btnSyncSelectedBhavCopy";
            this.btnSyncSelectedBhavCopy.Size = new System.Drawing.Size(194, 29);
            this.btnSyncSelectedBhavCopy.TabIndex = 3;
            this.btnSyncSelectedBhavCopy.Text = "Sync Selected Bhav Copy";
            this.btnSyncSelectedBhavCopy.UseVisualStyleBackColor = true;
            this.btnSyncSelectedBhavCopy.Click += new System.EventHandler(this.btnSyncSelectedBhavCopy_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(193, 6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 29);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(681, 323);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSyncAllBhavCopy
            // 
            this.btnSyncAllBhavCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncAllBhavCopy.Location = new System.Drawing.Point(499, 6);
            this.btnSyncAllBhavCopy.Name = "btnSyncAllBhavCopy";
            this.btnSyncAllBhavCopy.Size = new System.Drawing.Size(194, 29);
            this.btnSyncAllBhavCopy.TabIndex = 0;
            this.btnSyncAllBhavCopy.Text = "Sync All Bhav Copy";
            this.btnSyncAllBhavCopy.UseVisualStyleBackColor = true;
            this.btnSyncAllBhavCopy.Click += new System.EventHandler(this.btnSyncAllBhavCopy_Click);
            // 
            // tabDeliveryData
            // 
            this.tabDeliveryData.Controls.Add(this.btnSyncSelectedDeliveryData);
            this.tabDeliveryData.Controls.Add(this.btnDelLoad);
            this.tabDeliveryData.Controls.Add(this.dataGridView2);
            this.tabDeliveryData.Controls.Add(this.btnDelSync);
            this.tabDeliveryData.Location = new System.Drawing.Point(4, 22);
            this.tabDeliveryData.Name = "tabDeliveryData";
            this.tabDeliveryData.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeliveryData.Size = new System.Drawing.Size(708, 381);
            this.tabDeliveryData.TabIndex = 2;
            this.tabDeliveryData.Text = "Delivery data sync";
            this.tabDeliveryData.UseVisualStyleBackColor = true;
            // 
            // btnSyncSelectedDeliveryData
            // 
            this.btnSyncSelectedDeliveryData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncSelectedDeliveryData.Location = new System.Drawing.Point(277, 6);
            this.btnSyncSelectedDeliveryData.Name = "btnSyncSelectedDeliveryData";
            this.btnSyncSelectedDeliveryData.Size = new System.Drawing.Size(194, 29);
            this.btnSyncSelectedDeliveryData.TabIndex = 6;
            this.btnSyncSelectedDeliveryData.Text = "Sync Selected Delivery Data";
            this.btnSyncSelectedDeliveryData.UseVisualStyleBackColor = true;
            this.btnSyncSelectedDeliveryData.Click += new System.EventHandler(this.btnSyncSelectedDeliveryData_Click);
            // 
            // btnDelLoad
            // 
            this.btnDelLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLoad.Location = new System.Drawing.Point(162, 6);
            this.btnDelLoad.Name = "btnDelLoad";
            this.btnDelLoad.Size = new System.Drawing.Size(82, 29);
            this.btnDelLoad.TabIndex = 5;
            this.btnDelLoad.Text = "Load";
            this.btnDelLoad.UseVisualStyleBackColor = true;
            this.btnDelLoad.Click += new System.EventHandler(this.btnDelLoad_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 48);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(678, 363);
            this.dataGridView2.TabIndex = 4;
            // 
            // btnDelSync
            // 
            this.btnDelSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSync.Location = new System.Drawing.Point(499, 6);
            this.btnDelSync.Name = "btnDelSync";
            this.btnDelSync.Size = new System.Drawing.Size(194, 29);
            this.btnDelSync.TabIndex = 3;
            this.btnDelSync.Text = "Get Sync Del Files";
            this.btnDelSync.UseVisualStyleBackColor = true;
            this.btnDelSync.Click += new System.EventHandler(this.btnDelSync_Click);
            // 
            // tabNSEOI
            // 
            this.tabNSEOI.Controls.Add(this.btnSelectedNSEIOSync);
            this.tabNSEOI.Controls.Add(this.btnNseOILoad);
            this.tabNSEOI.Controls.Add(this.grdNSEOI);
            this.tabNSEOI.Controls.Add(this.btnSyncAllNSEOIData);
            this.tabNSEOI.Location = new System.Drawing.Point(4, 22);
            this.tabNSEOI.Name = "tabNSEOI";
            this.tabNSEOI.Padding = new System.Windows.Forms.Padding(3);
            this.tabNSEOI.Size = new System.Drawing.Size(708, 381);
            this.tabNSEOI.TabIndex = 3;
            this.tabNSEOI.Text = "NSE OI Data";
            this.tabNSEOI.UseVisualStyleBackColor = true;
            // 
            // btnSelectedNSEIOSync
            // 
            this.btnSelectedNSEIOSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectedNSEIOSync.Location = new System.Drawing.Point(299, 8);
            this.btnSelectedNSEIOSync.Name = "btnSelectedNSEIOSync";
            this.btnSelectedNSEIOSync.Size = new System.Drawing.Size(194, 29);
            this.btnSelectedNSEIOSync.TabIndex = 7;
            this.btnSelectedNSEIOSync.Text = "Sync Selected NSE OI Data";
            this.btnSelectedNSEIOSync.UseVisualStyleBackColor = true;
            this.btnSelectedNSEIOSync.Click += new System.EventHandler(this.btnSelectedNSEIOSync_Click);
            // 
            // btnNseOILoad
            // 
            this.btnNseOILoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNseOILoad.Location = new System.Drawing.Point(211, 8);
            this.btnNseOILoad.Name = "btnNseOILoad";
            this.btnNseOILoad.Size = new System.Drawing.Size(82, 29);
            this.btnNseOILoad.TabIndex = 6;
            this.btnNseOILoad.Text = "Load";
            this.btnNseOILoad.UseVisualStyleBackColor = true;
            this.btnNseOILoad.Click += new System.EventHandler(this.btnNseOILoad_Click);
            // 
            // grdNSEOI
            // 
            this.grdNSEOI.AllowUserToAddRows = false;
            this.grdNSEOI.AllowUserToDeleteRows = false;
            this.grdNSEOI.AllowUserToOrderColumns = true;
            this.grdNSEOI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNSEOI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdNSEOI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNSEOI.Location = new System.Drawing.Point(14, 50);
            this.grdNSEOI.Margin = new System.Windows.Forms.Padding(30);
            this.grdNSEOI.Name = "grdNSEOI";
            this.grdNSEOI.ReadOnly = true;
            this.grdNSEOI.Size = new System.Drawing.Size(681, 323);
            this.grdNSEOI.TabIndex = 5;
            // 
            // btnSyncAllNSEOIData
            // 
            this.btnSyncAllNSEOIData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncAllNSEOIData.Location = new System.Drawing.Point(501, 8);
            this.btnSyncAllNSEOIData.Name = "btnSyncAllNSEOIData";
            this.btnSyncAllNSEOIData.Size = new System.Drawing.Size(194, 29);
            this.btnSyncAllNSEOIData.TabIndex = 4;
            this.btnSyncAllNSEOIData.Text = "Sync All NSE OI Data";
            this.btnSyncAllNSEOIData.UseVisualStyleBackColor = true;
            this.btnSyncAllNSEOIData.Click += new System.EventHandler(this.btnSyncAllNSEOIData_Click);
            // 
            // tabDBConnection
            // 
            this.tabDBConnection.Controls.Add(this.grpDBConnectionString);
            this.tabDBConnection.Location = new System.Drawing.Point(4, 22);
            this.tabDBConnection.Name = "tabDBConnection";
            this.tabDBConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBConnection.Size = new System.Drawing.Size(708, 381);
            this.tabDBConnection.TabIndex = 1;
            this.tabDBConnection.Text = "DB Connection String";
            this.tabDBConnection.UseVisualStyleBackColor = true;
            // 
            // grpDBConnectionString
            // 
            this.grpDBConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDBConnectionString.Controls.Add(this.cmbConnectionString);
            this.grpDBConnectionString.Location = new System.Drawing.Point(15, 16);
            this.grpDBConnectionString.Name = "grpDBConnectionString";
            this.grpDBConnectionString.Size = new System.Drawing.Size(671, 61);
            this.grpDBConnectionString.TabIndex = 1;
            this.grpDBConnectionString.TabStop = false;
            this.grpDBConnectionString.Text = "DB Connection String";
            // 
            // cmbConnectionString
            // 
            this.cmbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConnectionString.FormattingEnabled = true;
            this.cmbConnectionString.Location = new System.Drawing.Point(16, 19);
            this.cmbConnectionString.Name = "cmbConnectionString";
            this.cmbConnectionString.Size = new System.Drawing.Size(636, 21);
            this.cmbConnectionString.TabIndex = 1;
            // 
            // btnGetAllBhavCopySync
            // 
            this.btnGetAllBhavCopySync.Location = new System.Drawing.Point(0, 0);
            this.btnGetAllBhavCopySync.Name = "btnGetAllBhavCopySync";
            this.btnGetAllBhavCopySync.Size = new System.Drawing.Size(75, 23);
            this.btnGetAllBhavCopySync.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(516, 12);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(209, 29);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download Data Dump";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.Location = new System.Drawing.Point(373, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(137, 20);
            this.dtFromDate.TabIndex = 2;
            this.dtFromDate.Value = new System.DateTime(2022, 11, 1, 0, 0, 0, 0);
            // 
            // btnDownloadActionRatioMatrix
            // 
            this.btnDownloadActionRatioMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadActionRatioMatrix.Location = new System.Drawing.Point(516, 47);
            this.btnDownloadActionRatioMatrix.Name = "btnDownloadActionRatioMatrix";
            this.btnDownloadActionRatioMatrix.Size = new System.Drawing.Size(209, 29);
            this.btnDownloadActionRatioMatrix.TabIndex = 3;
            this.btnDownloadActionRatioMatrix.Text = "Download Action Matrix";
            this.btnDownloadActionRatioMatrix.UseVisualStyleBackColor = true;
            this.btnDownloadActionRatioMatrix.Click += new System.EventHandler(this.btnDownloadActionRatioMatrix_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::NSEDataReader.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(741, 508);
            this.Controls.Add(this.btnDownloadActionRatioMatrix);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.tblMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NSE Data Utility";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tblMain.ResumeLayout(false);
            this.tabBhavCopy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabDeliveryData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabNSEOI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNSEOI)).EndInit();
            this.tabDBConnection.ResumeLayout(false);
            this.grpDBConnectionString.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tblMain;
        private System.Windows.Forms.TabPage tabBhavCopy;
        private System.Windows.Forms.TabPage tabDBConnection;
        private System.Windows.Forms.GroupBox grpDBConnectionString;
        private System.Windows.Forms.Button btnGetAllBhavCopySync;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TabPage tabDeliveryData;
        private System.Windows.Forms.Button btnDelLoad;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnDelSync;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnDownloadActionRatioMatrix;
        private System.Windows.Forms.Button btnSyncAllBhavCopy;
        private System.Windows.Forms.Button btnSyncSelectedBhavCopy;
        private System.Windows.Forms.Button btnSyncSelectedDeliveryData;
        private System.Windows.Forms.TabPage tabNSEOI;
        private System.Windows.Forms.Button btnSelectedNSEIOSync;
        private System.Windows.Forms.Button btnNseOILoad;
        private System.Windows.Forms.DataGridView grdNSEOI;
        private System.Windows.Forms.Button btnSyncAllNSEOIData;
        private System.Windows.Forms.ComboBox cmbConnectionString;
    }
}

