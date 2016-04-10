using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IEP.App_Start;
using IEP.Services.Contracts;

namespace IEP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            TinyMapperConfig.RegisterMappings();
        }

        protected void Application_PostAuthenticateRequest()
        {
            var service = DependencyResolver.Current.GetService<IAuthService>();

            service.AcceptCookies(Request);
        }
    }
}
