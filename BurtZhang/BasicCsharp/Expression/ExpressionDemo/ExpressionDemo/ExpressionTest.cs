﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExpressionDemo.DBExtend;

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

            {
                // 用处1
                {
                    string sql = "Select * from user where 1=1";
                    string name = "ivan";

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        sql += $" and name like '%{name}%'";
                    }
                }

                {
                    //现在entity framework查询的时候，都需要一个表达式目录树

                    IQueryable<int> list = null;

                    if (true) //过滤A
                    {
                        Expression<Func<People, bool>> exp1 = x => x.Id > 1;
                    }

                    if (true) //过滤B
                    {
                        Expression<Func<People, bool>> exp2 = x => x.Age > 10;
                    }

                    // 都过滤
                    Expression<Func<People, bool>> exp3 = x => x.Age > 10 && x.Id > 1;
                    {
                        // 表达式链接
                        Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
                        Expression<Func<People, bool>> lambda2 = x => x.Id > 5;
                        Expression<Func<People, bool>> lambda3 = lambda1.And(lambda2);
                        Expression<Func<People, bool>> lambda4 = lambda1.Or(lambda2);
                        Expression<Func<People, bool>> lambda5 = lambda1.Not();

                        Do1(lambda3);

                        
                    }
                    // Copy People 属性
                    {
                        {
                            // 写死了 只能为这两种类型服务, 性能最好因为硬编码
                            People people = new People()
                            {
                                Id = 1,
                                Name = "Ivan",
                                Age = 32
                            };

                            PeopleCopy peopleCopy = new PeopleCopy()
                            {
                                Id = people.Id,
                                Name = people.Name,
                                Age = people.Age
                            };
                        }

                        {
                            // 利用反射: 不同类型都能实现
                            People people = new People()
                            {
                                Id = 1,
                                Name = "Ivan",
                                Age = 32
                            };
                            var result = ReflectionMapper.Trans<People, PeopleCopy>(people);
                        }
                        {
                            People people = new People()
                            {
                                Id = 1,
                                Name = "Ivan",
                                Age = 32
                            };
                            //序列化器

                            var result = SerializeMapper.Trans<People, PeopleCopy>(people);
                        }
                        {
                            People people = new People()
                            {
                                Id = 1,
                                Name = "Ivan",
                                Age = 32
                            };
                            //1. 通用 2. 性能要高
                            // 能不能动态的生成硬编码,缓存起来
                            Expression<Func<People, PeopleCopy>> lambda = p => new PeopleCopy()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Age = p.Age
                            };

                            ExpressionMapper.Trans<People, PeopleCopy>(people);
                        }
                       

                    }
                }


                


            }
        }

        private static void Do1(Expression<Func<People, bool>> func)
        {
            List<People> peoples = new List<People>()
            {
                new People() {Id = 4, Name = "Ivan", Age = 4},
                new People() {Id = 5, Name = "Ivan", Age = 5},
                new People() {Id = 6, Name = "Ivan", Age = 6}
            };

            List<People> peoplesList = peoples.Where(func.Compile()).ToList();
        }
    }
}
