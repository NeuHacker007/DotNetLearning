using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFFirstDemo
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.


    [ServiceContract]
    public interface IAutoComplete
    {
        [OperationContract]
        //[WebGet(UriTemplate = "GetCustAutoComplete/{pre}", ResponseFormat = WebMessageFormat.Json)]
        CustNames GetCustAutoComplete(string pre);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFFirstDemo.ContractType".
    [DataContract]
    public class CustNames
    {
        [DataMember]
        public List<string> CustomerNames { get; set; }
    }
}
