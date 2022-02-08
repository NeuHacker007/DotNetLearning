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
          return await this.context.Inventories.Where(x => x != null 
                                                           && x.Name != null 
                                                           && x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                                           || string.IsNullOrWhiteSpace(name))
                                               .ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            await this.context.AddAsync(inventory);
            await this.context.SaveChangesAsync();
        }
    }
}