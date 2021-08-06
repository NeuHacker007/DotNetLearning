using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class CommonMethod
    {
        public static void ShowInt(int iPram)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name}, type={iPram.GetType().Name}, param={iPram} ");
        }
        public static void ShowString(string sPram)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name}, type={sPram.GetType().Name}, param={sPram} ");
        }
        public static void ShowDateTime(DateTime dtPram)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name}, type={dtPram.GetType().Name}, param={dtPram} ");
        }

        /// <summary>
        /// 1. object 类型是一切类型的父类
        /// 2. 通过继承，子类拥有父类一切的属性和行为；
        ///    任何父类出现的地方都可以用子类代替
        /// .NET Framework 1.0 1.1写法
        ///
        /// object 应用类型， 假如传个值类型int，会有装箱，拆箱，有性能损失。
        ///
        /// 类型不安全
        /// </summary>
        /// <param name="oPram"></param>
        public static void ShowObject(object oPram)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name}, type={oPram.GetType().Name}, param={oPram} ");


            // this will throw exception when Japenese comes in because it doesn't inherit from People
           // Console.WriteLine($"{ ((People) oPram).Id }_{((People)oPram).Name}");
        }
    }
}
