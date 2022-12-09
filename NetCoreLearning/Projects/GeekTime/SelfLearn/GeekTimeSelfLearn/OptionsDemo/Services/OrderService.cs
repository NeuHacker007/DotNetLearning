using Microsoft.Extensions.Options;

namespace OptionsDemo.Services
{
    public interface IOrderService
    {
        int ShowMaxOrderCount();
    }

    public class OrderService : IOrderService
    {
        private IOptionsSnapshot<OrderServiceOptions> _options;
        public OrderService(IOptionsSnapshot<OrderServiceOptions> options)
        {
            _options = options;
        }

        public int ShowMaxOrderCount()
        {
            return _options.Value.MaxOrderCount;
        }
    }

    public class OrderServiceOptions
    {
        public int MaxOrderCount { get; set; } = 100;
    }
}
