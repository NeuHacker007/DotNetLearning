using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace CustomConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.Add(new MyConfigurationSource());

            builder.AddMyConfiguration();
            var configRoot = builder.Build();
            ChangeToken.OnChange(() => configRoot.GetReloadToken(), () =>
            {
                Console.WriteLine($"{configRoot["lastTime"]}");
            });

            //Console.WriteLine($"{configRoot["lastTime"]}");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
