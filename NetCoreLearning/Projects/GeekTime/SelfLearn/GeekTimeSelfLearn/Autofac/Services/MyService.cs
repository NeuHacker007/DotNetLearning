using System;

namespace Autofac.Services
{
    public interface IMyService
    {
        void ShowCode();
    }
    public class Myservice : IMyService
    {
        public void ShowCode()
        {
            Console.WriteLine($"MyService.ShowCode: {GetHashCode()}");
        }
    }
    public class MyServiceV2 : IMyService
    {
        public MyNameService NameService { get; set; }
        public void ShowCode()
        {
            Console.WriteLine($"MyServiceV2.ShowCode: {GetHashCode()}, NameService is empty: {NameService == null}");
        }
    }

    public class MyNameService
    {

    }
}
