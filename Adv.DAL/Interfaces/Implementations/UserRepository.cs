using Adv.DAL.Entities;
using Adv.DAL.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration configuration;
        public UserRepository(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            var result = await userManager.CheckPasswordAsync(user, password).ConfigureAwait(false);
            return result ? result : throw new UserBadPasswordException("Неверный пароль!");
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

        public string CreateToken(IEnumerable<Claim> claims)
        {
            var secretsBytes = Encoding.UTF8.GetBytes(configuration["TokenSecret"]);
            var key = new SymmetricSecurityKey(secretsBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                configuration["TokenIssuer"],
                configuration["TokenAudience"],
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(7),
                signingCredentials);
            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenJson;
        }


        public async Task<AppUser> FindByIdAsync(string currentUserId)
        {
            var result = await userManager.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == currentUserId).ConfigureAwait(false);
            return result;
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            var result = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            return result ?? throw new UserNotFoundException($"Пользователя {userName} не существует!");
        }

        public async Task<IEnumerable<Claim>> GetClaims(AppUser user)
        {
            var result = await userManager.GetClaimsAsync(user).ConfigureAwait(false);
            return result;
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


        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                userManager.Dispose();
            }

            disposed = true;
        }
    }
}
