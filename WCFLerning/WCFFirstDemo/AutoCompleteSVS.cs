using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WCFFirstDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class AutoCompleteSVS : IAutoComplete
    {
        public CustNames GetCustAutoComplete(string pre)
        {
            CustNames names = new CustNames();
            List<string> custNamelist = new List<string>();
            CustomerRepository customer = new CustomerRepository();
            DataSet ds = customer.GetCustNameAutoComplete();
            custNamelist = ds.Tables[0].AsEnumerable()
                .Where(datarow => datarow["CustName"].ToString().StartsWith(pre))
                .Select(a => a.Field<string>("CustName")).ToList();
            names.CustomerNames = custNamelist;
            return names;
        }
    }
}
