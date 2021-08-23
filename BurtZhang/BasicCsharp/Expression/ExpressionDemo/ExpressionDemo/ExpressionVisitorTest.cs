using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExpressionDemo.Visitor;

namespace ExpressionDemo
{
    public class ExpressionVisitorTest
    {
        private static int Get(int k)
        {
            return k;
        }
        public static void Show()
        {
            {
                Expression<Func<int, int, int>> exp = (x, y) => x * y + 2;

                // 此时需求更改，需要将 x*y + 2 变成 x*y -2， 首先需要解析上面的expression 需要用到ExpressionVisitor类
                OperationVisitor visitor = new OperationVisitor();

                Expression expNew = visitor.Modify(exp);
            }

            {
                Expression<Func<int, int, int>> exp1 = (m, n) => m * n + 2 + 3 + Get(m);
                OperationVisitor visitor = new OperationVisitor();

                Expression expNew = visitor.Modify(exp1);
            }

            {
                //用处

                {
                    var source = new List<People>().AsQueryable();

                    var result = source?.Where<People>(p => p.Age > 5); // Select * from People Where Age > 5

                    Expression<Func<People, bool>> lambda = x => x.Age > 5;

                    ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
                    visitor.Visit(lambda);
                    Console.WriteLine(visitor.Condition());
                }

                {
                    Expression<Func<People, bool>> lambda = x => x.Age > 5
                                                                 && x.Id > 5
                                                                 && x.Name.StartsWith("I")
                                                                 && x.Name.EndsWith("n")
                                                                 && x.Name.Contains("n");

                    var sql = string.Format("Delete from [{0}] where {1}", nameof(People), " [Age] > 5 AND [ID] > 5");

                    ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();

                    visitor.Visit(lambda);
                    Console.WriteLine(visitor.Condition());


                }
            }


        }
    }
}
