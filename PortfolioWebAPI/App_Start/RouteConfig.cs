using System.Web.Mvc;
using System.Web.Routing;

namespace PortfolioWebAPI.App_Start
{
    /// <summary>
    /// Adds default home page from Swagger
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// default Swagger home page route
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}