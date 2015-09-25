﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            new
            {
                 controller = "Home",
                 action = "Index",
                 id = "DefaultId"
            });
   
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