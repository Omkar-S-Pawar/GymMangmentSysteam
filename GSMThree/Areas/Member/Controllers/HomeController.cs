using GSM.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Areas.Member.Controllers
{
    [Authorize]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetByUserName(User.Identity.Name));
        }

        public IActionResult Show()
        {
            return View(_userService.GetByUserName(User.Identity.Name));
        }

        public IActionResult Profile()
        {
            return View(_userService.GetByUserName(User.Identity.Name));
        }
    }
}
