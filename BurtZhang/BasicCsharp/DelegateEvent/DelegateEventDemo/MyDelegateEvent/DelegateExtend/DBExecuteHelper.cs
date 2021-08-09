using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.DelegateExtend
{
    public class DBExecuteHelper
    {

        public void Execute(string sql)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                Console.WriteLine("");
            }
        }
        public static void SafeInvoke(Action act)
        {
            try
            {
                act.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
    }
}
