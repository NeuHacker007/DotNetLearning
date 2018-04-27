using System;
using TropicalServer.Helper;

namespace TropicalServer.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cookie = Request.Cookies["LoginID"];
                if (cookie != null)
                {
                    txtBoxUsername.Text = cookie.Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginID = txtBoxUsername.Text;
            string password = txtBoxPassword.Text;
            bool isChecked = chkRemeberMe.Checked;
            //TODO: check whether user is exists
            bool isLoginedIn = SQLHelper.IsUserLogin(loginID, password);
            if (isLoginedIn)
            {
                //TODO: load cookies
                if (isChecked)
                {
                    UtilityTools.CreateCookies("LoginIDCookie", "LoginID", loginID, 24);
                }
                Response.Redirect("~/UI/Products.aspx");

            }
            else
            {
                Response.Write("Login Failed");
            }
        }

        protected void lbtnForgetUserName_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountRecovery.aspx");
        }

        protected void lbtnForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountRecovery.aspx");
        }
    }
}