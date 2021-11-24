using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using SOA.WebAPI.Models;
using SOA.WebAPI.Unity.Interface;

namespace SOA.WebAPI.Unity.Service
{
    public class UserService : IUserService
    {
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
        }
        public List<User> GetList()
        {
            return new List<User>()
            {
                new User() {UserId = 1, UserEmail = "a@b", UserName = "Ivan"}
            };
        }
    }
}