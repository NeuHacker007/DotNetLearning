using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingScopeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddCommandLine(args);
            configBuilder.AddJsonFile("appsettings.json", reloadOnChange: true, optional: false);
            var config = configBuilder.Build();
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(c => config);

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(config.GetSection("logging"));
                builder.AddConsole();
                builder.AddDebug();
            });

            IServiceProvider service = services.BuildServiceProvider();

            var logger = service.GetService<ILogger<Program>>();

            using(logger.BeginScope("ScopeId: {ScopeId}", Guid.NewGuid()))
            {
                logger.LogInformation("Info");
                logger.LogError("Error");
                logger.LogTrace("Trace");
            }

        }
    }
}
