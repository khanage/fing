using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Web.Common;
using Ninject;
using FingWeb.Core;
using System.Web.Routing;
using System.Web.Mvc;

namespace FSharpWeb.Web
{
   public class Global : NinjectHttpApplication
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
      }

      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
             "Default", // Route name
             "{controller}/{action}/{id}", // URL with parameters
             new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
         );

      }

      protected override void OnApplicationStarted()
      {
         AreaRegistration.RegisterAllAreas();

         RegisterGlobalFilters(GlobalFilters.Filters);
         RegisterRoutes(RouteTable.Routes);

         base.OnApplicationStarted();
      }

      protected override IKernel CreateKernel()
      {
         //var standardKernel = new StandardKernel(new ContainerModule());
         var standardKernel = new StandardKernel();
         return standardKernel;
      }
   }
}