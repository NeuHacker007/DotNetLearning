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


        }
    }
}
