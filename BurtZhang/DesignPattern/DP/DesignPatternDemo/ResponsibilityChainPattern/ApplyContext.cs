using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    public class ApplyContext
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int Hour { get; set; }

        public string Description { get; set; }

        public bool AuditResult { get; set; }

        public string AuditRemark { get; set; }
    }
}
