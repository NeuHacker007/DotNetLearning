using System.Linq;
using System.Collections.Generic;
using FakeXieCheng.API.Services;
using System.Linq.Dynamic.Core;
using System;

namespace FakeXieCheng.API.Extensions
{
    public static class IQueryableExtions
    {
        public static IQueryable<T> ApplySort<T>(
            this IQueryable<T> source,
            string orderBy,
            Dictionary<string, PropertyMappingValue> mappingDictionary
            )
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null");

            }

            if (mappingDictionary == null)
            {
                throw new ArgumentNullException($"{nameof(mappingDictionary)} cannot be null");
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            var orderByString = string.Empty;

            var orderByAfterSplit = orderBy.Split(',');


            foreach (var order in orderByAfterSplit)
            {
                var trimmedOrder = order.Trim();

                var orderDescending = trimmedOrder.EndsWith(" desc");

                var indexOfFirstSpace = trimmedOrder.IndexOf(" ");

                var propertyName = indexOfFirstSpace == -1 
                    ? trimmedOrder : trimmedOrder.Remove(indexOfFirstSpace);

                if (!mappingDictionary.ContainsKey(propertyName))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }

                var propertyMappingValue = mappingDictionary[propertyName];

                if (propertyMappingValue == null)
                {
                    throw new ArgumentNullException($"{nameof(propertyMappingValue)} cannot be null");
                }

                foreach (var destinationProperty in propertyMappingValue.DestinationProperties.Reverse())
                {
                    orderByString = orderByString + 
                        (string.IsNullOrWhiteSpace(orderByString) ? string.Empty : ", ")
                        + destinationProperty
                        + (orderDescending ? " descending" : " ascending");
                }
                
            }
            return source.OrderBy(orderByString);
        }
    }
}
