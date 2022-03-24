using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FakeXieCheng.API.Extensions
{
    public static class CustomerServicesExtension
    {
        public static void AddCustomerServices(this IServiceCollection services)
        {
            services.AddTransient<ITouristRouteRepository, TouristRoutesRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
