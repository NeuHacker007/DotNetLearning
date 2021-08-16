using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public static class ExtendMethod
    {
        //扩展方法: 静态类里面的静态方法, 第一个参数类型前面加上this
        // 缺点:
        // 1. 如果实例中有相同名字的方法，会优先调用实例方法而非扩展方法(有隐患)
        // 2. 扩展基类型，导致任何子类都有这个方法，而且还有可能被覆盖
        // 尽量为指定类型进行扩展，不要对基类型扩展，约细节越好
        public static void Sing(this Student student)
        {
            Console.WriteLine($"{student.Name} Sing a Song");
        }

        public static int ToInt(this int? iValue, int defaultValue = 0)
        {
            return iValue ?? defaultValue;
        }
    }
}
