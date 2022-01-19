using GSM.DAL.Models;
using GSM.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GMS.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("Traniner")]
    public class TraninerController : Controller
    {
        private readonly ITraniner _traniner;

        public TraninerController(ITraniner traninerService)
        {
            _traniner = traninerService;
        }
        //Display List 
        public IActionResult Index()
        {
            return View(_traniner.GetTraninerInfoAll());
        }

        // GET: Traniner/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        //Data Save 
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([Bind("Id,Name,Gender,IsActive")] Traniner traniner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _traniner.Add(traniner);

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

            var traniner = _traniner.GetById(id);

            if (traniner == null)
            {
                return NotFound();
            }

            return View(traniner);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(int id, [Bind("Id,Name,Gender,IsActive")] Traniner traniner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _traniner.UpdateTraniner(traniner);
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Update");
            }
        }

        // Delete Data
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            _traniner.DeleteById(id);
            return RedirectToAction("Index");
        }

        //Created Details
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int Id)
        {
            return View(_traniner.GetById(Id));
        }
    }
}
