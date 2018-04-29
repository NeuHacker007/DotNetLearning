using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TropicalServer.Helper
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
            _connectString = ConfigurationManager.AppSettings["TropicalServerConnectionString"].ToString();
            _command = new SqlCommand();
        }
        public static DataTable GetAllUsersInfo()
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

        public static DataTable GetUserInfoByUserName(string username)
        {
            using (_conn = new SqlConnection(_connectString))
            {
                string query = "select * from tblUserLogin where UserName = @UserName";
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

        //TODO: Whether user alreary exists incomplete
        public static bool IsUserAlreadyExists(string name)
        {
            return false;
        }

        public static bool IsUserLogin(string loginID, string password)
        {
            bool result = false;
            try
            {
                using (_conn = new SqlConnection(_connectString))
                {
                    _conn.Open();
                    string query = "select password from tblUserLogin where @UserName";
                    _command = new SqlCommand(query, _conn);
                    _command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                    _command.Parameters["@UserName"].Value = loginID;


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