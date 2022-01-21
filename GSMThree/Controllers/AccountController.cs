using GSM.Service.Services;
using GSM.Service.ViewModel;
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
        public async Task<IActionResult> Signup([Bind("Name,Email,Password")] InputModel inputModel)
        {

            var result = await _accountService.CreateUser(inputModel);
            if (!result.Succeeded)
            {
                foreach (var errormsg in result.Errors)
                {
                    ModelState.AddModelError("", errormsg.Description);
                }
                return View(inputModel);
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
        public async Task<IActionResult> Login(InputModel inputModel)
        {
            var result = await _accountService.PasswordSignInAsyc(inputModel);

            if (result.Succeeded)
            {
                TempData["Email"] = inputModel.Email;
                //For Admin Role
                if (inputModel.Email == "omkar@gmail.com")
                {

                    return RedirectToAction("Index", "Admin", new { Areas = "Admin" });
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

        [Authorize]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync([Bind(Prefix = "Item2")] vwChangePassword vwChangePassword)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ChangePasswordAsync(vwChangePassword,TempData["Email"].ToString().ToLower());
                TempData.Keep("Email");
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    await _accountService.SignOutAsync();
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return Redirect("~/Member/Home/Profile");
        }
    }
}
