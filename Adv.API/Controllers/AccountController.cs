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
        private readonly IUserService userService;

        public AccountController(
            IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                var loginUser = await userService.LoginAsync(user, user?.Password).ConfigureAwait(false);
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
            var result = await userService.CreateAsync(user, user?.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                return Ok(true);
            }

            return BadRequest(result.Errors.FirstOrDefault().Description);
        }
        [HttpGet("IsValidateUserName/{userName}")]
        public async Task<ActionResult<bool>> IsValidateUserName(string userName)
        {
            try
            {
                var result = await userService.IsValidateUserNameAsync(userName).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                // log e
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("userInfo/{userId}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetUserInfo(string userId)
        {
            //get current user id
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (currentUserId != userId)
            {
                return BadRequest();
            }

            UserViewModel result = await userService.GetUserInfo(currentUserId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}