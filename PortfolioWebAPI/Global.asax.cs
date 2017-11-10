using System.Web.Http;
using System.Web.Routing;

namespace PortfolioWebAPI
{
    /// <summary>
    /// Start application
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// App start
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            App_Start.RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
