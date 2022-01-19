using GSM.DAL.Models;
using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSMThree.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Display List 
        public IActionResult Index(string search, string sortOrder)
        {

            List<vwUserInfo> result = _userService.GetUserInfoAll().ToList();

            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "Date":
                    result = result.OrderByDescending(s => s.CreatedDate).ToList();
                    break;
                default:
                    break;
            }

            if (search != null)
            {
                result = result.Where(w => w.Name.Contains(search) || w.Phone.Contains(search)).ToList();
            }

            return View(result);
        }


        // GET: User/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            List<vwTraninerInfo> vwTraniners = _userService.GetddlTraniner().ToList();
            ViewBag.TraninersList = vwTraniners;

            List<vwPlan> vwPlan = _userService.GetddlPlan().ToList();
            ViewBag.PlanList = vwPlan;

            return View();
        }

        //Data Save 
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([Bind("Id,Email,Password,Name,Phone,Age,Gender,IsActive,TrainnerId,PlanId")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Add(user);

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

            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            List<vwTraninerInfo> vwTraniners = _userService.GetddlTraniner().ToList();
            ViewBag.TraninersList = vwTraniners;

            return View(user);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(int id, [Bind("Id,Email,Name,Phone,Age,Gender,IsActive,TrainnerId")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.UpdateUser(user);
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
            _userService.DeleteUserById(id);
            return RedirectToAction("Index");
        }

        //Created Details
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int Id)
        {
            return View(_userService.GetById(Id));
        }
        [HttpGet]
        public ActionResult Detail(string customerId)
        {
            int id = Convert.ToInt32(customerId);
            return PartialView("Details", _userService.GetUserById(id));
        }

        [HttpGet]
        [Route("UserPage")]
        public ActionResult UserPage()
        {
            return View(_userService.GetByUserName(User.Identity.Name));
        }
    }
}