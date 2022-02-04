using IMS.CoreBusiness;
using IMS.UserCases.PluginInterfaces;

namespace IMS.UserCases
{
    public class ViewInventoriesByNameUserCase : IViewInventoriesByNameUserCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByNameUserCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await this.inventoryRepository.GetInventoriesByName(name);
        }
    }
}