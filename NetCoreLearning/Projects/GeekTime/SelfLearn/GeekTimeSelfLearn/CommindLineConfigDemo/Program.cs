using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CommindLineConfigDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            //builder.AddCommandLine(args);
            var configReplace = new Dictionary<string, string>()
            {
                { "-key1", "key1" }
            };
            builder.AddCommandLine(args, configReplace);
            var configRoot = builder.Build();

            Console.WriteLine($"key1: {configRoot["key1"]}");
            Console.WriteLine($"key2: {configRoot["key2"]}");
            Console.WriteLine($"key3: {configRoot["key3"]}");
            Console.WriteLine($"key3: {configRoot["key1"]}");

        }
    }
}
