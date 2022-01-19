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
        private readonly IUserService _userService;

        public AdminController(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(_reportService.AdminDashboradCount());
        }

        [Route("UserDetails")]
        public IActionResult UserDetails(string name, string email, string txtFromDate, string txttoDate, int Gender, int IsActive, int ddlTraniners)
        {
            List<vwUserInfo> result = _userService.GetUsersForAdminReport(name, email, txtFromDate, txttoDate, Gender, IsActive, ddlTraniners).ToList();
            return View(result);
        }
    }
}