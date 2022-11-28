using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Autofac.Services;
using AutofacPractice.Services;

namespace Autofac
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Autofac", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //var serviceNamed = this.AutofacContainer.ResolveNamed<IMyService>("Service2");
            //serviceNamed.ShowCode();

            //var service = this.AutofacContainer.Resolve<IMyService>();
            //service.ShowCode();

            using (var myScope = AutofacContainer.BeginLifetimeScope("MyScope"))
            {
                var service0 = myScope.Resolve<MyNameService>();

                using (var scope = myScope.BeginLifetimeScope())
                {
                    var service1 = scope.Resolve<MyNameService>();
                    var service2 = scope.Resolve<MyNameService>();

                    Console.WriteLine($"service1=service2: {service1 == service2}");
                    Console.WriteLine($"service1=service0: {service1 == service0}");
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autofac v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<Myservice>().As<IMyService>();

            #region 命名zhuce

            //builder.RegisterType<MyServiceV2>().Named<IMyService>("Service2");

            #endregion

            #region 属性注册

            //builder.RegisterType<MyNameService>();

            //builder.RegisterType<MyServiceV2>().As<IMyService>().PropertiesAutowired();

            #endregion

            #region AOP

            //builder.RegisterType<Interceptor>();
            ////builder.RegisterType<MyNameService>();
            //builder.RegisterType<MyServiceV2>().As<IMyService>().PropertiesAutowired()
            //    .InterceptedBy(typeof(Interceptor))
            //    .EnableInterfaceInterceptors();

            #endregion

            #region Child Container

            builder.RegisterType<MyNameService>().InstancePerMatchingLifetimeScope("MyScope");

            #endregion
        }

        public ILifetimeScope AutofacContainer { get; private set; }
    }
}
