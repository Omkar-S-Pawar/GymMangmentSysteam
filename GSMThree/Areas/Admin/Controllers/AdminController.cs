using GSM.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IReportService _reportService;

        public AdminController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(_reportService.AdminDashboradCount());
        }
    }
}