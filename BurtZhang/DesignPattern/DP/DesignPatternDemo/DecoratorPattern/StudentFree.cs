using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class StudentFree : AbstractStudent
    {
        public override void Study()
        {
            Console.WriteLine("Learn Free");
        }
    }
}
