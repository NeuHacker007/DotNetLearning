using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class OracleHelper: IHelper
    {
        public void Add<T>()
        {
            Console.WriteLine("Oracle Helper add");
        }

        public void Delete<T>()
        {
            Console.WriteLine("Oracle Helper Delete");
        }

        public void Update<T>()
        {
            Console.WriteLine("Oracle Helper Update");
        }

        public void Query<T>()
        {
            Console.WriteLine("Oracle Helper Query");
        }
    }
}
