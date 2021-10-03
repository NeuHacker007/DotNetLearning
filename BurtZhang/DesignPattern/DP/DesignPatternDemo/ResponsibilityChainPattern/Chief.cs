using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    public class Chief: AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine("Chief approval");
            if (context.Hour <= 40)
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
