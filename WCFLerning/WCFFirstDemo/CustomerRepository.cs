using System.Configuration;
/**
* @Project Name: $projectname$ ： OrdersRepository
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: WCFFirstDemo
* @Creation Time:  5/21/2018 10:09:29 AM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          5/21/2018 10:09:29 AM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System.Data;
using System.Data.SqlClient;

namespace WCFFirstDemo
{
    class CustomerRepository : ICustomerRepository
    {
        private string _connstr;
        public CustomerRepository()
        {
            _connstr = ConfigurationManager.AppSettings["TropicalConnStr"];
        }
        public DataSet GetCustNameAutoComplete()
        {

            DataSet _ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(_connstr))
            {
                conn.Open();
                string query = "select tu.FirstName +','+ tu.LastName as UserName from tblTropicalUser tu join tblTropicalUserRole tur on tu.RoleID = tur.RoleID where tur.RoleDescription = 'Sales Representative'";

                SqlDataAdapter _sda = new SqlDataAdapter(query, conn);
                _sda.Fill(_ds);
                conn.Close();
            }

            return _ds;
        }
    }
}
