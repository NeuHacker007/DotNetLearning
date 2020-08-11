using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MiddlewareDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync($"<html><body>Response from 1st middleware");
                await next();
                await ctx.Response.WriteAsync($"<br>End of 1st middleware");
            });

            app.UseWhen(ctx => ctx.Request.Query.ContainsKey("role"), a =>
            {
                //a.Run(async ctx =>
                //{
                //    await ctx.Response.WriteAsync($"<br> Role is {ctx.Request.Query["role"]}");
                //});
                a.Use(async (ctx, next) =>
                {
                    await ctx.Response.WriteAsync($"<br> Role is {ctx.Request.Query["role"]}");
                    await next();
                });
            });

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync($"<br>Response from 2st middleware");

            });

        }
    }
}
