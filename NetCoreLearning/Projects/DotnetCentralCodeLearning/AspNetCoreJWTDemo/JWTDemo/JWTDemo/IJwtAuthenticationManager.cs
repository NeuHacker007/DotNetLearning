using System.Collections.Generic;
using System.Security.Claims;

namespace JWTDemo
{
    public interface IJwtAuthenticationManager
    {
        AuthenticationResponse Authenticate(string username, string password);
        IDictionary<string, string> UserRefreshTokens { get; set; }
        AuthenticationResponse Authenticate(string username, Claim[] claims);
    }
}