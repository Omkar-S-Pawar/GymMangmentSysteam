using GSM.DAL.Data;
using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly ITraniner _traniner;
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly GMSContext _GMSContext;

        public AdminController(IReportService reportService, ITraniner traniner, IUserService userService, GMSContext GMSContext)
        {
            _reportService = reportService;
            _traniner = traniner;
            _userService = userService;
            _GMSContext = GMSContext;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(_reportService.AdminDashboradCount());
        }

        [Route("UserDetails")]
        public IActionResult UserDetails(vwUserInfo userModel)
        {
            DateTime fromDate = userModel.CreatedDate;
            DateTime toDate = userModel.CreatedDate;
            var aa = Request.Form["Gender"].ToString();
            var aa1 = Request.Form["Email"].ToString();
            var aa22 = Request.Form["txtFromDate"].ToString();
            var aa33 = Request.Form["txtToDate"].ToString();
            var aa44 = Request.Form["ddlTraniners"].ToString();
            List<vwUserInfo> result = _userService.GetUserInfoAll().ToList();

            if(userModel.Name!=null && userModel.Email == "" && fromDate == null && toDate ==null && userModel.Gender == 0 && userModel.IsActive == null && userModel.TrainnerId==0 )
            {
                
            }

            var a = Request.Form["Name"];
            return View(result);
        }

        //[HttpPost]
        //[Route("Search")]
        //public IActionResult Search(vwUserInfo userModel)
        //{
         
        //}
    }
}
