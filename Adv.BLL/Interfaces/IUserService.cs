

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
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> LoginAsync(AppUserDTO user, string password);
        Task<bool> IsValidateUserNameAsync(string userName);
        /// <summary>
        /// Get user info
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        Task<AppUserDTO> GetUserInfo(string currentUserId);
    }
}
