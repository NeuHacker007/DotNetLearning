using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.SqlServer
{
    public class ReflectionTest
    {
        public ReflectionTest()
        {
            Console.WriteLine("this is {0} parameterless constructor", this.GetType());
        }

        public ReflectionTest(string name)  
        {
            Console.WriteLine("this is {0} parameter constructor", this.GetType());
        }
        public ReflectionTest(int id)  
        {
            Console.WriteLine("this is {0} parameter constructor", this.GetType());
        }

        public void Show1()
        {
            Console.WriteLine("this is {0} 's show 1", this.GetType());
        }
        
        public void Show2(int id)
        {
            Console.WriteLine("this is {0} 's show 2", this.GetType());
        }
        public void Show3(int id, string name)
        {
            Console.WriteLine("this is {0} 's show 3", this.GetType());
        }
        public void Show3(int id)
        {
            Console.WriteLine("this is {0} 's show 3_3", this.GetType());
        }
        public void Show3(string name)
        {
            Console.WriteLine("this is {0} 's show 3_4", this.GetType());
        }
        public void Show3()
        {
            Console.WriteLine("this is {0} 's show 3_1", this.GetType());
        }

        private void Show4(string name)
        {
            Console.WriteLine("this is {0} 's show 4", this.GetType());
        }
        public static void Show5(string name)
        {
            Console.WriteLine("this is {0} 's show 5", typeof(ReflectionTest));
        }
    }
    
}
