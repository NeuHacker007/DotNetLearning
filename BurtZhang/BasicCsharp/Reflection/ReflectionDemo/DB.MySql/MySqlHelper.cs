using System;
using DB.Interface;

namespace DB.MySql
{
    public class MySqlHelper : IDBHelper
    {
        public MySqlHelper()
        {
            Console.WriteLine("{0} constructed", this.GetType().Name);
        }
        public void Query()
        {
            Console.WriteLine("{0} query", this.GetType().Name);
        }
    }
}
