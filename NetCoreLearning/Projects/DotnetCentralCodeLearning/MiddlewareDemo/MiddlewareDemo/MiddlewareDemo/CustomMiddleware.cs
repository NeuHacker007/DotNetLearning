using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiddlewareDemo
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPrinter _myPrinter;

        // Advantages of using custom middleware is that we can utilize the DI framework to implement complex logic
        // in different classes instead of implement them all in one place

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="myPrinter"></param>
        public CustomMiddleware(RequestDelegate next, IPrinter myPrinter)
        {
            _next = next;
            _myPrinter = myPrinter;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync($"Custom new middleware");

            await _next(httpContext);
            _myPrinter.Print();
        }
    }


}
