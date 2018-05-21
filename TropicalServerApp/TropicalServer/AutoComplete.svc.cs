using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using TropicalServer.DAL;

namespace TropicalServer
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AutoComplete
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public List<string> GetCustomerNamesAutoComplete(string pre)
        {
            List<string> names = new List<string>();
            UserOperationDALcs userOperation = new UserOperationDALcs();
            DataSet ds = userOperation.GetUniqueCustomerName();
            names = ds.Tables[0].AsEnumerable()
                .Where(datarow => datarow["CustName"].ToString().StartsWith(pre))
                .Select(a => a.Field<string>("CustName")).ToList();
            return names;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
