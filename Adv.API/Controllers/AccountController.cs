using Adv.API.Models;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Adv.API.Controllers
{
    /// <summary>
    /// var usr = User.FindFirst(ClaimTypes.NameIdentifier).Value; * get current user id
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISuperManager superManager;

        public AccountController(
            ISuperManager superManager)
        {
            this.superManager = superManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                var loginUser = await superManager.Users.LoginAsync(user, user?.Password).ConfigureAwait(false);
                return CreatedAtAction(nameof(Login), new { access_token = loginUser });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModel user)
        {
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
        [HttpGet("userInfo/{id}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetUserInfo()
        {
            //get current user id
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            UserViewModel result = await superManager.Users.GetUserInfo(currentUserId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}