using System;
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariable.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            //builder.AddEnvironmentVariables();

            var config = builder.Build();
            Console.WriteLine($"Key1: {config["key1"]}");

            //Sectioned configuration

            var section = config.GetSection("SECTION1");
            Console.WriteLine($"Key3: {section["KEY3"]}");

            var section2 = config.GetSection("SECTION1:SECTION2");
            Console.WriteLine($"Key4: {section2["KEy4"]}");

            //prefix pattern;

            builder.AddEnvironmentVariables("Ivan_");
            var config2 = builder.Build();
            Console.WriteLine($"Ivan Key1: {config2["key1"]}");
            Console.WriteLine($"Key3: {section["KEY3"]}");
        }
    }
}
