using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.SRP
{
    public class Animal
    {
        protected string _Name = null;

        public Animal(string name)
        {
            this._Name = name;
        }

        public virtual void Breath()
        {
            // If else 很多导致维护困难，每添加一个动物都要修改if else
            // 需要拆分
            if (_Name.Equals("Chicken"))
            {
                Console.WriteLine($"{_Name} Breath Air");
            }
            else if (_Name.Equals("fish"))
            {
                Console.WriteLine($"{_Name} Breath water");
            }
            //...

        }

        public virtual void Action()
        {
            if (_Name.Equals("Chicken"))
            {
                Console.WriteLine($"{_Name} flying");
            }
            else if (_Name.Equals("fish"))
            {
                Console.WriteLine($"{_Name} swimming");
            }
            // ...
        }
    }

    public class Chicken : Animal
    {
        public Chicken(string name): base(name)
        {
            
        }

        public override void Breath()
        {
            Console.WriteLine($"{_Name} Breath Air");
        }

        public override void Action()
        {
            Console.WriteLine($"{_Name} flying");
        }
    }

    public class Fish : Animal
    {
        public Fish(string name): base(name)
        {
            
        }

        public override void Breath()
        {
            Console.WriteLine($"{_Name} Breath water");
        }

        public override void Action()
        {
            Console.WriteLine($"{_Name} swimming");
        }
    }
}
