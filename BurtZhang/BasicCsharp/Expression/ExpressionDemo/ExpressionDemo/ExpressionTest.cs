using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
                //lambda 写法
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
                // 不用lambda的写法

                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");

                BinaryExpression multiply = Expression.Multiply(parameterExpression, parameterExpression2);
                ConstantExpression constant = Expression.Constant(2, typeof(int));
                BinaryExpression add = Expression.Add(multiply, constant);

                Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(
                    add,
                    new ParameterExpression[]
                    {
                        parameterExpression,
                        parameterExpression2
                    });
            }

            {
                ConstantExpression conLeft = Expression.Constant(345);
                ConstantExpression conRight = Expression.Constant(234);

                BinaryExpression add = Expression.Add(conLeft, conRight);

                Expression<Action> actExpression = Expression.Lambda<Action>(add, null); // ()=>345 + 456;
                actExpression.Compile()();
            }
            {
                Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "x");
                var field = Expression.Field(parameterExpression, typeof(People).GetField("Id"));
                var toString = typeof(People).GetMethod("ToString");
                var equals = typeof(People).GetMethod("Equals");

                var body = Expression.Call(
                    Expression.Call(
                        field,
                        toString,
                        new Expression[0]),
                    equals,
                    new Expression[]
                    {
                        Expression.Constant("5", typeof(string))
                    });
                
                Expression<Func<People, bool>> expression = Expression.Lambda<Func<People, bool>>(
                        body,
                        new ParameterExpression[]
                        {
                            parameterExpression
                        }

                        );

               var result = expression.Compile()(new People()
                {
                    Id = 5
                });

               Console.WriteLine(result);
            }
        }
    }
}
