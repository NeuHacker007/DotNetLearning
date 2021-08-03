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

    }
    
}
