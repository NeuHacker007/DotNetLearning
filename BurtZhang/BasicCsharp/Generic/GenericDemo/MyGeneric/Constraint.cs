using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Constraint
    {
        /// <summary>
        /// 泛型： 不同参数类型都能进来；任何类型都能进来，你知道我是谁？
        /// 泛型约束 -- 基类约束: 保证T一定是people 或People的子类 （不能是sealed）
        /// 1. 可以使用基类里面的一切属性方法
        /// 2. 强制保证T一定是People或者People子类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tPram"></param>
        public static void Show<T>(T tPram) 
            where T: People//, ISports, IWork
        {
            Console.WriteLine($"{tPram.Id}_ {tPram.Name}");
            tPram.Hi();
            //tPram.PingPang();
            //tPram.Work();
        }
        // 为啥不直接用基类： 约束可以叠加，更灵活
        // 此实现与 line 19 - line24效果一样
        // 但是使用泛型约束可以不止局限在People
        // 可以让它既是people 或 people 子类， 也可以同时
        // 是ISports, IWork
        public static void ShowBase(People peop)
        {
            Console.WriteLine($"{peop.Id}_ {peop.Name}");
            peop.Hi();
        }

        // 可以使用Int32来约束么？
        // 不可以，用基类约束不能使用 sealed 的类
        public static T Get<T>(T t)
            //where T : ISports //接口约束, 一定是实现了该接口的
            //where T : class // 引用类型约束： 引用类型 （可以被设置为null的）
            //where T : struct // 值类型约束: 值类型
              where T : new() //无参数构造函数
        {
            /// t.PingPang();
            //T tNew = null;
            // T tnew = 0; //不行
            T tnew = default(T); //会根据T的不同 赋予默认值 不约束也可以直接写
            T tNew = new T();
            return t;
        }
    }
}
