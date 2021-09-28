using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class MysqlHelper: IHelper
    {
        public void Add<T>()
        {
            Console.WriteLine("Mysql Helper add");
        }

        public void Delete<T>()
        {
            Console.WriteLine("Mysql Helper delete");
        }

        public void Update<T>()
        {
            Console.WriteLine("Mysql Helper update");
        }

        public void Query<T>()
        {
            Console.WriteLine("Mysql Helper query");
        }
    }
}
