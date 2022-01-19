using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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