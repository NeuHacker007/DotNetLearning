using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;

namespace FactoryPattern.AbstractFactory
{
    public class HumanFactory : AbstractFactory
    {
        public override IRace CreateRace()
        {
            return new Human();
        }

        public override IArmy CreateArmy()
        {
            return new HumanArmy();
        }

        public override IHero CreateHero()
        {
            return new HumanHero();
        }

        public override IResource CreateResource()
        {
            return new HumanResouce();
        }
    }
}
