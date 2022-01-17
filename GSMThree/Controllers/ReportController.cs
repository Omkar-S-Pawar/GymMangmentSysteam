using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GMS.Controllers
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

        public IActionResult GetUserCount()
        {
        
            return View();
        }

    }
}
