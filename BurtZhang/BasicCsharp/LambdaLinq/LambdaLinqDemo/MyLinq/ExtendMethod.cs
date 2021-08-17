using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public static class ExtendMethod
    {

        /// <summary>
        /// 加迭代器，按需获取(延迟获取)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<T> GIenumerableWhere<T>(this IEnumerable<T> tList, Func<T, bool> func)
        {
          //  var list = new List<T>();

            foreach (var t in tList)  
            {
                if (func.Invoke(t))
                {
                    yield return t;
                }
            }
            
        }

        /// <summary>
        /// 泛型，应对各种类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<T> GenericWhere<T>(this List<T> tList, Func<T, bool> func)
        {
            var list = new List<T>();

            foreach (var t in tList)  
            {
                if (func.Invoke(t))
                {
                    list.Add(t);
                }
            }

            return list;
        }
        
        /// <summary>
        /// 基于委托封装解耦，去掉重复代码，完成通用代码
        /// </summary>
        /// <param name="students"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<Student> IvanWhere(this List<Student> students, Func<Student, bool> func)
        {
            var list = new List<Student>();

            foreach (var student in students)  
            {
                if (func.Invoke(student))
                {
                    list.Add(student);
                }
            }

            return list;
        }

        //可以使用泛型写扩展方法，但是最好加上约束
        //否则等同于为所有类型添加该方法
        public static void Show<T> (this T t) where T : Student
        {

        }
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
