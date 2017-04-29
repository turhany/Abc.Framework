using System.Web.Mvc;
using System.Web.Routing;
using Abc.Core.Utilities.Mvc.Infrastructure;
using Abc.Northwind.Business.DependencyResolvers.Ninject;

namespace Abc.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //TODO: MVC > Bussines katmanı üzerinden çalışmasını sağlayan kod
            // ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));

            //TODO: MVC > WCF Servisi üzerinden çalışmasını sağlayan kod
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new ServiceModule()));
        }
    }
}
