using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observer
{
    public class Mouse: IObserver
    {
        public void Run()
        {
            Console.WriteLine($"{nameof(Mouse)} run");
        }

        public void Action()
        {
            Run();
        }
    }
}
