using IMS.CoreBusiness;

namespace IMS.UserCases
{
    public interface IViewInventoriesByNameUserCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name ="");
    }
}