using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExpressionDemo.Visitor;

namespace ExpressionDemo.DBExtend
{
    public static class ExpressionExtend
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp1,
            Expression<Func<T, bool>> exp2)
        {
            if (exp1 == null)
            {
                return exp2;
            }

            if (exp2 == null)
            {
                return exp1;
            }
            // 这种拼接方式在调用的时候会报 x not found。
            // 因为 表达式1 和表达式2 的 x 为不同的对象，
            // 而下面的拼接 使用的是表达式1的x.
            // return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(exp1.Body, exp2.Body), exp1.Parameters);

            ParameterExpression newParameter = Expression.Parameter(typeof(T), "c");

            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);

            var left = visitor.Replace(exp1.Body);
            var right = visitor.Replace(exp2.Body);
            var body = Expression.Add(left, right);

            return Expression.Lambda<Func<T, bool>>(body, newParameter);

        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            if (exp1 == null)
            {
                return exp2;
            }

            if (exp2 == null)
            {
                return exp1;
            }
            ParameterExpression newPara = Expression.Parameter(typeof(T), "c");

            NewExpressionVisitor visitor = new NewExpressionVisitor(newPara);

            var left = visitor.Replace(exp1.Body);
            var right = visitor.Replace(exp2.Body);

            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newPara);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> exp)
        {
            var candidateExp = exp.Parameters[0];

            var body = Expression.Not(exp.Body);

            return Expression.Lambda<Func<T, bool>>(body, candidateExp);
        }


    }
}
