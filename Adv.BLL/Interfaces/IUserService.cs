

using Adv.BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user">AppUserDTO model</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        Task<IdentityResult> CreateAsync(AppUserDTO user, string password);
        //Task<IdentityUser> FindByNameAsync(string userName);
        //Task<bool> CheckPasswordAsync(IdentityUser user, string password);
        //Task<IEnumerable<Claim>> GetClaims(IdentityUser user);
        ///// <summary>
        ///// Generate JWT
        ///// </summary>
        ///// <param name="claims">User Claims</param>
        ///// <returns></returns>
        //string CreateToken(IEnumerable<Claim> claims);
        Task<bool> IsValidateUserNameAsync(string userName);
    }
}
