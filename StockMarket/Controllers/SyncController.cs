using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSEDAL.Entities;

namespace StockMarket.Controllers
{
    public class SyncController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SyncController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BhavCopy()
        {
            IEnumerable<dynamic> rows;
            using (var db = new DapperContext(_connectionString).CreateConnection())
            {
                rows = db.Query("EXEC dbo.spSyncBhavCopy @TypeId = 1");
            }
            return View(rows);
        }

        public IActionResult Delivery()
        {
            IEnumerable<dynamic> rows;
            using (var db = new DapperContext(_connectionString).CreateConnection())
            {
                rows = db.Query("EXEC dbo.spSyncDeliveryData @TypeId = 1");
            }
            return View(rows);
        }

        public IActionResult NseOI()
        {
            IEnumerable<dynamic> rows;
            using (var db = new DapperContext(_connectionString).CreateConnection())
            {
                rows = db.Query("EXEC dbo.spSyncNSEOIData @TypeId = 1");
            }
            return View(rows);
        }

        [HttpGet]
        public IActionResult DownloadCompleteData(string fromDate)
        {
            // fromDate expected in yyyy-MMM-dd or empty for default
            var param = string.IsNullOrEmpty(fromDate) ? DateTime.Now.AddMonths(-6).ToString("yyyy-MMM-dd") : fromDate;
            IEnumerable<dynamic> rows;
            using (var db = new DapperContext(_connectionString).CreateConnection())
            {
                rows = db.Query($"EXEC dbo.spGetCompleteData @FromDate = '{param}'");
            }

            var csv = BuildCsv(rows);
            var bytes = Encoding.UTF8.GetBytes(csv);
            return File(bytes, "text/csv", $"StockData_From_{param}.csv");
        }

        private string BuildCsv(IEnumerable<dynamic> rows)
        {
            var sb = new StringBuilder();
            var list = rows.ToList();
            if (!list.Any()) return string.Empty;

            var first = list.First() as IDictionary<string, object>;
            var headers = first.Keys;
            sb.AppendLine(string.Join(",", headers));

            foreach (IDictionary<string, object> row in list)
            {
                var values = headers.Select(h => EscapeCsv(row.ContainsKey(h) && row[h] != null ? row[h].ToString() : string.Empty));
                sb.AppendLine(string.Join(",", values));
            }

            return sb.ToString();
        }

        private string EscapeCsv(string s)
        {
            if (s == null) return string.Empty;
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n") || s.Contains("\r"))
            {
                return '"' + s.Replace("\"", "\"\"") + '"';
            }
            return s;
        }
    }
}
