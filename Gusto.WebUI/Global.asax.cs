using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gusto.Business.DependencyResolvers.Ninject;
using Gusto.Business.Helper.Ninject;


namespace Gusto.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new AutoMapperModule()));
        }
    }
}
