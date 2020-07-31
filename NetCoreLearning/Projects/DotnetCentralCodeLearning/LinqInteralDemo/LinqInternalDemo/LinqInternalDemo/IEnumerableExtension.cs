using System;
using System.Collections.Generic;
using System.Linq;
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


        public static IEnumerable<TResult> NewSelect<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector)
        {
            foreach (var item in items)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> NewSelectMany<T, TResult>(this IEnumerable<T> items, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in items)
            {
                foreach (var innerItem in selector(item))
                {
                    yield return innerItem;
                }
            }

        }

        public static IEnumerable<TResult> NewJoin<T, TH, TKey, TResult>(
            this IEnumerable<T> items,
            IEnumerable<TH> innerItems,
            Func<T, TKey> outerKeySelector,
            Func<TH, TKey> innerKeySelector,
            Func<T, TH, TResult> resultSelector)
        {
            foreach (var item in items)
            {
                foreach (var innerItem in innerItems)
                {
                    if (outerKeySelector(item).Equals(innerKeySelector(innerItem)))
                    {
                        yield return resultSelector(item, innerItem);
                    }

                }
            }
        }
    }
}
