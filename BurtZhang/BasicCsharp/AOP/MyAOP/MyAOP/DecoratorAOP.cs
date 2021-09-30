using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 装饰器模式实现静态代理
    /// AOP在方法前后增加自定义的方法
    /// </summary>
    class DecoratorAOP
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

            processor = new UserProcessorDecorator(processor);
            processor.RegUser(user);
        }
    }


    public class UserProcessorDecorator : IUserProcessor
    {
        private IUserProcessor _UserProcessor { get; set; }

        public UserProcessorDecorator(IUserProcessor userProcessor)
        {
            _UserProcessor = userProcessor;
        }
        public void RegUser(User user)
        {
            BeforeProceed(user);
            _UserProcessor.RegUser(user);

            AfterProceed(user);
        }

        private void AfterProceed(User user)
        {
            Console.WriteLine($"Before RegUser");
        }

        private void BeforeProceed(User user)
        {
            Console.WriteLine($"After RegUser");
        }
    }
}
