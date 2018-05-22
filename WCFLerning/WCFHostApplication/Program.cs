using System;
using System.ServiceModel;

namespace WCFHostApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFFirstDemo.AutoCompleteSVS)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("Host Opened");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
