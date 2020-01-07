

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityUser> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(IdentityUser user, string password);
        Task<SignInResult> PasswordSignInAsync(string userName, string password);
        Task SignOutAsync();
    }
}
