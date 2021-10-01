using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public abstract class AbstractBankClient
    {
        public void Query(int id, string name, string password)
        {
            if (CheckUser(id, password))
            {
                double balance = QueryBalance(id);
                double interest = CalculateInterest(balance);

                Show(name, balance, interest);

            }
            else
            {
                Console.WriteLine("id/password wrong");
            }
        }


        /// <summary>
        /// 活期 定期 利率不同
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        protected abstract double CalculateInterest(double balance);
       
        // 如果还有更多方法都是这样的分支， 比较稳定的分支比如各个方法当中都出现了定期活期的判断
        // 那么我们不应该把不同的行为强行赛在一起 单一职责
        private void Show(string name, double balance, double interest)
        {
           
            Console.WriteLine($"{name}'s balance is {balance} and interest is {interest}");
        }
        private double QueryBalance(int id)
        {
            return new Random().Next(10000, 1000000);
        }

        private bool CheckUser(int id, string password)
        {
            return true;
        }
    }
}
