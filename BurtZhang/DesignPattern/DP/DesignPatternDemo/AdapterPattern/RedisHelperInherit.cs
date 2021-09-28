using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// 类适配器 模式
    ///
    /// 只能为RedisHelper这个类型服务，如果要为其他类型服务必须添加新类
    /// 
    /// 适配器： 满足IHelper 继承RedisHelper
    /// </summary>
    public class RedisHelperInherit: RedisHelper, IHelper
    {
        public void Add<T>()
        {
            base.AddRedis<T>();
        }

        public void Delete<T>()
        {
           base.DeleteRedis<T>();
        }

        public void Update<T>()
        {
            base.UpdateRedis<T>();
        }

        public void Query<T>()
        {
            base.QueryRedis<T>();
        }
    }
}
