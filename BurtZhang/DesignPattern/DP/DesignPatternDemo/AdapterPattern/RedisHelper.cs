using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// 第三方提供的， openStack Servicestack
    ///
    /// 不能修改
    /// </summary>
    public class RedisHelper
    {
        public void AddRedis<T>()
        {
            Console.WriteLine("Mysql Helper add");
        }

        public void DeleteRedis<T>()
        {
            Console.WriteLine("Mysql Helper delete");
        }

        public void UpdateRedis<T>()
        {
            Console.WriteLine("Mysql Helper update");
        }

        public void QueryRedis<T>()
        {
            Console.WriteLine("Mysql Helper query");
        }
    }
}
