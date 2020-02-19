﻿using Adv.BLL.DTO;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Adv.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository  userRepository;


        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IdentityResult> CreateAsync(AppUserDTO user, string password)
        {
            var result = await userRepository.CreateAsync(user, password).ConfigureAwait(false);
            return result;
        }

        public async Task<AppUserDTO> GetUserInfo(string currentUserId)
        {
            AppUserDTO currentUser = await userRepository.FindByIdAsync(currentUserId).ConfigureAwait(false);
            return currentUser;
        }

        public async Task<bool> IsValidateUserNameAsync(string userName)
        {
            var result = await userRepository.IsValidateUserNameAsync(userName).ConfigureAwait(false);
            return result;
        }

        public async Task<string> LoginAsync(AppUserDTO user, string password)
        {
            //find user
            var existUser = await userRepository.FindByNameAsync(user?.UserName).ConfigureAwait(false);
            //check pair user - password
            var checkUserPassword = await userRepository.CheckPasswordAsync(existUser, password).ConfigureAwait(false);
            if (existUser != null && checkUserPassword == true)
            {
                //generates user claims
                var claims = await userRepository.GetClaims(existUser).ConfigureAwait(false);
                //create JWT
                var token = userRepository.CreateToken(claims);

                return token;
            }
            return null;

        }

    }
}
