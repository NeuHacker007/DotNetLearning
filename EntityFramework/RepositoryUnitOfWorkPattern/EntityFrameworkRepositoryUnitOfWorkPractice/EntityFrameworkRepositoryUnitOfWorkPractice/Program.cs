using System;
using EntityFrameworkRepositoryUnitOfWorkPractice.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntityFrameworkRepositoryUnitOfWorkPractice
{
    class Program
    {


        static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(config =>
                {
                    config.AddJsonFile("./appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContextPool<AppDbContext>(options =>
                    {
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("SqlDBConnection"));
                    });
                });

    }
}
