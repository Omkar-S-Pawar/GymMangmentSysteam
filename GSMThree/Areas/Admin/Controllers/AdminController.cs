using GSM.DAL.Data;
using GSM.Service.Services;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
     
        public AdminController(IReportService reportService, ITraniner traniner, IUserService userService)
        {
            _reportService = reportService;
            _traniner = traniner;
            _userService = userService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(_reportService.AdminDashboradCount());
        }

        [Route("UserDetails")]
        public IActionResult UserDetails(string name,string email,string txtFromDate, string txttoDate,int Gender,int IsActive,int ddlTraniners)
        {
            List<vwUserInfo> result = _userService.GetUserForAdminReport(name,email,txtFromDate,txttoDate,Gender,IsActive,ddlTraniners).ToList();

            if(name!=null)
            {
                result = result.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (email != null)
            {
                result = result.Where(s => s.Email.Contains(email)).ToList();
            }
            if (txtFromDate != null && txttoDate!=null)
            {
                result = result.Where(s => s.CreatedDate >= Convert.ToDateTime(txtFromDate) && s.CreatedDate <= Convert.ToDateTime(txttoDate)).ToList();
            }
            if (Gender != 0)
            {
                result = result.Where(s => s.Gender.Equals(Gender)).ToList();
            }
            if (IsActive != 0)
            {
                result = result.Where(s => s.Gender.Equals(IsActive)).ToList();
            }   
            if (ddlTraniners != 0)
            {
                result = result.Where(s => s.Gender.Equals(ddlTraniners)).ToList();
            }

            return View(result);
        }




    }
}
