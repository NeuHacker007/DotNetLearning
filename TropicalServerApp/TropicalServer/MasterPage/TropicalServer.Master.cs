namespace TropicalServer.MasterPage
{
    public partial class TropicalServer : System.Web.UI.MasterPage
    {
        protected void linkBtnLogOut_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/UI/Login.aspx");
        }
    }
}