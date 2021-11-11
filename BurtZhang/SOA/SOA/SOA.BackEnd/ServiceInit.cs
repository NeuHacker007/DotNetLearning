using SOA.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOA.BackEnd
{
    public class ServiceInit
    {
        public static void Process()
        {
            List<ServiceHost> hosts = new List<ServiceHost>()
            {

                new ServiceHost(typeof(MathService))

            };



            foreach (var host in hosts)
            {
                host.Opening += (s, e) => Console.WriteLine($"{host.GetType().Name} open" );
                host.Open();
            }

            Console.WriteLine("input any char, stop");

            Console.Read();

            foreach(var host in hosts)
            {
                host.Close();
            }

            Console.Read();
        }
    }
}
