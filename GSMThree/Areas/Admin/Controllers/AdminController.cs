using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly ITraniner _traniner;
        private readonly IReportService _reportService;
        private readonly IUserService _userService;

        public AdminController(IReportService reportService, ITraniner traniner, IUserService userService)
        {
            _reportService = reportService;
            _traniner = traniner;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_reportService.AdminDashboradCount());
        }

        [HttpGet]
        [Route("UserDetails")]
        public IActionResult UserDetails()
        {
            List<vwUserInfo> result = _userService.GetUserInfoAll().ToList();
            
            return View(result);
        }
    }
}
