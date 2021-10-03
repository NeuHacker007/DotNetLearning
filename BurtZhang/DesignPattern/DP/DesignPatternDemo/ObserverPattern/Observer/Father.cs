using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observer
{
    public class Father: IObserver
    {
        public void Roar()
        {
            Console.WriteLine($"{nameof(Father)} Roar");
        }

        public void Action()
        {
            Roar();
        }
    }
}
