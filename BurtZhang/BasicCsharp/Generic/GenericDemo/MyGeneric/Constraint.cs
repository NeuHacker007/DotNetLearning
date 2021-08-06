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
        /// 泛型约束 -- 基类约束: 保证T一定是people 或People的子类
        /// 1. 可以使用基类里面的一切属性方法
        /// 2. 强制保证T一定是People或者People子类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tPram"></param>
        public static void Show<T>(T tPram) 
            where T: People
        {
            Console.WriteLine($"{tPram.Id}_ {tPram.Name}");
            tPram.Hi();
        }
    }
}
