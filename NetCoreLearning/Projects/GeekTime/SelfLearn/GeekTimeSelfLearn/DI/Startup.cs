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
using DI.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DI
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
            #region LifeTime

            services.AddSingleton<IMySingletonService, MySingletonService>();
            services.AddTransient<IMyTransitService, MyTransitService>();
            services.AddScoped<IMyScopeService, MyScopeService>();

            #endregion

            #region Register 

            services.AddSingleton<IOrderService>(new OrderService()); // 直接注入实例
            //services.AddSingleton<IOrderService>(serviceProvider => // 工厂
            //            new OrderServiceEx()
            //);


            #endregion

            #region Try Register
            //如果该服务已经被注册则不再注册
            //services.TryAddSingleton<IOrderService, OrderService>();

            //如果实现类相同就不注册，实现类不同才注册
           // services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderService>());

           
            #endregion

            #region RemoveReplace

            //services.RemoveAll<IOrderService>();
           // services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>()); // 替换服务

            #endregion

            #region Register Generic Template

            services.AddSingleton(typeof(IGenericService<>), typeof(GenericService<>));

            #endregion
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
