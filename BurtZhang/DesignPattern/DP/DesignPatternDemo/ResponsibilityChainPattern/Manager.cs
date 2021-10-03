using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    public class Manager: AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine("Manager approval");
            if (context.Hour <= 24)
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
