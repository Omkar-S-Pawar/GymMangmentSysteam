using GSM.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace GMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ITraniner _traniner;
        private readonly IReportService _reportService;

        public AdminController(IReportService reportService, ITraniner traniner)
        {
            _reportService = reportService;
            _traniner = traniner;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_reportService.AdminDashboradCount());
        }
    }
}
