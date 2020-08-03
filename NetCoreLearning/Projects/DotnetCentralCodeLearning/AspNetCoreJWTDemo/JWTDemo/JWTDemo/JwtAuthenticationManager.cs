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

        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public string Authenticate(string userName, string password)
        {
            if (!users.Any(u => u.Key == userName && u.Value == password)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}