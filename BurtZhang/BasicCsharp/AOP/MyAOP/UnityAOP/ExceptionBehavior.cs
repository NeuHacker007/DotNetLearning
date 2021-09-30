using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityAOP
{
    public class ExceptionBehavior: IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);

            Console.WriteLine("catch exception");
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("good");
            }
            else
            {
                Console.WriteLine($"Exception: {methodReturn.Exception.Message}");
            }

            return methodReturn;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
