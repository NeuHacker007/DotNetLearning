﻿using FakeXieCheng.API.Dtos;
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
using System.Collections.Generic;
using FakeXieCheng.API.Models;
using FakeXieCheng.API.Services;

namespace FakeXieCheng.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly ITouristRouteRepository _touristRouteRepository;

        public AuthenticateController(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            ITouristRouteRepository touristRouteRepository
            )
        {
            this._configuration = configuration;
            this._userManager = userManager;
            this._signinManager = signinManager;
            this._touristRouteRepository = touristRouteRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            //1. verify the user name and password
            var loginResult = await _signinManager.PasswordSignInAsync(
                loginDto.Email,
                loginDto.Password,
                isPersistent: false,
                lockoutOnFailure: false
                );
            if (!loginResult.Succeeded)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(loginDto.Email);
            var roleNames = await _userManager.GetRolesAsync(user);
            //2. create Jwt

            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                //new Claim(ClaimTypes.Role, )
            };

            foreach (var roleName in roleNames)
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                claims.Add(roleClaim);
            }

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
            var user = new ApplicationUser()
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

            var shoppingCart = new ShoppingCart()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id
            };

            await _touristRouteRepository
                .CreateShoppingCartAsync(shoppingCart);
            await _touristRouteRepository.SaveAsync();



            return Ok();

        }
    }
}
