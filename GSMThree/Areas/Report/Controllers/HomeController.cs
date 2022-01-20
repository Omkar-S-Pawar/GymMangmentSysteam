using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GMS.Areas.Report.Controllers
{
    [Route("Report")]
    [Area("Report")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [Route("Index")]
        public IActionResult Index(string name, string email, string txtFromDate, string txttoDate, int Gender, int IsActive)
        {
            List<vwUserInfo> result = _userService.GetUsersForAdminReport(name, email, txtFromDate, txttoDate, Gender, IsActive).ToList();
            return View(result);
        }
    }
}
