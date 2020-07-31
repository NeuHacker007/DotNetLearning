using System;
using System.Collections.Generic;
using System.Text;

namespace LinqInternalDemo
{
    public static class EnumerableExtension
    {
        // this is an extension method.
        public static IEnumerable<T> NewWhere<T>(this IEnumerable<T> items, Func<T, bool> predicateFunc)
        {
            foreach (var item in items)
            {
                if (predicateFunc(item))
                {
                    // here yield has the delay execution effects
                    // only if the IEnumerable derived class call ToList/ ToArray or loop through,
                    // the data will be filtered out.Otherwise, it just generate a query.
                    yield return item;
                }
            }
        }
    }
}
