using System;
using DB.Interface;
using DB.MySql;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*************************");

                IDBHelper helper = new MySqlHelper();
                helper.Query();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //throw;
            }

            Console.ReadLine();
        }
    }
}
