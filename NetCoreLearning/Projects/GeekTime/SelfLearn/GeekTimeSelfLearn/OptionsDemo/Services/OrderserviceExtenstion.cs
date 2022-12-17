using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OptionsDemo.Services
{
    public static class OrderserviceExtenstion
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<OrderServiceOptions>(config);
            services.PostConfigure<OrderServiceOptions>((options) =>
            {
                options.MaxOrderCount += 100; 
            });
            services.AddSingleton<IOrderService, OrderService>();

            return services;
        }
    }
}
