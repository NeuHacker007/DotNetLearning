using System.Web.Mvc;

namespace HappyItlizer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("MyHomePage");
        }
    }
}