using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;

namespace FactoryPattern.War3.Service
{
    class Human : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine($"The king of {nameof(Human)} is Go Stop");
        }
    }
}
