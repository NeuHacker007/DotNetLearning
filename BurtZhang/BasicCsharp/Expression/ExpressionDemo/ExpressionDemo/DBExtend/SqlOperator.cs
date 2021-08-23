using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.DBExtend
{
    static class SqlOperator
    {
        internal static string ToSqlOperator(this ExpressionType type)
        {
           var result = type switch
            {
                var x when x == ExpressionType.AndAlso
                                    ||  x == ExpressionType.Add => "AND",
                var x when x == ExpressionType.OrElse
                                    || x == ExpressionType.Or => "OR",
                ExpressionType.Not => "NOT",
                ExpressionType.NotEqual => "<>",
                ExpressionType.GreaterThan => ">",
                ExpressionType.GreaterThanOrEqual => ">=",
                ExpressionType.LessThan => "<",
                ExpressionType.LessThanOrEqual => "<=",
                ExpressionType.Equal => "=",
                _ => throw new NotSupportedException("Operator is not supported")


            };

           return result;
        }
    }
}
