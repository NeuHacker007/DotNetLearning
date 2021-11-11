using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SOA.WCF.Model;

namespace SOA.WCF.Interface
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        int PlusInt(int x, int y);
        int Minus(int x, int y);

        WCFUser GetUser(int x, int y);

        List<WCFUser> UserList();

    }
}
