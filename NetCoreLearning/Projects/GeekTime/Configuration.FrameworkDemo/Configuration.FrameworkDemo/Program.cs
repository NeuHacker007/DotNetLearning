using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Configuration.FrameworkDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                {"k1", "V1"},
                {"k2", "V2"},
                {"section1:k3", "v3"},
                {"section2:k4", "v4"},
                {"section2:k5", "v5"},
                {"section2:section3:k7", "v7"},
            });

            var configurationRoot = builder.Build();

            Console.WriteLine($"Key 1: {configurationRoot["k1"]}");
            Console.WriteLine(configurationRoot["k2"]);

            IConfiguration config = configurationRoot;
            IConfigurationSection section = config.GetSection("section1");
            Console.WriteLine($"k3: {section["k3"]}");
            Console.WriteLine($"k4: {section["k4"]}");

            var section2 = config.GetSection("section2");

            Console.WriteLine($"k4: {section2["k4"]}");
            Console.WriteLine($"k5: {section2["k5"]}");

            var section3 = config.GetSection("section2:section3");

            Console.WriteLine($"k7 : {section3["k7"]}");

            Console.ReadLine();

        }
    }
}
