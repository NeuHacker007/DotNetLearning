using FakeXieCheng.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using System;

namespace FakeXieCheng.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticateController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            //1. verify the user name and password

            //2. create Jwt

            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, "fake_user_id")
            };
            var secretBytes = Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]);

            var signingKey = new SymmetricSecurityKey(secretBytes);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);
            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            //3.return 200 ok + jwt

            return Ok(tokenString);
        }
    }
}
