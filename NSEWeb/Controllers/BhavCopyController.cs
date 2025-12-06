using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSEDAL.Entities;
using NSEWeb.UIHelpers;
using NuGet.Protocol;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace NSEWeb.Controllers
{
    public class BhavCopyController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BhavCopyController(IConfiguration config, IWebHostEnvironment webHostEnvironment) : base(config)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: SyncBhavCopy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            var result = SqlHelper.ExecuteDataSet<BhavCopyStatusModel>(base.ConnectionString, "EXEC dbo.spSyncBhavCopy @TypeId = 1");
            return Json(result);
        }

        public async Task<ActionResult> SyncNowAsync(BhavCopyStatusModel model)
        {
            string saveFolderPath = $"{_webHostEnvironment.ContentRootPath}\\Download";
            var fileDownloader = new FileDownloader();
            await fileDownloader.DownloadFileAsync(model.SyncURL, saveFolderPath);

            //Data reading
            var dt = fileDownloader.ReadCsvFile(fileDownloader.filePath.Replace(".zip", ""));

            InsertBhavCopyRecords(dt);

            DeleteOldDownloadedFiles(saveFolderPath);

            return Content("");
        }

        private static void DeleteOldDownloadedFiles(string saveFolderPath)
        {
            try
            {
                foreach (var f in Directory.GetFiles(saveFolderPath))
                {
                    if (new FileInfo(f).CreationTime <= DateTime.UtcNow.AddDays(-3))
                    {
                        System.IO.File.Delete(f);
                    }
                }
            }
            catch (Exception) { }
        }

        private void InsertBhavCopyRecords(DataTable csvdt)
        {
            if (csvdt == null) return;

            SqlConnection conn = new SqlConnection(base.ConnectionString);
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
            finally
            {
                conn.Dispose();
            }



        }

    }
}
