using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
  
    internal class Program
    {
      
        static async Task Main(string[] args)
        {

             //testAsnc();
            Student student1 = new Student {
                
                Name = "Ivan"
                };

            var student2 = student1;
            
            student1 = null;
            Console.WriteLine($"{student2.Name}");
           // Console.WriteLine($"{student1.Name}");

             
            Console.WriteLine("Hello World");
        }

        public class Student
        {
            public string Name { get; set; }
        }

        public static async void testAsnc()
        {
            var factory = new TaskFactory();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var task = factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
            await task;

            Console.WriteLine("Test");
        } 

        public static async int test2Async()
        {
            


            
            return 1;
        }

    }
}
