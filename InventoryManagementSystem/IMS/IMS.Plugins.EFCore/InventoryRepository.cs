using IMS.CoreBusiness;
using IMS.UserCases.PluginInterfaces;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        public Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}