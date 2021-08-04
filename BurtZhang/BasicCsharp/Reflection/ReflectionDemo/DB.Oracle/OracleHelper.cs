using System;
using DB.Interface;

namespace DB.Oracle
{
    public class OracleHelper : IDBHelper
    {
        public OracleHelper()
        {
            Console.WriteLine("Oracle is constructed");
        }
        public void Query()
        {
            Console.WriteLine("Oracle");
        }
    }
}
