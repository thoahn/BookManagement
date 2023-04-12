using BookManagement.Web.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetReportList()
        {
            var result = await _reportService.GetList();

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> SaveReport()
        {
            var result = await _reportService.SaveReport();

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> GetReportData(Guid id)
        {
            var result = await _reportService.GetReportData(id);

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }
    }
}
