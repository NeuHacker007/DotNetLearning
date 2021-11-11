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
            return x + y;
        }

        public int Minus(int x, int y)
        {
            return x - y;
        }

        public WCFUser GetUser(int x, int y)
        {
            return new WCFUser()
            {
                Id = 1,
                Name = "Ivan"
            };
        }

        public List<WCFUser> UserList()
        {
            return new List<WCFUser>()
            {
                new WCFUser() {Id =1, Name="Ivan"},
                new WCFUser() {Id =2, Name="Ivan2"},
                new WCFUser() {Id =3, Name="Ivan3"},
                new WCFUser() {Id =4, Name="Ivan4"}
            };
        }
    }
}
