﻿using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OrderTracking.Helper
{
    public class SQLHelper
    {
        private static SqlConnection _conn;
        private static SqlCommand _command;
        private static string _connectString;
        private static DataTable _dt;
        private static DataSet _ds;
        private static SqlDataAdapter _sda;
        private static SqlDataReader _reader;

        public SQLHelper()
        {
            _connectString = ConfigurationManager.ConnectionStrings["TropicalDBServerConn"].ConnectionString.ToString();
            _command = new SqlCommand();
        }
        public static DataTable GetAllUsersInfo()
        {
            using (_conn = new SqlConnection(_connectString))
            {
                string query = "select * from UsersLogin";
                _command = new SqlCommand(query, _conn);
                using (_sda = new SqlDataAdapter(_command))
                {
                    _sda.Fill(_dt);
                    return _dt;
                }

            }
        }

        public static DataTable GetUserInfoByUserName(string username)
        {
            using (_conn = new SqlConnection(_connectString))
            {
                string query = "select * from UsersLogin where UserName = @UserName";
                using (_command = new SqlCommand(query, _conn))
                {
                    _command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                    _command.Parameters["@UserName"].Value = username;
                    using (_sda = new SqlDataAdapter(_command))
                    {
                        _sda.Fill(_dt);
                        return _dt;
                    }
                }
            }
        }

        //TODO: Whether user alreary exists
        public static bool IsUserAlreadyExists(string name)
        {
            return false;
        }
        //TODO: Compare Password (loginID, userInput password) return bool
        public static bool IsUserLogin(string loginID, string password)
        {
            bool result = false;
            using (_conn = new SqlConnection(_connectString))
            {
                string query = "select password from UsersLogin where @UserName";
                using (_command = new SqlCommand(query, _conn))
                {
                    _command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                    _command.Parameters["@UserName"].Value = loginID;

                    _conn.Open();
                    using (_reader = _command.ExecuteReader())
                    {

                        if (_reader.Read())
                        {
                            string PasswordFromServer = _reader["password"].ToString();
                            if (PasswordFromServer.Equals(password))
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                    _conn.Close();
                }

            }

            return result;
        }



    }
}