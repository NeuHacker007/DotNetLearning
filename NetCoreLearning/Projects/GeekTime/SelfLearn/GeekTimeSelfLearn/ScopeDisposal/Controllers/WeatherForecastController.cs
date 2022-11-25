using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ScopeDisposal.Services;

namespace ScopeDisposal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get([FromServices] IOrderService orderService, [FromServices] IOrderService orderService2)
        {
            Console.WriteLine("==============1===============");
            // HttpContext.RequestServices 当前请求的根容器, 每个请求都会有一个当前请求的根容器
            using (IServiceScope scope = HttpContext.RequestServices.CreateScope())
            {
                //子作用域， 子作用域内多个请求为单例
                var service = scope.ServiceProvider.GetService<IOrderService>();
                var service2 = scope.ServiceProvider.GetService<IOrderService>();
                
            }
            Console.WriteLine("==============2===============");
            Console.WriteLine("Interface request end");
            return 1;
        }
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
