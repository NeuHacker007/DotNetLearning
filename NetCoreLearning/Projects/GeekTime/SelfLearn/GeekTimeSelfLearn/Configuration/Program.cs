using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Configuration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "key1", "V1" },
                { "key2", "V2" },
                { "section1:k3", "v3" },
                { "section2:k4", "v4" },
                { "section2:k5", "v5" },
                { "section2:section3:k6", "v6" },
            });

            IConfigurationRoot configurationRoot = builder.Build();

            IConfiguration config = configurationRoot;

            Console.WriteLine(configurationRoot["key1"]);
            Console.WriteLine(configurationRoot["key2"]);

            IConfigurationSection section = config.GetSection("section1");
            
            Console.WriteLine($"key3: {section["k3"]}");
            Console.WriteLine($"key4: {section["k4"]}");
            

            IConfigurationSection section2 = config.GetSection("section2");
            Console.WriteLine($"key4_V2: {section2["k4"]}");

            IConfigurationSection section3 = section2.GetSection("section3");
            Console.WriteLine($"key6_V2: {section3["k6"]}");


        }
    }
}
