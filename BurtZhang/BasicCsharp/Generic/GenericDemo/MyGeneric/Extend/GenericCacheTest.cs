using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGeneric.Extend
{
    public class GenericCacheTest
    {
        public static void Show()
        {
            for (int i = 0; i < 5; i++)
            {

                // 泛型缓存, 在首次调用的时候 初始化,
                // 后续直接调用缓存 比Dictionary based 快很多
                Console.WriteLine(GenericCache<int>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<long>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<DateTime>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<string>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<GenericCacheTest>.GetCache());
                Thread.Sleep(10);
                
            }
        }

    }

    public class DictionaryCache
    {
        private static Dictionary<Type, string> _typeTimeDictionary = null;

        static DictionaryCache()
        {
            Console.WriteLine("this is DictionaryCache static constructor");
            _typeTimeDictionary = new Dictionary<Type, string>();
        }

        public static string GetCache<T> ()
        {
            Type type = typeof(T);

            if (!_typeTimeDictionary.ContainsKey(type))
            {
                _typeTimeDictionary[type] =$"{typeof(T).FullName}_{DateTime.Now.ToString()}"; 
            }

            return _typeTimeDictionary[type];
        }
    }
    /// <summary>
    /// 每个不同的T，都会生成一份不同的副本
    /// 适合不同类型， 需要缓存一份数据的场景，效率高
    /// 缺点，为不同类只能保存一次
    /// 不能主动释放
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCache<T>
    {
        private static string _TypeTime = "";
        static GenericCache()
        {
            Console.WriteLine("This is a static constructor of Generic Cache");
            _TypeTime = $"{typeof(T).FullName}_{DateTime.Now.ToString()}";
        }

        public static string GetCache ()
        {
            return _TypeTime;
        }
    }
}
