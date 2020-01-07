

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityUser> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(IdentityUser user, string password);
        Task<IEnumerable<Claim>> GetClaims(IdentityUser user);
        Task SignOutAsync();
        Task<bool> IsValidateUserNameAsync(string userName);
    }
}
