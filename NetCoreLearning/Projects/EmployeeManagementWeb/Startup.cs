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
            /**
             * Must be plugged in the pipeline as early as possible
             * contains stack trace, query string, cookies and HTTP headers
             * customized the developerExceptionPageOptions
             */
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPage = new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(developerExceptionPage);
            }         
            app.UseFileServer();
            app.Run(async (context) =>
            {
                throw new Exception("Some wrong with the server");
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}
