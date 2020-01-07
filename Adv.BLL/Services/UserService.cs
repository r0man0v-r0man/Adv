using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
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
            if (result.Succeeded)
            {
                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user?.UserName)).ConfigureAwait(false);
            }
            return result;
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var result = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            return result ?? throw new UserNotFoundException($"Пользователя {userName} не существует!");
        }
        public async Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
            var result = await userManager.CheckPasswordAsync(user, password).ConfigureAwait(false);
            return result ? result : throw new UserBadPasswordException("Не верный пароль!");
        }
        public async Task<IEnumerable<Claim>> GetClaims(IdentityUser user)
        {
            var result = await userManager.GetClaimsAsync(user).ConfigureAwait(false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsValidateUserNameAsync(string userName)
        {
            var result = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
