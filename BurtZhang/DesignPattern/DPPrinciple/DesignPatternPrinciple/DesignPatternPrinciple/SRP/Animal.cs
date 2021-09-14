using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.SRP
{
    public class Animal
    {
        private string _Name = null;

        public Animal(string name)
        {
            this._Name = name;
        }

        public void Breath()
        {
            Console.WriteLine($"{_Name} Breath");
        }

        public void Action()
        {
            Console.WriteLine($"{_Name} Fly");
        }
    }
}
