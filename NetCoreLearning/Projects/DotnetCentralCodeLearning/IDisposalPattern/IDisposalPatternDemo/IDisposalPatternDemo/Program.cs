using System;

namespace IDisposalPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // using is nothing but try finally clause. 
            // if we use the following style then the resource will be release
            // when code reaches the end curly brace. But if we want release earlier
            // then we need to use
            // using () {} style
            // using var serviceProxy = new ServiceProxy(null);
            // if we are not use using keyword then this object will not be collected by the GC
            // which causes the memory leakage;
            // To solve that we have to implement a finalizer method within ServiceProxy.
            // See service proxy class for details
            var serviceProxy = new ServiceProxy(null);

            serviceProxy.Get();
            serviceProxy.Post("");
        }
    }
}
