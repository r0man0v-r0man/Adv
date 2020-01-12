using Adv.API.Models;
using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
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
                    var token = superManager.Users.CreateToken(claims);

                    return CreatedAtAction(nameof(Login), new { access_token = token });
                }
                return NoContent();
            }
            catch (Exception ex) 
            {
                if (ex is UserNotFoundException || ex is UserBadPasswordException)
                {
                    return BadRequest(ex.Message);
                    throw;
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    throw;
                }
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModel user)
        {//add cliams to new user, like a role, date of birth, gender etc.
            var result = await superManager.Users.CreateAsync(user, user?.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                return Ok(true);
            }

            return BadRequest(result.Errors.FirstOrDefault().Description);
        }
        [HttpGet("IsValidateUserName/{userName}")]
        public async Task<ActionResult<bool>> IsValidateUserName(string userName)
        {
            var result = await superManager.Users.IsValidateUserNameAsync(userName).ConfigureAwait(false);
            return result;
        }
        public async Task<IActionResult> LogOut()
        {
            // sign out
            await superManager.Users.SignOutAsync().ConfigureAwait(false);
            return Ok();
        }
    }
}