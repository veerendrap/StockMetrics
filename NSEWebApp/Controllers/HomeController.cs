using Microsoft.AspNetCore.Mvc;
using NSEDAL.Entities;
using NSEWebApp.Models;
using System.Diagnostics;

namespace NSEWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration) : base(configuration)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAdvanceDeclineRatio()
        {
            var result = SqlHelper.ExecuteDataSet<AdvanceDeclineModel>(base.ConnectionString, "EXEC spGetCompleteData @FromDate='2023-08-01', @TypeId=10, @StockType = 'ALL'");
            
            var finalResult = new
            {
                categories = result.Select(o => o.Sector + $" [{o.Advanced + o.Declined + o.NoChange}]"),
                advancedCount = result.Select(o => o.Advanced),
                declinedCount = result.Select(o => o.Declined),
                noChangeCount = result.Select(o=> o.NoChange),
            };
            return Json(finalResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}