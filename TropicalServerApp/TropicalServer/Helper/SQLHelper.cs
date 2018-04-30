using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TropicalServer.Helper
{
    public class SQLHelper
    {
        private SqlConnection _conn;
        private SqlCommand _command;
        private string _connectString;
        private DataTable _dt;
        private DataSet _ds;
        private SqlDataAdapter _sda;
        private SqlDataReader _reader;

        public SQLHelper()
        {
            _connectString = ConfigurationManager.AppSettings["TropicalServerConnectionString"].ToString();
            _command = new SqlCommand();
        }

        public DataTable GetAllUsersInfo()
        {
            _dt = new DataTable();
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    string query = "select * from tblUserLogin";
                    _command = new SqlCommand(query, _conn);
                    using (_sda = new SqlDataAdapter(_command))
                    {
                        _sda.Fill(_dt);
                    }

                    _conn.Close();
                }
            }
            catch (Exception e)
            {
                //TODO: Log
            }

            return _dt;
        }

        public DataTable GetUserInfoByUserName(string username)
        {
            _dt = new DataTable();
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    string query = "select * from tblUserLogin where UserName = @UserName";
                    _command = new SqlCommand(query, _conn);
                    _command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                    _command.Parameters["@UserName"].Value = username;
                    using (_sda = new SqlDataAdapter(_command))
                    {
                        _sda.Fill(_dt);
                    }

                    _conn.Close();
                }
            }
            catch (Exception e)
            {
                //TODO: ADD LOG
            }

            return _dt;
        }

        //TODO: Whether user alreary exists incomplete
        public bool IsUserAlreadyExists(string name)
        {
            return false;
        }

        public bool IsUserLogin(string loginID, string password)
        {
            bool result = false;
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    string query = "select password from tblTropicalUser where LoginID ='" + loginID + "'";
                    _command = new SqlCommand(query, _conn);

                    using (_reader = _command.ExecuteReader())
                    {
                        if (_reader.Read())
                        {
                            string passwordFromServer = _reader["password"].ToString();
                            if (passwordFromServer.Equals(password))
                            {
                                result = true;
                            }
                        }
                    }

                    _conn.Close();
                }
            }
            catch (Exception e)
            {
                //TODO: Add Log
            }

            return result;
        }
    }
}