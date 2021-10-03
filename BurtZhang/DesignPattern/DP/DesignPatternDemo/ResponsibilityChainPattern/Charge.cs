using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    public class Charge:AbstractAuditor
    {
      
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine("Charger approval");
            if (context.Hour <= 16)
            {
                context.AuditResult = true;
                context.AuditRemark = "Enjoy";
            }
            else
            {
                _auditor.Audit(context);
            }
        }
    }
}
