using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace JWTDemo
{
    public class TokenRefresher : ITokenRefresher
    {
        private readonly string _key;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public TokenRefresher(string key, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _key = key;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        public AuthenticationResponse Refresh(RefreshCredential refreshCredential)
        {
            //get and valid principal 

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(refreshCredential.JwtToken, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key)),
                ValidateIssuer = false,
                ValidateAudience = false

            }, out var validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;

            if (jwtToken == null || jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token passed");
            }

            var userName = principal.Identity.Name;
            var refreshToken = userName == null ? string.Empty : _jwtAuthenticationManager.UserRefreshTokens[userName];

            if (refreshCredential.RefreshToken != refreshToken)
            {
                throw new SecurityTokenException("Invalid refresh token passed");
            }

            return _jwtAuthenticationManager.Authenticate(userName, principal.Claims.ToArray());
        }
    }
}
