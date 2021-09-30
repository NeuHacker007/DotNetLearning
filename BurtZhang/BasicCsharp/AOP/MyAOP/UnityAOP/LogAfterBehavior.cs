using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityAOP
{
    public class LogAfterBehavior : IInterceptionBehavior 
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext); //执行后面的全部动作
            Console.WriteLine("Log after Behavior");

            foreach (var item in input.Inputs)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine($"Log After Behavior {methodReturn.ReturnValue}");
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
