using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityAOP
{
    public class CachingBehavior : IInterceptionBehavior
    {
        private static Dictionary<string, object> cacheDictionary = new Dictionary<string, object>();
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            string key = $"{input.MethodBase.Name}_{JsonConvert.SerializeObject(input.Inputs)}";

            if (cacheDictionary.ContainsKey(key))
            {
                return input.CreateMethodReturn(cacheDictionary[key]);
            }

            IMethodReturn result = getNext()(input, getNext);
            if (result.ReturnValue != null)
            {
                cacheDictionary.Add(key,result.ReturnValue);
            }

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute => true;
    }
}
