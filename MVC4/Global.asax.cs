using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor.Installer;
using Infrastructure;
using Infrastructure.Windsor;
using Raven.Client;
using MVC4.Infrastructure.AutoMapper;

namespace MVC4
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            EndRequest += SaveSessionChanges;
        }

        private void SaveSessionChanges(object sender, EventArgs e)
        {
            using (var session = IoC.Instance.Resolve<IDocumentSession>())
            {
                if (session == null)
                    return;
                if (Server.GetLastError() != null)
                    return;

                session.SaveChanges();
            }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            BootstrapContainer();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            AutoMapperConfiguration.Configure();

        }

        private static void BootstrapContainer()
        {
            IoC.Instance.Install(FromAssembly.This());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Instance.Kernel));
        }

        protected void Application_End()
        {
            IoC.Instance.Dispose();
        }
    }
}