using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOA.Web.Remoting;

namespace SOA.Web.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyWCF" in both code and config file together.
    [ServiceContract] //必须标记
    public interface IMyWCF
    {
        [OperationContract] //必须标记
        void DoWork();
        [OperationContract]
        string GetString();

        [OperationContract]
        List<User> GetUsers(int index);
        
        void HelloWorld();
    }
}
