using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOA.Web.Remoting;

namespace SOA.Web.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyWCF.svc or MyWCF.svc.cs at the Solution Explorer and start debugging.
    public class MyWCF : IMyWCF
    {
        public void DoWork()
        {
            Console.WriteLine("1234");
        }

        public string GetString()
        {
            return "HelloWord";
        }

        public List<User> GetUsers(int index)
        {
            return new List<User>()
            {
                new User() {Id =1, Name="Ivan"},
                new User() {Id =2, Name="Ivan2"},
                new User() {Id =3, Name="Ivan3"},
                new User() {Id =4, Name="Ivan4"},
            };
        }

        public void HelloWorld()
        {
            
        }
    }
}
