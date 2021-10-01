using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    class BankClientCurrent:AbstractBankClient
    {
        protected override double CalculateInterest(double balance)
        {
            return balance * 0.001;
        }
    }
}
