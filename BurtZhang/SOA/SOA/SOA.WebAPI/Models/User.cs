using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOA.WebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}