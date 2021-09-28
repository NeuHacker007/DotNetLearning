using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;

namespace FactoryPattern.FactoryMethod
{
    public class NEFactory : IFactory
    {
        public IRace CreateRace()
        {
            return new NE();
        }
    }
}
