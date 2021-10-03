using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    public class PM : AbstractAuditor
    {
       
        public override void Audit(ApplyContext context)
        {

            Console.WriteLine("PM approval");
            if (context.Hour <= 8)
            {
                context.AuditResult = true;
                context.AuditRemark = "Enjoy";
            } else
            {
                base._auditor?.Audit(context);
            }

            //else
            //{ 
            //    // 代码的坏味道， 这种方式虽然使用者只对PM发起请假请求，但是PM 除了
            //    // 自己本职工作外，还负责了找到下一个人。 并且如果PM离职或者产生变化。
            //    // 流程变化，代码不够灵活
            //    AbstractAuditor charger = new Charge()
            //    {
            //        Name = "Eva"
            //    };

            //    charger.Audit(context);
            //}
        }
    }

}
