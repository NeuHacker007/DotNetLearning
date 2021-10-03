using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observer
{
    public class Dog : IObserver
    {
        public void Wang()
        {
            Console.WriteLine($"{nameof(Dog)} Wang");
        }

        public void Action()
        {
            Wang();
        }
    }
}
