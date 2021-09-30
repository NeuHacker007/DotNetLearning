using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityAOP
{
    public class ParameterCheckBehavior: IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Parameter check");

            User user = input.Inputs[0] as User; //可以不写死类型， 用反射 + 特性完成数据有效性检测

            if (user?.Password.Length < 10)
            {
                //返回异常
                return input.CreateExceptionMethodReturn(new Exception("Password length must > 10"));
                //throw new Exception("xxx");
            }

            return getNext()(input, getNext);
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
