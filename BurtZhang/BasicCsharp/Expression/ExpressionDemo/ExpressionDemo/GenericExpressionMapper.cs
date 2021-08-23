using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 利用泛型缓存，只要 泛型类型一样，就不用再执行解析过程，直接返回。
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class GenericExpressionMapper<TIn, TOut>
    {
        private static Func<TIn, TOut> _func = null;
         static GenericExpressionMapper()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindings = new List<MemberBinding>();

            foreach (var item in typeof(TOut).GetProperties())
            {
                MemberExpression property =
                    Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);

                memberBindings.Add(memberBinding);
            }

                
            foreach (var item in typeof(TOut).GetFields())
            {
                MemberExpression property =
                    Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);

                memberBindings.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(
                Expression.New(typeof(TOut)),
                memberBindings.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(
                memberInitExpression,
                new ParameterExpression[]
                {
                    parameterExpression
                }
            );

            _func = lambda.Compile();
        }

         public static TOut Trans(TIn tIn)
         {
             return _func(tIn);
         }
    }
}
