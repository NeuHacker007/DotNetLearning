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
using ScopeDisposal.Services;

namespace ScopeDisposal
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
            //services.AddTransient<IOrderService, DisposableOrderService>();
            //services.AddTransient<IOrderService>(o => new DisposableOrderService());
            //services.AddScoped<IOrderService>(o => new DisposableOrderService());
            //services.AddSingleton<IOrderService>(o => new DisposableOrderService());

            #region 容器不会释放对象

            // 以下方式注册对象，然后放入容器无法使得容器管理对象的声明周期
            //var service = new DisposableOrderService();

            //services.AddSingleton<IOrderService>(service);
            #endregion

            services.AddSingleton<IOrderService, DisposableOrderService>();
            //services.AddTransient<IOrderService, OrderService>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScopeDisposal", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 如果在根容器范围内声明实现了IDisposal瞬时服务
            // 然后再在根容器内获取该对象，对象会积累到应用程序关闭时才能得到释放
            var service1 = app.ApplicationServices.GetService<IOrderService>();
            var service2 = app.ApplicationServices.GetService<IOrderService>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScopeDisposal v1"));
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
