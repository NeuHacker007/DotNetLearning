using System;
using Microsoft.Extensions.Configuration;

namespace EnvVariableConfig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            //builder.AddEnvironmentVariables();

            //var configRoot = builder.Build();

            //Console.WriteLine($"Ivan_Key1: {configRoot["Ivan_Key1"]}");
            //var section = configRoot.GetSection("section1");
            //Console.WriteLine($"Section1__Key3: {section["Key3"]}");

            //var section2 = configRoot.GetSection("section1:section2");

            //Console.WriteLine($"Section1__Section2__Key4: {section2["Key4"]}");
            //Console.WriteLine($"Ivan_Key1: {configRoot["Ivan_Key1"]}");

            builder.AddEnvironmentVariables("Ivan_");

            var configRoot = builder.Build();

            Console.WriteLine($"Ivan_Key1: {configRoot["key1"]}");
            Console.WriteLine($"Key2: {configRoot["key2"]}");
        }
    }
}
