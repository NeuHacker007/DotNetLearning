using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    public class SerializeMapper
    {
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            return JsonSerializer.Deserialize<TOut>(JsonSerializer.Serialize(tIn));
        }
    }
    
}
