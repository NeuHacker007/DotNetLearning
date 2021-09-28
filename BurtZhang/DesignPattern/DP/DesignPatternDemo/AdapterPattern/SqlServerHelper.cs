using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class SqlServerHelper : IHelper
    {
        public void Add<T>()
        {
            Console.WriteLine("SQL Server Helper Add");
        }

        public void Delete<T>()
        {
            Console.WriteLine("SQL Server Helper delete");
        }

        public void Update<T>()
        {
            Console.WriteLine("SQL Server Helper Update");
        }

        public void Query<T>()
        {
            Console.WriteLine("SQL Server Helper Query");
        }
    }
}
