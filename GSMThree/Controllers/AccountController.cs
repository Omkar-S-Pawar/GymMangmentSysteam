using GSM.DAL.Models;
using GSM.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GMS.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("Signup")]
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup([Bind("Name,Email,Password")] User userModel)
        {

            var result = await _accountService.CreateUser(userModel);
            if (!result.Succeeded)
            {
                foreach (var errormsg in result.Errors)
                {
                    ModelState.AddModelError("", errormsg.Description);
                }
                return View(userModel);
            }
            ModelState.Clear();

            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User userModel)
        {
            var result = await _accountService.PasswordSignInAsyc(userModel);

            if (result.Succeeded)
            {
            
                if (userModel.Email=="osp@gmail.com")
                {
                    return RedirectToAction("Index","Admin",new {Areas="Admin"});
                }
                else
                {
                    return Redirect("~/Member/Home/Index");
                }
               
            }

            ModelState.AddModelError("", "Invalid Creditials");
            return View();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Default", "Home"); 
        }
    }
}
