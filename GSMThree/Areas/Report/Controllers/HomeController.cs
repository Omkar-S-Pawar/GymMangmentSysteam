using Microsoft.AspNetCore.Mvc;

namespace GMS.Areas.Report.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }        
}
