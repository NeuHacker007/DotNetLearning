using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagementWeb
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /**
             * Every thing before next() happens as request travel 
             * Every thing after next() happens as response travel (All the way up to the terminal middleware)
             */
            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");
                //await context.Response.WriteAsync("This is my 1st middleware");
                await next();
                logger.LogInformation("MW1: Outgoing Response");
            });
            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                //await context.Response.WriteAsync("This is my 1st middleware");
                await next();
                logger.LogInformation("MW2: Outgoing Response");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3: Request handled and response produced!");
                logger.LogInformation("MW3: Request handled and response produced!");
            });
        }
    }
}
