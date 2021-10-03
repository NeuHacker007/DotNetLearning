using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observer
{
     public class Stealer: IObserver
    {
        public void Hide()
        {
            Console.WriteLine($"{nameof(Stealer)} hide");
        }

        public void Action()
        {
            Hide();
        }
    }
}
