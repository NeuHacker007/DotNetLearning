using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI.Services;

namespace DI.Controllers
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
        public IEnumerable<WeatherForecast> Get(
            [FromServices] IMySingletonService singleton1,
            [FromServices] IMySingletonService singleton2,
            [FromServices] IMyTransitService transitService1,
            [FromServices] IMyTransitService transitService2,
            [FromServices] IMyScopeService scopeService1,
            [FromServices] IMyScopeService scopeService2)
        {
            Console.WriteLine($"singleton1: {singleton1.GetHashCode()}");
            Console.WriteLine($"singleton2: {singleton2.GetHashCode()}");
            Console.WriteLine($"transitService1: {transitService1.GetHashCode()}");
            Console.WriteLine($"transitService2: {transitService2.GetHashCode()}");
            Console.WriteLine($"scopeService1: {scopeService1.GetHashCode()}");
            Console.WriteLine($"scopeService2: {scopeService2.GetHashCode()}");

            Console.WriteLine($"==========END==========");

            return Enumerable.Empty<WeatherForecast>();
        }

        [HttpGet("GetServices")]
        public int GetServices([FromServices] IEnumerable<IOrderService> services)
        {
            foreach (var orderService in services)
            {
                Console.WriteLine($"Instance get: {orderService.ToString()} : {orderService.GetHashCode()}");
            }

            return 1;
        }
    }
}
