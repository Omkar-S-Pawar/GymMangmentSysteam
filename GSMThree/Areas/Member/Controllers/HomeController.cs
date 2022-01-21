using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GMS.Areas.Member.Controllers
{
    [Authorize]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        public HomeController(IUserService userService,IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }
        //User Dashborad
        public IActionResult Index()
        {
            return View(_userService.GetByUserName(User.Identity.Name));
        }
        //Update User Profile
        [HttpPost]
        [Route("UpdateProfile")]
        public IActionResult UpdateProfile([Bind(Prefix = "Item1")]vwUserInfo vwUserInfo)
        {
            _userService.UpdateUser(vwUserInfo, _userService.GetByUserName(User.Identity.Name).Email);
            return Redirect("/Views/Shared/UpdateProfile.cshtml");
        }
        //Show Profile and Change Password
        [HttpGet]
        [Route("Profile")]
        public IActionResult Profile()
        {
            var tuple = new Tuple<vwUserInfo, vwChangePassword>(_userService.GetByUserName(User.Identity.Name), new vwChangePassword());
            return View(tuple);
        }
    }
}
