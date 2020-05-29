using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null, "", new { Controller="Product",action="list",category=(string)null,Page=1});
            routes.MapRoute(null, "Page{page}", new { Controller = "Product", action = "list", category = (string)null, page = @"\d+" });
            routes.MapRoute(null, "{category}", new { Controller = "Product", action = "list", page = 1 });

           // routes.MapRoute(null, "Page{page}", new { Controller = "Product", action = "list", category = (string)null, page = 1 });
            
            routes.MapRoute(null, "{category}/Page{page}", new { Controller = "Product", action = "list"}, new { page = @"\d+" });

            //  routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(null, "{controller}/{action}");
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
