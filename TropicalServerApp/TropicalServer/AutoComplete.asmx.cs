using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using TropicalServer.DAL;

namespace TropicalServer.WebServices
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<string> GetCustomerNames(string pre)
        {
            List<string> names = new List<string>();
            UserOperationDALcs userOperation = new UserOperationDALcs();
            DataSet ds = userOperation.GetUniqueCustomerName();
            names = ds.Tables[0].AsEnumerable()
                .Where(datarow => datarow["CustName"].ToString().StartsWith(pre))
                .Select(a => a.Field<string>("CustName")).ToList();
            return names;
        }
    }
}
