using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWTDemo
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;

        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"Test1", "pwd1"},
            {"Test2", "pwd2"},
            {"Test3", "pwd3"},
            {"Test4", "pwd4"},
            {"Test5", "pwd5"},
            {"Test6", "pwd6"}
        };

        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public IDictionary<string, string> UserRefreshTokens { get; set; }
        public JwtAuthenticationManager(string key, IRefreshTokenGenerator refreshTokenGenerator)
        {
            _refreshTokenGenerator = refreshTokenGenerator;
            _key = key;
            UserRefreshTokens = new Dictionary<string, string>();
        }

        public AuthenticationResponse Authenticate(string username, Claim[] claims)
        {
            var key = Encoding.ASCII.GetBytes(_key);
            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = _refreshTokenGenerator.GenerateToken();

            if (UserRefreshTokens.ContainsKey(username))
            {
                UserRefreshTokens[username] = refreshToken;
            }
            else
            {
                UserRefreshTokens.Add(username, refreshToken);
            }


            return new AuthenticationResponse()
            {
                JwtToken = token,
                RefreshToken = refreshToken
            };
        }
        public AuthenticationResponse Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Key == username && u.Value == password)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = _refreshTokenGenerator.GenerateToken();

            if (UserRefreshTokens.ContainsKey(username))
            {
                UserRefreshTokens[username] = refreshToken;
            }
            else
            {
                UserRefreshTokens.Add(username, refreshToken);
            }


            return new AuthenticationResponse()
            {
                JwtToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken
            };
        }


    }
}