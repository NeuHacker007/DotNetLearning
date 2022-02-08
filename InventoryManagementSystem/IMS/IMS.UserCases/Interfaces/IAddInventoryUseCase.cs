using IMS.CoreBusiness;

namespace IMS.UserCases
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}