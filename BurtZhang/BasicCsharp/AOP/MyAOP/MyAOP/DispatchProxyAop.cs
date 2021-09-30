using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyAOP
{
    //TODO: implement after
    public class DispatchProxyAop
    {
    }

    public class MyRealProxy<T> : DispatchProxy
    {

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 必须继承自MarshalByRefObject父类， 否则无法生成
    /// </summary>
    public class UserProcessRealProxy : MarshalByRefObject, IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine($"User has already registered Name: {user.Name}; Password: {user.Password}");
        }
    }
}
