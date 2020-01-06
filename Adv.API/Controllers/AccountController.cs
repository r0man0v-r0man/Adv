using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISuperManager superManager;

        public AccountController(ISuperManager superManager)
        {
            this.superManager = superManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            UserViewModel existUser = await superManager.Users.FindByNameAsync(user?.UserName).ConfigureAwait(false);
            if (existUser != null)
            {
                // sign in
                var signInResult = await superManager.Users.PasswordSignInAsync(user?.UserName, user?.Password).ConfigureAwait(false);
                if (signInResult.Succeeded)
                {
                    return Ok(true);
                }
            }
            return NotFound();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            var result = await superManager.Users.CreateAsync(user, user?.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                //sign in
                var signInResult = await superManager.Users.PasswordSignInAsync(user?.UserName, user?.Password).ConfigureAwait(false);
                if (signInResult.Succeeded)
                {
                    return Ok(true);
                }
            }

            return CreatedAtAction(nameof(Register), user);
        }
        public async Task<IActionResult> LogOut()
        {
            // sign out
            await superManager.Users.SignOutAsync().ConfigureAwait(false);
            return Ok();
        }
    }
}