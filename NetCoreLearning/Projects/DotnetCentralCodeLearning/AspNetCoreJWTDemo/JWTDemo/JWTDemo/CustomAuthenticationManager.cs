using System;
using System.Collections.Generic;
using System.Linq;

namespace JWTDemo
{
    public class CustomAuthenticationManager : ICustomerAuthenticationManager
    {
        private readonly IList<User> users = new List<User>()
        {
            new User() { UserName = "test1", Password = "pwd1", Role = "Administrator"},
            new User() { UserName = "test2", Password = "pwd2", Role = "User"},
        };

        private readonly IDictionary<string, Tuple<string, string>> _tokens = new Dictionary<string, Tuple<string, string>>();

        public IDictionary<string, Tuple<string, string>> Tokens => _tokens;
        public string Authenticate(string username, string password)
        {
            if (!users.Any(u => u.UserName == username && u.Password == password)) return null;

            // in real world this should be an hashed and encrypted value but here for simplicity, just write like this
            var token = Guid.NewGuid().ToString();


            _tokens.Add(token, new Tuple<string, string>(
                username,
                users
                    .First(u => u.UserName == username && u.Password == password).Role));


            return token;
        }
    }
}