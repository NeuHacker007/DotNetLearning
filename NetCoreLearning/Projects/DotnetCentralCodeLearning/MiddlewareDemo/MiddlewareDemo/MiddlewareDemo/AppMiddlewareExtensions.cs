using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareDemo
{
    public static class AppMiddlewareExtensions
    {
        public static void UseOutOfBoxExtensions(this IApplicationBuilder app)
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

            app.Map("/map", a =>
            {
                a.Map("/branch", x =>
                {
                    x.Run(async ctx =>
                    {
                        await ctx.Response.WriteAsync($"New Children branch");
                    });
                });
                a.Run(async ctx =>
                {
                    await ctx.Response.WriteAsync($"New map branch");
                });
            });

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync($"<br>Response from 2st middleware");

            });
        }
    }
}
