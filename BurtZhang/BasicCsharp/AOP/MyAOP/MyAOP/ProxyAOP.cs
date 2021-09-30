using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    public class ProxyAOP
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

            processor = new UserProcessProxy();
            processor.RegUser(user);
        }
    }

    public class UserProcessProxy : IUserProcessor
    {
        private IUserProcessor _userProcessor = new UserProcessor();
        public void RegUser(User user)
        {
            BeforeProceed(user);
            _userProcessor.RegUser(user);
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
