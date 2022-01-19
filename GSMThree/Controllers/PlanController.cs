using GSM.DAL.Models;
using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GMS.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Plan")]
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        //Display List 
        public IActionResult Index()
        {
            return View(_planService.GetPlanInfoAll());
        }

        // GET: Plan/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        //Data Save 
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([Bind("Id,Name,IsActive")] Plan plan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    plan.CreatedBy = "Admin";
                    plan.CreatedDate = DateTime.UtcNow;
                    plan.UpdateDate = plan.CreatedDate;
                    plan.UpdateBy = plan.CreatedBy;

                    _planService.Add(plan);

                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Display Value For Update
        [HttpGet]
        [Route("Update")]
        public IActionResult Update(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = _planService.GetById(id);

            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }


        [HttpPost]
        [Route("Update")]
        public IActionResult Update([Bind("Id,Name,IsActive")] vwPlan plan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _planService.UpdatePlan(plan);
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Update");
            }
        }

        // Delete Data
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            _planService.DeletePlanById(id);
            return RedirectToAction("Index");
        }

        //Created Details
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int Id)
        {
            return View(_planService.GetById(Id));
        }
    }
}
