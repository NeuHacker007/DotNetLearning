using System;
using Castle.DynamicProxy;

namespace AutofacPractice.Services
{
    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Intercept before, Method: {invocation.Method.Name}");
            invocation.Proceed();
            Console.WriteLine($"Intercept after, Method: {invocation.Method.Name}");
        }
    }
}
