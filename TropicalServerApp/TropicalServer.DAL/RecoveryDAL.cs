/**
* @Project Name: $projectname$ ： RecoveryDAL
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TropicalServer.DAL
* @Creation Time:  4/30/2018 10:59:07 AM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          4/30/2018 10:59:07 AM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TropicalServer.DAL
{
    public class RecoveryDAL
    {
        private SqlConnection _conn;
        private SqlCommand _command;
        private string _connectString;
        private DataTable _dt;
        private DataSet _ds;
        private SqlDataAdapter _sda;
        private SqlDataReader _reader;
        private SqlParameter[] _parameters;

        public RecoveryDAL()
        {
            _connectString = ConfigurationManager.AppSettings["TropicalServerConnectionString"];
        }

        public string CheckEmail(string email, string guid)
        {
            _parameters = new SqlParameter[3];
            _parameters[0] = new SqlParameter("@email", SqlDbType.NVarChar) { Direction = ParameterDirection.Input };
            _parameters[1] = new SqlParameter("@Guid", SqlDbType.NVarChar) { Direction = ParameterDirection.Input };
            _parameters[2] = new SqlParameter("@uId", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.InputOutput };
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    _command = new SqlCommand("spCheckEmailExisting", _conn);
                    _command.CommandType = CommandType.StoredProcedure;
                    if (_parameters != null)
                    {
                        foreach (var sqlParameter in _parameters)
                        {
                            _command.Parameters.Add(sqlParameter);
                        }
                    }

                    _command.ExecuteNonQuery();
                    _conn.Close();


                }
            }
            catch (System.Exception)
            {

            }
            return _parameters[2].Value.ToString();
        }
    }
}
