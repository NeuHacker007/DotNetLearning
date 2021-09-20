using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
    public class Iphone : AbstractPhone
    {
        public override void Call()
        {
            Console.WriteLine("Call from Iphone");
        }

        public override void Text()
        {
            Console.WriteLine("Text from Iphone");
        }
    }
}
