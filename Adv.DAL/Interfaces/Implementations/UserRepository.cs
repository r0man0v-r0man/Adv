using Adv.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> userManager;
        public UserRepository(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                await userManager.AddClaimsAsync(user, new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user?.UserName),
                    new Claim(JwtRegisteredClaimNames.Sub, user?.Id)
                }).ConfigureAwait(false);
            }
            return result;
        }

        public void Dispose()
        {
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
