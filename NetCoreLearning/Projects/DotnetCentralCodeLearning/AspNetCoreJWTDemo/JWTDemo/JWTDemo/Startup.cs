using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace JWTDemo
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
            services.AddAuthentication("Basic")
                .AddScheme<BasicAuthenticationOptions, CustomerAuthenticationHandler>("Basic", null);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAndPowerUser", policy =>
               {
                   policy.RequireRole("Administrator", "PowerUser");
               });

                options.AddPolicy("EmployeeWithMoreThan20Years", policy =>
                {
                    policy.Requirements.Add(new EmployeeWithMoreYearsRequirement(20));
                });
            });

            services.AddSingleton<IAuthorizationHandler, EmployeeWithMoreYearsHandler>();
            services.AddSingleton<IEmployeeNumberOfYears, EmployeeNumberOfYears>();
            services.AddSingleton<ICustomerAuthenticationManager, CustomAuthenticationManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();


            app.UseRouting();


            app.UseAuthentication();


            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}