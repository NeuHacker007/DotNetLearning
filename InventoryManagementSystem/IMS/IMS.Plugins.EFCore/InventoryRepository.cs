using IMS.CoreBusiness;
using IMS.UserCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext context;

        public InventoryRepository(IMSContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
          return await this.context.Inventories.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                                || string.IsNullOrWhiteSpace(name))
                                               .ToListAsync();
        }
    }
}