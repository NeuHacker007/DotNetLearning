using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace SOA.Web.Remoting
{
    public class CustomerHeader : SoapHeader
    {
        private string userName = string.Empty;
        private string password = string.Empty;

        /// <summary>
        /// 必须有一个无参数的构造函数
        /// </summary>
        public CustomerHeader()
        {

        }

        public CustomerHeader(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
        }


        public string Password
        {
            get {return this.password;}
            set { this.password = value; }
        }

        public bool IsValid()
        {
            return this.userName.Contains("s") && this.password.Contains("1");
        }



    }
}