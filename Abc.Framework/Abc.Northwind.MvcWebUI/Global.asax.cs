using System;
using System.Security.Principal;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Abc.Core.CrossCuttingConcerns.Security.Web;
using Abc.Core.Utilities.Mvc.Infrastructure;
using Abc.Northwind.Business.DependencyResolvers.Ninject;
using System.Web;

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

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null) return;

                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket)) return;

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormsAuthTicketToIdentity(ticket);
                var prin = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = prin;
                Thread.CurrentPrincipal = prin;
            }
            catch (Exception)
            {
            }
        }
    }
}
