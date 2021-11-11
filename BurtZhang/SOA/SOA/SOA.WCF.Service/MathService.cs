using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOA.WCF.Interface;
using SOA.WCF.Model;

namespace SOA.WCF.Service
{
    public class MathService : IMathService
    {
        public int PlusInt(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Minus(int x, int y)
        {
            throw new NotImplementedException();
        }

        public WCFUser GetUser(int x, int y)
        {
            throw new NotImplementedException();
        }

        public List<WCFUser> UserList()
        {
            throw new NotImplementedException();
        }
    }
}
