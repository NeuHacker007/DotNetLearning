using System;

namespace ScopeDisposal.Services
{
    public interface IOrderService
    {

    }
    public class DisposableOrderService : IOrderService, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine($"DisposableOrderService disposed: {this.GetHashCode()}");
        }
    }

    public class OrderService : IOrderService
    {
        
    }
}
