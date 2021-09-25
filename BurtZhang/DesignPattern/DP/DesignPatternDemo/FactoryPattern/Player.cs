using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.War3.Interface;

namespace FactoryPattern
{
    class Player
    {
        public void PlayWar3(IRace race)
        {
            race.ShowKing();
            Console.WriteLine($"PlayWar3 is playing {nameof(race)}");
        }
    }
}
