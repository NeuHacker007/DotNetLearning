using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.SqlServer
{
    public sealed class Singleton
    {
        private static Singleton _Singleton = null;
        private Singleton()
        {
            Console.WriteLine("Singleton is been constructed");
        }

        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetSingleton()
        {
            return _Singleton;
        }

    }
}
