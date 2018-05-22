using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WCFSecondDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AutoComplete" in both code and config file together.
    public class AutoComplete : IAutoComplete
    {
        public List<string> GetCustAutoComplete(string pre)
        {
            string connstr = ConfigurationManager.AppSettings["TropicalConnStr"];
            DataSet _ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string query = "select tu.FirstName +','+ tu.LastName as UserName from tblTropicalUser tu join tblTropicalUserRole tur on tu.RoleID = tur.RoleID where tur.RoleDescription = 'Sales Representative'";

                SqlDataAdapter _sda = new SqlDataAdapter(query, conn);
                _sda.Fill(_ds);
                conn.Close();
            }

            return _ds.Tables[0].AsEnumerable()
                   .Where(datarow => datarow["CustName"].ToString()
                   .StartsWith(pre))
                   .Select(a => a.Field<string>("CustName")).ToList();
        }
    }
}
