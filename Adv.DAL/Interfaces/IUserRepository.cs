using Adv.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface IUserRepository 
    {
        /// <summary>
        /// Create user when register
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IdentityResult> CreateAsync(AppUser user, string password);
        /// <summary>
        /// check is userName exist
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> IsValidateUserNameAsync(string userName);
        /// <summary>
        /// Find User by name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<AppUser> FindByNameAsync(string userName);
        /// <summary>
        /// Find User by Id
        /// </summary>
        /// <param name="currentUserId">User Id</param>
        /// <returns></returns>
        Task<AppUser> FindByIdAsync(string currentUserId);

        /// <summary>
        /// Check pair user - password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        /// <summary>
        /// Get user claims
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IEnumerable<Claim>> GetClaims(AppUser user);
        /// <summary>
        /// Generate claims
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        string CreateToken(IEnumerable<Claim> claims);

    }
}
