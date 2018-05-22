using System.Collections.Generic;
using System.ServiceModel;

namespace WCFSecondDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAutoComplete" in both code and config file together.
    [ServiceContract]
    public interface IAutoComplete
    {
        [OperationContract]
        List<string> GetCustAutoComplete(string pre);
    }
}
