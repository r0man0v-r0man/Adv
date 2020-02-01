using Adv.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<IdentityResult> CreateAsync(AppUser user, string password);
        Task<bool> IsValidateUserNameAsync(string userName);

    }
}
