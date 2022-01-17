using GSM.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSM.Service.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUser(User userModel);
        Task<SignInResult> PasswordSignInAsyc(User userModel);
        Task SignOutAsync();
    }
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, 
                              SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(User userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
            return await _userManager.CreateAsync(user, userModel.Password);
        }

        public async Task<SignInResult> PasswordSignInAsyc(User userModel)
        {
            return await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, false, false);
        }
      
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
