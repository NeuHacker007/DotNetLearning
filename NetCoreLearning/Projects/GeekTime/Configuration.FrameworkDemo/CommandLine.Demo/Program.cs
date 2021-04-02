using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CommandLine.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            //builder.AddCommandLine(args);

            #region commandline replace
            // mainly used to provide a shortcut of a command
            // like -h === --help in dotnet commandline tool
            var mapper = new Dictionary<string, string>()
            {
                {"-k1", "CommandLineKey1"}
            };

            builder.AddCommandLine(args, mapper);

            #endregion

            var configurationRoot = builder.Build();

            Console.WriteLine($"CommandlineKey1: {configurationRoot["CommandLineKey1"]}");
            Console.WriteLine($"CommandlineKey2: {configurationRoot["CommandLineKey2"]}");

            Console.ReadLine();
        }
    }
}
