using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingDemo
{
    public class OrderService
    {
        private readonly ILogger<OrderService> _logger;

        public OrderService(ILogger<OrderService> logger)
        {
            this._logger = logger;
        }

        public void Show()
        {
            // Difference between 
            //  1    _logger.LogInformation("Current Time: {time}", DateTime.Now);
            //  2    _logger.LogInformation($"Current Time: {DateTime.Now}");
            // 推荐使用1. 
            // 1，2 的 字符串拼接时机不同。 
            // 1， 会在需要输出时才拼接字符串 而 2，是先将字符串拼接好，然后再输出
            // 1 可以节省资源，如果把日志级别设置为none， 1，不会拼接字符串，而2，则会拼接无论是否输出
            // 若在热点路径中记录Debug信息，则会非常耗时
            _logger.LogInformation("Current Time: {time}", DateTime.Now);
            _logger.LogInformation($"Current Time: {DateTime.Now}");
        }
    }
}
