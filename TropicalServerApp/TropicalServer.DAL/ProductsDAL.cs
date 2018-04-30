/**
* @Project Name: $projectname$ ： ProductsDAL
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TropicalServer.DAL
* @Creation Time:  4/26/2018 12:02:17 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          4/26/2018 12:02:17 PM                    Ivan                  Initial
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
    public class ProductsDAL
    {
        private string _connectionString;
        private SqlConnection _conn;
        private SqlCommand _command;
        private SqlDataAdapter _sda;
        private DataSet _ds;
        private DataTable _dt;
        private SqlDataReader _sdReader;

        public ProductsDAL()
        {
            _connectionString = ConfigurationManager.AppSettings["TropicalServerConnectionString"];
        }

        public DataSet GetProductByProductCategory(string categorydesc)
        {
            _ds = new DataSet();
            try
            {
                using (_conn = new SqlConnection(_connectionString))
                {
                    _conn.Open();
                    _command = new SqlCommand("GetProductByProductCategory", _conn);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Parameters.Add("@itemDescription", SqlDbType.NVarChar).Value = categorydesc;

                    using (_sda = new SqlDataAdapter(_command))
                    {
                        _sda.Fill(_ds);
                    }

                    _conn.Close();

                }
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return _ds;
        }

        public DataSet GetAllProducts()
        {
            _ds = new DataSet();
            try
            {
                using (_conn = new SqlConnection(_connectionString))
                {
                    _conn.Open();
                    string query =
                        "select I.ItemNumber as [ITEM #], I.ItemDescription as [ITEM DESCRIPTION], isnull(I.PrePrice, 0) as [PRE - PRICE],isnull(CONVERT(VARCHAR(50), ItemUnits) + 'x' + CONVERT(VARCHAR(50), ItemWeights) + ' lb', '') as SIZE from tblItemType as IT join tblItem as I ON (IT.ItemTypeID = I.ItemType)";

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
                //TODO: Add Log
            }

            return _ds;
        }
    }
}
