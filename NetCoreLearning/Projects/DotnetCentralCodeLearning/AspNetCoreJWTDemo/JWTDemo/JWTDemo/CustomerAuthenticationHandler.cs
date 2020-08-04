using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JWTDemo
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
    }

    public class CustomerAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly ICustomerAuthenticationManager _customerAuthenticationManager;

        public CustomerAuthenticationHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ICustomerAuthenticationManager customerAuthenticationManager) : base(options, logger, encoder, clock)
        {
            _customerAuthenticationManager = customerAuthenticationManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            string authorizationHeader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            if (!authorizationHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var token = authorizationHeader.Substring("bearer".Length).Trim();

            if (string.IsNullOrWhiteSpace(token))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            try
            {
                return ValidateToken(token);
            }
            catch (Exception e)
            {
                //logger
                return AuthenticateResult.Fail("Unauthorized");
            }
        }

        private AuthenticateResult ValidateToken(string token)
        {
            var validToken = _customerAuthenticationManager.Tokens.FirstOrDefault(t => t.Key == token);

            if (validToken.Key == null)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var (username, role) = validToken.Value;
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);

            var principal = new GenericPrincipal(identity, new[] { role });

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
