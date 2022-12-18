using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = configBuilder.Build();

            IServiceCollection serviceCollection = new ServiceCollection();

            //如果用serviceCollection.AddSingleton<IConfiguration>(config)
            //则容器不会帮我们管理该对象的生命周期
            serviceCollection.AddSingleton<IConfiguration>(c => config);// 工厂模式注入

            serviceCollection.AddLogging(builder =>
            {
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddConsole();
            });

            IServiceProvider service = serviceCollection.BuildServiceProvider();

            ILoggerFactory loggerFactory = service.GetService<ILoggerFactory>();

            var alogger = loggerFactory.CreateLogger("alogger");
        }
    }
}
