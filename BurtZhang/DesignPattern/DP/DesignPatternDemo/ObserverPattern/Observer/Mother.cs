using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observer
{
    public class Mother: IObserver
    {
        public void Wispher()
        {
            Console.WriteLine($"{nameof(Mother)} Wispher");
        }

        public void Action()
        {
            Wispher();
        }
    }
}
