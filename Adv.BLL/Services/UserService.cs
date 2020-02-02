using Adv.BLL.DTO;
using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
