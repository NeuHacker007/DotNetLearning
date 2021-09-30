using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace RealProxyAOP
{
    public class RealProxyAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Ivan",
                Password = "1234123"
            };


            IUserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            UserProcessor userProcessor = TransparentProxy.Create<UserProcessor>();
            userProcessor.RegUser(user);
        }
    }

    /// <summary>
    /// 真实代理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyRealProxy<T> : RealProxy
    {
        private T tTarget;

        public MyRealProxy(T target): base(typeof(T))
        {
            this.tTarget = target;
        }


        public override IMessage Invoke(IMessage msg)
        {
            BeforeProceed(msg);
            object retval = null;
            IMethodCallMessage callMessage = null;
            {
                // 相当于调用真实方法体

                callMessage = (IMethodCallMessage) msg;

                retval= callMessage.MethodBase.Invoke(this.tTarget, callMessage.Args);
            }
            

            AfterProceed(msg);

            return new ReturnMessage(retval, new object[0], 0, null, callMessage);
        }

        public void BeforeProceed(IMessage msg)
        {
            Console.WriteLine($"Before proceed");
        }

        public void AfterProceed(IMessage msg)
        {
            Console.WriteLine($"After proceed");
        }
    }
    /// <summary>
    /// 透明代理
    /// </summary>
    public static class TransparentProxy
    {
        public static T Create<T>()
        {
            T instance = Activator.CreateInstance<T>();

            MyRealProxy<T> realProxy = new MyRealProxy<T>(instance);

            T transparentProxy = (T) realProxy.GetTransparentProxy();

            return transparentProxy;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public interface IUserProcessor
    {
        void RegUser(User user);
    }

    public class UserProcessor : IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine($"User has already registered Name: {user.Name}; Password: {user.Password}");
        }
    }
    public class UserProcessRealProxy : MarshalByRefObject, IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine($"User has already registered Name: {user.Name}; Password: {user.Password}");
        }
    }
}
