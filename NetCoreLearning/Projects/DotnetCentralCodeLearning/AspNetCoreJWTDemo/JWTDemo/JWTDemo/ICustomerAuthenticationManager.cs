using System;
using System.Collections.Generic;

namespace JWTDemo
{
    public interface ICustomerAuthenticationManager
    {
        string Authenticate(string username, string password);
        IDictionary<string, Tuple<string, string>> Tokens { get; }
    }
}