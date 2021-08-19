using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    public class ExpressionMapper
    {
        private static Dictionary<string, object> _Dic = new Dictionary<string, object>();
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            var key = $"funckey_{typeof(TIn).FullName}_{typeof(TOut).FullName}";

            if (!_Dic.ContainsKey(key))
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

                Func<TIn, TOut> func = lambda.Compile();
                _Dic[key] = func;

            }

            return ((Func<TIn, TOut>) _Dic[key])(tIn);
        }
    }
}
