using OrderTracking.Helper;
using System;

namespace OrderTracking.Forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginID = txtBoxLoginID.Text;
            string password = txtBoxPasswd.Text;

            //TODO: check whether user is exists
            bool isLoginedIn = SQLHelper.IsUserLogin(loginID, password);
            if (isLoginedIn)
            {
                Response.Redirect("~/Pages/OrderTrackingDetail.aspx");
                //TODO: load cache
                //1. check whether cache exists or expired
                //2. if exists use this cache
                //3. if expired or not exists create cache
            }
            else
            {
                Response.Write("Login Failed");
            }

        }
    }
}