using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 多了一层： 包一层： 就是可以为所欲为
    ///
    /// 没有什么技术问题是包一层不能解决的，如果有，就再包一层
    /// 1.日志代理：业务操作要写日志 在不修改业务类的情况，增加了日志功能
    /// 2.延迟代理：需要的时候才去加载/实例化/占用
    /// 3.权限代理：
    /// 4.单例代理：
    /// 5.缓存代理： 在第一次获取之后， 把结果保存， 下一次直接用
    ///             推迟一切可以推迟的
    /// </summary>
    public class ProxySubject : ISubject
    {
        private ISubject _subject = null;

        /// <summary>
        /// 延迟实例化RealSubject对象
        /// </summary>
        private void Init()
        {
            if (_subject == null)
            {
                _subject = new RealSubject();
            }
            
        }
        
        // private readonly ISubject _subject = new RealSubject();
        



        // 静态的东西都是唯一的不会被释放的
        private static Dictionary<string, List<string>> dicCache = new Dictionary<string, List<string>>();

        public List<string> GetSomethingLong()
        {
            Console.WriteLine("prepare GetSomethingLong");
            string key = $"{nameof(ProxySubject)}_{nameof(GetSomethingLong)}";
            List<string> list;
            if (!dicCache.ContainsKey(key))
            {
                Init();
                list = _subject.GetSomethingLong();

                dicCache.Add(key, list);
            }
            else
            {
                list = dicCache[key];
            }
;
            return list;
        }

        public void DoSomethingLong()
        {
            Console.WriteLine("prepare DoSomethingLong");
            Init();
            _subject.DoSomethingLong();
        }
    }
}
