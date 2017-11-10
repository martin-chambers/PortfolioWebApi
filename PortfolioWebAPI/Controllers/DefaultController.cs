using System.Web.Mvc;
using System.Configuration;
namespace PortfolioWebAPI.Controllers
{
    /// <summary>
    /// Default Swagger home page controller
    /// </summary>
    public class DefaultController : Controller
    {
        // GET: Default
        /// <summary>
        /// Note: This is an MVC controller - not Web API
        /// default controller displays in the web root and shows swagger-based documentation and assistance
        /// </summary>
        public ActionResult Index()
        {
            return new RedirectResult("~/swagger/ui/index");
        }
    }
}
