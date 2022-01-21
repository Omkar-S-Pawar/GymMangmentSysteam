using GSM.DAL.Data;
using GSM.DAL.Models;
using GSM.Service.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GSM.Service.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> ChangePasswordAsync(vwChangePassword model, string email);
        Task<IdentityResult> CreateUser(InputModel inputModel);
        Task<IdentityResult> CreateUser(vwUserInfo viewModelUserInfo);
        Task<SignInResult> PasswordSignInAsyc(InputModel inputModel);
        Task SignOutAsync();
    }
    public class InputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
     
        public AccountService(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //For Registration 
        public async Task<IdentityResult> CreateUser(InputModel inputModel)
        {
            var user = new IdentityUser()
            {
                Email = inputModel.Email,
                UserName = inputModel.Email
            };
            return await _userManager.CreateAsync(user, inputModel.Password);
        }

        //For Admin UserCreation
        public async Task<IdentityResult> CreateUser(vwUserInfo viewModelUserInfo)
        {
            var user = new User()
            {
                Name = viewModelUserInfo.Name,
                Email = viewModelUserInfo.Email,
                UserName = viewModelUserInfo.Email,
                NormalizedEmail = viewModelUserInfo.Email,
                PhoneNumber = viewModelUserInfo.Phone,
                Age = viewModelUserInfo.Age,
                Gender = viewModelUserInfo.Gender,
                PlanId = viewModelUserInfo.PlanId,
                TrainnerId = viewModelUserInfo.TrainnerId,
                IsActive = viewModelUserInfo.IsActive,
                SubcriptionDate = DateTime.Now.AddMonths(viewModelUserInfo.PlanId),
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CreatedBy = "Admin",
                UpdatedBy = "Admin"
            };
            return await _userManager.CreateAsync(user, viewModelUserInfo.Password);
        }

        public async Task<SignInResult> PasswordSignInAsyc(InputModel inputModel)
        {
            return await _signInManager.PasswordSignInAsync(inputModel.Email, inputModel.Password, false, false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ChangePasswordAsync(vwChangePassword model, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }
}
