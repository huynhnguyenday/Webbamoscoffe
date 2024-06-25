using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webbamoscoffe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DetailProduct",
                url: "ProductMain/CHI-TIET-SAN-PHAM-SO-{id}",
                defaults: new { controller = "ProductMain", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Webbamoscoffe.Controllers" }
            );

            routes.MapRoute(
                name: "CategoryProduct",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Webbamoscoffe.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Webbamoscoffe.Areas.Admin.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "Cart/Index",
                defaults: new { controller = "Cart", action = "Index" }
            );

        }
    }
}
