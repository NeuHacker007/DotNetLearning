using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOA.WebAPI.Models;

namespace SOA.WebAPI.Unity.Interface
{
    public interface IUserService
    {
        List<User> GetList();
    }
}
