using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
    public class Camera : IExtendPhotography
    {
        public void Photo()
        {
            throw new NotImplementedException();
        }

       
        public void Record()
        {
            throw new NotImplementedException();
        }
    }
}
