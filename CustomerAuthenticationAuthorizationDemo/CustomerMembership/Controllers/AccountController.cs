using System.Web.Mvc;

namespace CustomerMembership.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logon()
        {
            return View("Login");
        }

    }
}