using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Authenticate()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "some_id")
            };

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
            return CreatedAtAction(nameof(Authenticate), new { access_token = tokenJson });
        }
        public IActionResult Decode(string value)
        {
            var bytes = Convert.FromBase64String(value);
            return CreatedAtAction(nameof(Decode), Encoding.UTF8.GetString(bytes));
        }

    }
}