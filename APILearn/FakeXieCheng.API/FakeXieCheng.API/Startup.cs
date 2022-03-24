using FakeXieCheng.API.Database;
using FakeXieCheng.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FakeXieCheng.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcControllerSettingsServices();


            services.AddDbContext<AppDbContext>(option =>
            {
                //option.UseSqlServer(@"Server=IVAN-ZHANG\IVAN_ZHANG;Database=FakeXiechengDb;Integrated Security=True;");
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddJwtAuthenticationToWeb(Configuration);
            services.AddCustomerServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                endpoints.MapControllers();
            });
        }
    }
}
