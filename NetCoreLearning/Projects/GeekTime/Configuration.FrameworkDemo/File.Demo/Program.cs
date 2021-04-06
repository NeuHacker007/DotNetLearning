using System;
using Microsoft.Extensions.Configuration;

namespace File.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            /*
             * The order of the file loaded for the configuration matters.
             *
             * The latter load file will override the value of the before one.
             */

            // reloadOnChange will watch the configuration file change and load new settings without
            // restart the program.
            builder.AddJsonFile("appsettings.json", optional:false, reloadOnChange:true);
            builder.AddIniFile("appsettings.ini");
            builder.AddJsonFile("appsettings.Dev.json");
            var config = builder.Build();

            Console.WriteLine($"K1: {config["k1"]}");
            Console.WriteLine($"K2: {config["k2"]}");
            Console.WriteLine($"K3: {config["k3"]}");

            Console.ReadKey();

            Console.WriteLine($"K1: {config["k1"]}");
            Console.WriteLine($"K2: {config["k2"]}");
            Console.WriteLine($"K3: {config["k3"]}");

            Console.ReadKey();
        }
    }
}
