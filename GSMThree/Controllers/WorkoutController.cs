using GSM.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Controllers
{
    [Route("Workout")]
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public ActionResult Index()
        {
            TempData["Data"] = _workoutService.GetList();
            return View();
        }
    }
}
