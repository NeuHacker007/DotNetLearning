using System;
using System.Collections.Generic;
using System.Linq;

namespace JWTDemo
{
    public class CustomAuthenticationManager : ICustomerAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"Test1", "pwd1"},
            {"Test2", "pwd2"},
            {"Test3", "pwd3"},
            {"Test4", "pwd4"},
            {"Test5", "pwd5"},
            {"Test6", "pwd6"}
        };

        private readonly IDictionary<string, string> _tokens = new Dictionary<string, string>();

        public IDictionary<string, string> Tokens => _tokens;
        public string Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Key == username && u.Value == password)) return null;

            // in real world this should be an hashed and encrypted value but here for simplicity, just write like this
            var token = Guid.NewGuid().ToString();


            _tokens.Add(token, username);

            return token;
        }
    }
}