using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericMethod
    {
        /// <summary>
        /// .NET 2.0 推出的新语法
        ///
        /// 泛型方法解决用一个方法, 满足不同参数类型; 做相同的事儿
        /// 
        /// 延迟声明: 把参数类型声明推迟到调用
        /// 不是语法糖，而是由框架升级提供的功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tPram"></param>
        public static void Show<T>(T tPram)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name}, type={tPram.GetType().Name}, param={tPram.ToString()} ");
        }
        public static void ShowObject(object oPram)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name}, type={oPram.GetType().Name}, param={oPram} ");
        }
    }
}
