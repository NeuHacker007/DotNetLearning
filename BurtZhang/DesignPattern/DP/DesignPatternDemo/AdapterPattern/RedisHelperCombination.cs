using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// 对象适配器
    /// 适配器： 满足IHelper 组合RedisHelper
    /// </summary>
    public class RedisHelperCombination : IHelper
    {
        /// <summary>
        /// 1. 字段属性方式组合
        ///     默认构造 特别强烈的关系，而且写死了
        /// </summary>
        private readonly RedisHelper _redisHelper = new RedisHelper(); //组合

        private RedisHelper _redisHelperCtor = null;
        /// <summary>
        /// 2. 构造函数组合方式
        ///     实例化会一定传入， 但是对象可以选择
        /// </summary>
        /// <param name="redisHelper"></param>
        public RedisHelperCombination(RedisHelper redisHelper)
        {
            _redisHelperCtor = redisHelper;
        }

        public RedisHelperCombination()
        {
            
        }
        /// <summary>
        /// 3. 方法方式组合
        ///    对象可以选择， 而且可有可无
        /// </summary>
        /// <param name="redisHelper"></param>
        public void AddRedisHelper(RedisHelper redisHelper)
        {
            _redisHelperCtor = redisHelper;
        }
        public void Add<T>()
        {
            _redisHelper.AddRedis<T>();
        }

        public void Delete<T>()
        {
           _redisHelper.DeleteRedis<T>();
        }

        public void Update<T>()
        {
            _redisHelper.UpdateRedis<T>();
        }

        public void Query<T>()
        {
            _redisHelper.QueryRedis<T>();
        }
    }
}
