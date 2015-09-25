using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;
            //Bypass the routing system
            routes.MapRoute("DiskFile", "Content/StaticContent.html",
            new
            {
                 controller = "Customer",
                 action = "List",
            });

           // Applying a Custom Constraint in a Route
            routes.MapRoute("ChromeRoute", "{*catchall}",
            new { controller = "Home", action = "Index" },
            new
            {
              customConstraint = new UserAgentConstraint("Chrome")
            },
            new[] { "UrlsAndRoutes.AdditionalControllers" });

            //construct a route using a regular expression and http method
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new { controller = "^H.*", action = "Index|About",
            httpMethod = new HttpMethodConstraint("GET") },
            new[] { "URLsAndRoutes.Controllers" });

            //disabling fallback namespaces
            Route myRoute = routes.MapRoute("AddContollerRoute",
            "Home/{action}/{id}/{*catchall}",
            new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            },
            new[] { "UrlsAndRoutes.AdditionalControllers" });
            myRoute.DataTokens["UseNamespaceFallback"] = false;


            //Multiple routes
            routes.MapRoute("MyRoute1", "{controller}/{action}/{id}/{*catchall}",
            new
            {
                 controller = "Home",
                 action = "Index",
                 id = UrlParameter.Optional
            },
            new[] { "UrlsAndRoutes.AdditionalControllers" }
            );
            //Multiple routes
           routes.MapRoute("MyRoute2", "{controller}/{action}/{id}/{*catchall}",
          new
          {
              controller = "Home",
              action = "Index",
              id = UrlParameter.Optional
          },
          new[] { "UrlsAndRoutes.Controllers" }
          );
   
            //alising a controller and an action
            routes.MapRoute("ShopSchema2", "Shop/OldAction",new { controller = "Home", action = "Index" });
            //Mixing Static URL Segments and Default Values
            routes.MapRoute("ShopSchema", "Shop/{action}",new { controller = "Home" });

            routes.MapRoute("", "X{controller}/{action}");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute( name: "Default", url: "{controller}/{action}/{id}", defaults: new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            }
            );
            routes.MapRoute("", "Public/{controller}/{action}",new { controller = "Home", action = "Index" });
        }
    }
}