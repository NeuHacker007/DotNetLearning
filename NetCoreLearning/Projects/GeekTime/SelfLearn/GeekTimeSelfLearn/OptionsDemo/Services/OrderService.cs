﻿using Microsoft.Extensions.Options;
using System;

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
        public int MaxOrderCount { get; set; } = 100;
    }
}
