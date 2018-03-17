using System.Web.Mvc;
using System.Web.Routing;

namespace Eva
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "MovieReleasedByDate",
            //    url: "movies/released/{year}/{month}",
            //    defaults: new { Controller = "Movies", Action = "ByReleasedDate" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
