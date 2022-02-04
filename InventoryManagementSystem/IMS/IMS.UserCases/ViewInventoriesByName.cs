using IMS.CoreBusiness;
using IMS.UserCases.PluginInterfaces;

namespace IMS.UserCases
{
    public class ViewInventoriesByName
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByName(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name)
        {
            return await this.inventoryRepository.GetInventoriesByName(name);
        }
    }
}