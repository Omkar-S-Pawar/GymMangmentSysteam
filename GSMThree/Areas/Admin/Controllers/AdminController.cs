using Microsoft.AspNetCore.Mvc;

namespace GMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
