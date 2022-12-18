using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;

namespace OptionsDemo.Services
{
    public interface IOrderService
    {
        int ShowMaxOrderCount();
    }

    public class OrderService : IOrderService
    {
        private IOptionsMonitor<OrderServiceOptions> _options;
        public OrderService(IOptionsMonitor<OrderServiceOptions> options)
        {
            _options = options;
            _options.OnChange((options) =>
            {
                Console.WriteLine($"new value = {options.MaxOrderCount}");
            });
        }

        public int ShowMaxOrderCount()
        {
            return _options.CurrentValue.MaxOrderCount;
        }
    }

    public class OrderServiceOptions
    {
        [Range(1, 20)]
        public int MaxOrderCount { get; set; } = 100;
    }

    public class OrderServiceValidateOptions : IValidateOptions<OrderServiceOptions>
    {
        ValidateOptionsResult IValidateOptions<OrderServiceOptions>.Validate(string name, OrderServiceOptions options)
        {
            if (options.MaxOrderCount > 100)
            {
                return ValidateOptionsResult.Fail("MaxOrderCount Cannot Great 100");
            } else
            {
                return ValidateOptionsResult.Success; 
            }
        }
    }
}
