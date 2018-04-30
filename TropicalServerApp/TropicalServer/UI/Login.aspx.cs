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

        }

        protected void lbtnForgetUserName_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountRecovery.aspx");
        }

        protected void lbtnForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountRecovery.aspx");
        }

        protected void btnLoginButton_Click(object sender, EventArgs e)
        {
            string loginId = txtBoxUsername.Text;
            string password = txtBoxPassword.Text;
            bool isChecked = chkRemeberMe.Checked;
            SQLHelper helper = new SQLHelper();
            bool isLoginedIn = helper.IsUserLogin(loginId, password);
            if (isLoginedIn)
            {
                Session["LoginID"] = loginId;

                if (isChecked)
                {
                    UtilityTools.CreateCookies("LoginIDCookie", "LoginID", loginId, 24);
                }
                Response.Redirect("~/UI/Orders.aspx");

            }
            else
            {
                Response.Write("Login Failed");
            }
        }
    }
}