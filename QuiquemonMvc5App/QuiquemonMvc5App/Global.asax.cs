using System.Web.Optimization;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuiquemonMvc5App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
