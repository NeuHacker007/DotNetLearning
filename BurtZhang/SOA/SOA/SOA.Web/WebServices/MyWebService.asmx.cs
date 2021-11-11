using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using SOA.Web.WebServices;

namespace SOA.Web.Remoting
{
    /// <summary>
    /// Summary description for MyWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {
        public CustomerHeader soapHeader;
        [WebMethod] //必须标记
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Plus(int x, int y)
        {
            return x + y;
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("soapHeader")]
        public List<User> Get()
        {
            if (soapHeader == null || !soapHeader.IsValid()) throw new SoapException("soap error", SoapHeaderException.ServerFaultCode);
            return new List<User>()
            {
                new User() {Id =1, Name="Ivan"},
                new User() {Id =2, Name="Ivan2"},
                new User() {Id =3, Name="Ivan3"},
                new User() {Id =4, Name="Ivan4"},
            };
        }
    }
}
