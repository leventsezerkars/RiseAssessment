using Microsoft.AspNetCore.Mvc;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;

namespace RiseAssessment.FrontEnd.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocationReportService _reportService;
        private readonly ILocationReportDetailService _reportDetailService;

        public ReportController(ILogger<HomeController> logger, ILocationReportService reportService, ILocationReportDetailService reportDetailService)
        {
            _logger = logger;
            _reportService = reportService;
            _reportDetailService = reportDetailService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _reportService.GetAllAsync());
        }

        public async Task<IActionResult> Detail(string id)
        {
            var model = new LocationReportDetailViewModel();
            var report = await _reportService.GetById(id);
            var details = await _reportDetailService.GetAllByReportIdAsync(id);
            model.Report = report;
            model.Details = details;
            return View(model);
        }

        public async Task<IActionResult> CreateReport()
        {
            var result = await _reportService.CreateAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}