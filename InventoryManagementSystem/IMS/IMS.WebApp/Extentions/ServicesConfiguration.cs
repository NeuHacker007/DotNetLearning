using IMS.Plugins.EFCore;
using IMS.UserCases;
using IMS.UserCases.PluginInterfaces;

namespace IMS.WebApp.Extentions
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IViewInventoriesByNameUserCase, ViewInventoriesByNameUserCase>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
        }
    }
}
