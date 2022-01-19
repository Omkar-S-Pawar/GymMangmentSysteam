using GSM.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GMS.Areas.Member.Controllers
{
    [Authorize]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        /***
             string CurrentUserNameAsync();
         */
        public HomeController(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }

        public  IActionResult Index()
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
