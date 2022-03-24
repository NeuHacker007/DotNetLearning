using FakeXieCheng.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticateController(
            IConfiguration configuration,
            UserManager<IdentityUser> userManager 
            )
        {
            this._configuration = configuration;
            this._userManager = userManager;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            //1. verify the user name and password

            //2. create Jwt

            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, "fake_user_id"),
                new Claim(ClaimTypes.Role, "Admin")
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

            return Ok(new { JwtToken = tokenString });
        }

        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterDto registerDto
            )
        {
            var user = new IdentityUser()
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(
                                            user,
                                            registerDto.Password
                                            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();

        }
    }
}
