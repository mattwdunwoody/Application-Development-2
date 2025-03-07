using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GadgetHub.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // All products, all routes
            routes.MapRoute(null, "", new
            {
                controller = "Gadget",
                action = "List",
                category = (string) null,
                page = 1
            });

            // /Page2 - Lists on page from all categories
            routes.MapRoute(null, "Page{page}", new
            {
                controller = "Gadget",
                action = "List",
                category = (string) null,
            },
            new { page = @"\d+" });

            // /Wearables - shows first page from a specific category
            routes.MapRoute(null, "{category}", new
            { 
                controller = "Gadget",
                action = "List",
                page = 1
            });

            // /Wearables/Page2 - Shows a specific page of a specific category
            routes.MapRoute(null, "{category}/Page{page}", new
            { 
                controller = "Gadget",
                Action = "List"
            },
            new { page = @"\d+" });

			routes.MapRoute(null, "{controller}/{action}");

			//default method
			/*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Gadget", action = "List", id = UrlParameter.Optional }
            );*/
		}
    }
}
