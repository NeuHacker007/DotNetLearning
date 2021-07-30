using System;
using DB.Interface;

namespace DB.SqlServer
{
    public class SqlServerHelper : IDBHelper
    {
        public SqlServerHelper()
        {
            Console.WriteLine("{0} constructed", this.GetType().Name);
        }

        public void Query()
        {
            Console.WriteLine("{0} query", this.GetType().Name);
        }
    }
}
