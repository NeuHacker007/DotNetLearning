using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace MyAOP
{
    /// <summary>
    /// 使用castle\DynamicProxy 实现动态代理
    ///
    /// 方法必须式虚方法
    /// </summary>
    class CastleProxyAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Ivan",
                Password = "1234123"
            };

            ProxyGenerator generator = new ProxyGenerator();
            MyInterceptor myInterceptor = new MyInterceptor();

            CastleUserProcessor castleUserProcessor = generator.CreateClassProxy<CastleUserProcessor>(myInterceptor);
            castleUserProcessor.RegUser(user);

        }
        public class MyInterceptor: IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                PreProceed(invocation);
                invocation.Proceed();
                PostProceed(invocation);
            }

            public void PreProceed(IInvocation invocation)
            {
                Console.WriteLine("before exe");
            }

            public void PostProceed(IInvocation invocation)
            {
                Console.WriteLine("after exe");
            }
        }

        public class CastleUserProcessor: IUserProcessor
        {
            /// <summary>
            /// 必须带上virtual否则没用
            /// </summary>
            /// <param name="user"></param>
            public virtual void RegUser(User user)
            {
                Console.WriteLine($"User has already registered Name: {user.Name}; Password: {user.Password}");
            }
        }
    }
}
