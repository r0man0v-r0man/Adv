using Adv.API.Models;
using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
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
                UserViewModel existUser = await superManager.Users.FindByNameAsync(user?.UserName).ConfigureAwait(false);
                if (existUser != null)
                {
                    //generates user claims
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, existUser.UserName)
                    };
                    //create JWT
                    var secretsBytes = Encoding.UTF8.GetBytes(configuration["TokenSecret"]);
                    var key = new SymmetricSecurityKey(secretsBytes);
                    var algorithm = SecurityAlgorithms.HmacSha256;

                    var signingCredentials = new SigningCredentials(key, algorithm);

                    var token = new JwtSecurityToken
                        (
                        configuration["TokenIssuer"],
                        configuration["TokenAudience"],
                        claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials
                        );
                    var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

                    return CreatedAtAction(nameof(Login), new { access_token = tokenJson });
                }
                return NoContent();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                throw;
            }

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            var result = await superManager.Users.CreateAsync(user, user?.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                //sign in
                //var signInResult = await superManager.Users.PasswordSignInAsync(user?.UserName, user?.Password).ConfigureAwait(false);
                //if (signInResult.Succeeded)
                //{
                //    return Ok(true);
                //}
                return Ok();
            }

            return BadRequest();
        }
        public async Task<IActionResult> LogOut()
        {
            // sign out
            await superManager.Users.SignOutAsync().ConfigureAwait(false);
            return Ok();
        }
    }
}