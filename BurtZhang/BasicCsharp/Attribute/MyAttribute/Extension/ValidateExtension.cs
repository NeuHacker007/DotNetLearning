using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extension
{
    public static class ValidateExtension
    {
        public static bool Validate(this object oObj)
        {
            Type type = oObj.GetType();

            foreach (var propertyInfo in type.GetProperties())
            {
                if (propertyInfo.IsDefined(typeof(LongAttribute), true))
                {
                    if (propertyInfo.GetCustomAttribute(typeof(LongAttribute), true) is LongAttribute attribute 
                        && !attribute.Validate(propertyInfo.GetValue(oObj)))
                    {
                        return false;
                    }
                }
                if (propertyInfo.IsDefined(typeof(LengthAttribute), true))
                {
                    if (propertyInfo.GetCustomAttribute(typeof(LengthAttribute), true) is LengthAttribute attribute 
                        && !attribute.Validate(propertyInfo.GetValue(oObj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
    public class LengthAttribute : Attribute
    {
        private readonly long _min = 0;
        private readonly long _max = 0;

        public LengthAttribute(long min, long max)
        {
            _min = min;
            _max = max;
        }

        public bool Validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()) && long.TryParse(value.ToString(), out long lResult))
            {
                var length = value.ToString().Length;
                if (length > this._min && length < this._max)
                {
                    return true;
                }


            }

            return false;

        }
    }
    public class LongAttribute : Attribute
    {
        private readonly long _min = 0;
        private readonly long _max = 0;

        public LongAttribute(long min, long max)
        {
            _min = min;
            _max = max;
        }

        public bool Validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()) && long.TryParse(value.ToString(), out long lResult))
            {
                if (lResult > this._min && lResult < this._max)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
