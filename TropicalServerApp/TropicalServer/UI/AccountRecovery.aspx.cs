using System;
using TropicalServer.DAL;
using TropicalServer.Helper;

namespace TropicalServer.UI
{
    public partial class AccountRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string emailTo = txtBoxRecoverEmail.Text;
            string guid = getGuid();
            RecoveryDAL recovery = new RecoveryDAL();
            string uid = recovery.CheckEmail(emailTo, guid);
            if (string.IsNullOrEmpty(uid))
            {
                string emailbody = "Reset your password by using the link: " + "http://localhost:55254/UI/PasswordReset.aspx?userid=" + uid + "&guid=" + guid;
                EmailHelper.SendEmail(emailTo, emailbody);
            }
        }

        private string getGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}