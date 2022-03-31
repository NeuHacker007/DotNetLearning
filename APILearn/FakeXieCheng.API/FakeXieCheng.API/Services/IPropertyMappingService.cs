﻿using System.Collections.Generic;

namespace FakeXieCheng.API.Services
{
    public interface IPropertyMappingService
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
        bool IsMappingExists<TSource, TDestination>(string fields);
        bool IsPropertyExists<T>(string fields);
    }
}