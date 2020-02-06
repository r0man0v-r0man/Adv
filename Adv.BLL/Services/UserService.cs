using Adv.BLL.DTO;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Adv.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IDataManager _dataManager;


        public UserService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IdentityResult> CreateAsync(AppUserDTO user, string password)
        {
            var result = await _dataManager.Users.CreateAsync(user, password).ConfigureAwait(false);
            return result;
        }

        public async Task<AppUserDTO> GetUserInfo(string currentUserId)
        {
            AppUserDTO currentUser = await _dataManager.Users.FindByIdAsync(currentUserId).ConfigureAwait(false);
            return currentUser;
        }

        public async Task<bool> IsValidateUserNameAsync(string userName)
        {
            var result = await _dataManager.Users.IsValidateUserNameAsync(userName).ConfigureAwait(false);
            return result;
        }

        public async Task<string> LoginAsync(AppUserDTO user, string password)
        {
            //find user
            var existUser = await _dataManager.Users.FindByNameAsync(user?.UserName).ConfigureAwait(false);
            //check pair user - password
            var checkUserPassword = await _dataManager.Users.CheckPasswordAsync(existUser, password).ConfigureAwait(false);
            if (existUser != null && checkUserPassword == true)
            {
                //generates user claims
                var claims = await _dataManager.Users.GetClaims(existUser).ConfigureAwait(false);
                //create JWT
                var token = _dataManager.Users.CreateToken(claims);

                return token;
            }
            return null;

        }

    }
}
