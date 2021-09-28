using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;

namespace FactoryPattern.War3.Service
{
    public class Human : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine($"The king of {nameof(Human)} is Go Stop");
        }
    }

    public class HumanArmy : IArmy
    {
        public void ShowArmy()
        {
            Console.WriteLine("Show army");
        }
    }

    public class HumanHero : IHero
    {
        public void ShowHero()
        {
            Console.WriteLine("Show Hero");
        }
    }

    public class HumanResouce : IResource
    {
        public void ShowResource()
        {
            Console.WriteLine("Show Resource");
        }
    }
}
