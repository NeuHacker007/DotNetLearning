using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace ConfigFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettins.json",true,true);

            var configRoot = builder.Build();

            IChangeToken token = configRoot.GetReloadToken();


            ChangeToken.OnChange(() => configRoot.GetReloadToken(), () =>
            {
                Console.WriteLine($"Key1: {configRoot["key1"]}");
                Console.WriteLine($"Key2: {configRoot["key2"]}");
                Console.WriteLine($"Key3: {configRoot["key3"]}");

            });
            //token.RegisterChangeCallback(state =>
            //{
            //    Console.WriteLine($"Key1: {configRoot["key1"]}");
            //    Console.WriteLine($"Key2: {configRoot["key2"]}");
            //    Console.WriteLine($"Key3: {configRoot["key3"]}");
            //}, configRoot);

            Console.ReadKey();



        }
    }
}
