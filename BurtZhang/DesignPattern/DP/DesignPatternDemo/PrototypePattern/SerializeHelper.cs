using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class SerializeHelper
    {
        public static string Serializable(object target)
        {
           return  JsonSerializer.Serialize(target);
        }

        public static T DeepClone<T>(T t)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(t));
        }
    }
}
