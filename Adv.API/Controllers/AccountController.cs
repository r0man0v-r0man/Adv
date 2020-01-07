using Adv.API.Models;
using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISuperManager superManager;
        private readonly IConfiguration configuration;

        public AccountController(
            ISuperManager superManager,
            IConfiguration configuration)
        {
            this.superManager = superManager;
            this.configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                //find user
                var existUser = await superManager.Users.FindByNameAsync(user?.UserName).ConfigureAwait(false);
                //check pair user - password
                var checkUserPassword = await superManager.Users.CheckPasswordAsync(existUser, user?.Password).ConfigureAwait(false);
                if (existUser != null && checkUserPassword == true)
                {
                    //generates user claims
                    var claims = await superManager.Users.GetClaims(existUser).ConfigureAwait(false);
                    //create JWT
                    var token = CreateToken(claims);

                    return CreatedAtAction(nameof(Login), new { access_token = token });
                }
                return NoContent();
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
            catch (UserBadPasswordException ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModel user)
        {//add cliams to new user, like a role, date of birth, gender etc.
            var result = await superManager.Users.CreateAsync(user, user?.Password).ConfigureAwait(false);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
        /// <summary>
        /// Generate JWT
        /// </summary>
        /// <param name="userClaims">User Claims</param>
        /// <returns></returns>
        private string CreateToken(IEnumerable<Claim> userClaims)
        {
            var secretsBytes = Encoding.UTF8.GetBytes(configuration["TokenSecret"]);
            var key = new SymmetricSecurityKey(secretsBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                configuration["TokenIssuer"],
                configuration["TokenAudience"],
                userClaims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials);
            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenJson;
        }
        public async Task<IActionResult> LogOut()
        {
            // sign out
            await superManager.Users.SignOutAsync().ConfigureAwait(false);
            return Ok();
        }
    }
}