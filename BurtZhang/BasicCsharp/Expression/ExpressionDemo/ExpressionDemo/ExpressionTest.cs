using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    public class ExpressionTest
    {
        public static void Show()
        {
            {
                Func<int, int, int> func = (m, n) => m * 2 + 2; // lambda 只是一个方法

                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;//lambda 表达式声明 表达式目录树

                //Expression<Func<int, int, int>> exp1 = (m, n) => // 表达式目录树只能一行，不能有大括号
                //{
                //    return m * n + 2;
                //};


                // 表达式目录树: 语法树， 或者说一种数据结构；可以被我们解析。
                int iResult1 = func.Invoke(12, 23);
                int iResult2 = exp.Compile().Invoke(12, 23); // Compile 之后返回的是一个委托实例

                Console.WriteLine();
            }
            {

            }
        }
    }
}
