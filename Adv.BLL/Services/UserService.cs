﻿using Adv.BLL.DTO;
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

        //public async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        //{

        //    var result = await userManager.CreateAsync(user, password).ConfigureAwait(false);
        //    if (result.Succeeded)
        //    {
        //        await userManager.AddClaimsAsync(user, new List<Claim>
        //        {
        //            new Claim(JwtRegisteredClaimNames.UniqueName, user?.UserName),
        //            new Claim(JwtRegisteredClaimNames.Sub, user?.Id)
        //        }).ConfigureAwait(false);
        //    }
        //    return result;
        //}

        //public async Task<IdentityUser> FindByNameAsync(string userName)
        //{
        //    var result = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
        //    return result ?? throw new UserNotFoundException($"Пользователя {userName} не существует!");
        //}
        //public async Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        //{
        //    var result = await userManager.CheckPasswordAsync(user, password).ConfigureAwait(false);
        //    return result ? result : throw new UserBadPasswordException("Не верный пароль!");
        //}
        //public async Task<IEnumerable<Claim>> GetClaims(IdentityUser user)
        //{
        //    var result = await userManager.GetClaimsAsync(user).ConfigureAwait(false);
        //    return result;
        //}


        public async Task<bool> IsValidateUserNameAsync(string userName)
        {
            var result = await _dataManager.Users.IsValidateUserNameAsync(userName).ConfigureAwait(false);
            return result;
        }
        //public string CreateToken(IEnumerable<Claim> claims)
        //{
        //    var secretsBytes = Encoding.UTF8.GetBytes(configuration["TokenSecret"]);
        //    var key = new SymmetricSecurityKey(secretsBytes);
        //    var algorithm = SecurityAlgorithms.HmacSha256;

        //    var signingCredentials = new SigningCredentials(key, algorithm);

        //    var token = new JwtSecurityToken(
        //        configuration["TokenIssuer"],
        //        configuration["TokenAudience"],
        //        claims,
        //        notBefore: DateTime.Now,
        //        expires: DateTime.Now.AddHours(1),
        //        signingCredentials);
        //    var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
        //    return tokenJson;
        //}
    }
}
