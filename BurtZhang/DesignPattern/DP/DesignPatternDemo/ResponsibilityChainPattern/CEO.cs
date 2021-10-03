using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    public class CEO: AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine("CEO approval");
            if (context.Hour <= 80)
            {
                context.AuditResult = true;
                context.AuditRemark = "Enjoy";
            }
            else
            {
                context.AuditResult = false;
                context.AuditRemark = "No way";
            }
        }
    }
}
