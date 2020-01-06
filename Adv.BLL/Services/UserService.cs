using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adv.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password).ConfigureAwait(false);
           
            return result;
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var result = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(IdentityUser user, string password)
        {
            var result = await signInManager.PasswordSignInAsync(user, password, false, false).ConfigureAwait(false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync().ConfigureAwait(false);
        }
    }
}
