using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observer
{
    public class Neighbor: IObserver
    {
        public void Awake()
        {
            Console.WriteLine($"{nameof(Neighbor)} awake");
        }

        public void Action()
        {
            Awake();
        }
    }
}
