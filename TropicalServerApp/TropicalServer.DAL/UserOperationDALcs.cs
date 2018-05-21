/**
* @Project Name: $projectname$ ： UserOperationDALcs
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TropicalServer.DAL
* @Creation Time:  4/26/2018 9:11:08 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          4/26/2018 9:11:08 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TropicalServer.DAL
{
    public class UserOperationDALcs
    {
        private SqlConnection _conn;
        private SqlCommand _command;
        private string _connectString;
        private DataTable _dt;
        private DataSet _ds;
        private SqlDataAdapter _sda;
        private SqlDataReader _reader;

        public UserOperationDALcs()
        {
            _connectString = ConfigurationManager.AppSettings["TropicalServerConnectionString"];
        }

        public DataSet GetUniqueSalesMgr()
        {
            _ds = new DataSet();
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    string query = "select tu.FirstName +','+ tu.LastName as UserName from tblTropicalUser tu join tblTropicalUserRole tur on tu.RoleID = tur.RoleID where tur.RoleDescription = 'Sales Representative'";

                    _sda = new SqlDataAdapter(query, _conn);
                    _sda.Fill(_ds);
                    _conn.Close();
                }

            }
            catch (Exception)
            {

                //TODO: AddLOg
            }
            return _ds;
        }

        public DataSet GetUniqueCustomerName()
        {
            _ds = new DataSet();

            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    string query = "select distinct CustName  from tblCustomer";
                    _command = new SqlCommand(query, _conn);

                    using (_sda = new SqlDataAdapter(_command))
                    {
                        _sda.Fill(_ds);
                    }
                    _conn.Close();

                }
            }
            catch (Exception e)
            {
                //TODO:Add Log
            }

            return _ds;
        }

        public DataSet GetUniqueCustomerNames()
        {
            _ds = new DataSet();

            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    string query = "select distinct CustName  from tblCustomer";
                    _command = new SqlCommand(query, _conn);

                    using (_sda = new SqlDataAdapter(_command))
                    {
                        _sda.Fill(_ds);
                    }
                    _conn.Close();

                }
            }
            catch (Exception e)
            {
                //TODO:Add Log
            }

            return _ds;
        }
    }
}
