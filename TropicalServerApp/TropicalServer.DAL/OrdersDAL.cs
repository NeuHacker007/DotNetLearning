/**
* @Project Name: $projectname$ ： Orders
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TropicalServer.DAL
* @Creation Time:  4/26/2018 12:02:40 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          4/26/2018 12:02:40 PM                    Ivan                  Initial
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
    public class OrdersDAL
    {
        private SqlConnection _conn;
        private SqlCommand _command;
        private string _connectString;
        private DataTable _dt;
        private DataSet _ds;
        private SqlDataAdapter _sda;
        private SqlDataReader _reader;

        public OrdersDAL()
        {
            _connectString = ConfigurationManager.AppSettings["TropicalServerConnectionString"];
        }

        public DataSet GetAllOrders()
        {
            _ds = new DataSet();
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();

                    string query = "SELECT c.custID, O.OrderTrackingNumber, O.OrderDate, C.CustNumber, C.CustName, C.CustOfficeAddress1,O.OrderRouteNumber FROM tblCustomer C JOIN tblOrder O ON C.CustNumber = O.OrderCustomerNumber WHERE O.OrderTrackingNumber IS NOT NULL";
                    _sda = new SqlDataAdapter(query, _conn);
                    _sda.Fill(_ds);
                    _conn.Close();
                }
            }
            catch (Exception)
            {

                //TODO: Log Exception
            }


            return _ds;
        }

        public DataSet GetOrdersByDateType(string dateType)
        {
            _ds = new DataSet();
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    _command = new SqlCommand("spGetOrdersByTimePeriod", _conn);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Parameters.Add("@OrderDate", SqlDbType.NVarChar).Value = dateType;
                    _sda = new SqlDataAdapter(_command);
                    _sda.Fill(_ds);
                    _conn.Close();
                }
            }
            catch (Exception e)
            {
                //Add To Log

            }
            return _ds;
        }

        public void UpdateCustomerAddress(string addr, int custId)
        {
            using (_conn = new SqlConnection(_connectString))
            {
                _conn.Open();
                _command = new SqlCommand("spUpdateCutomerAddress", _conn);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = addr;
                _command.Parameters.Add("@custNumber", SqlDbType.Int).Value = custId;
                _command.ExecuteNonQuery();
                _conn.Close();

            }
        }
    }
}
