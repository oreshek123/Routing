using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Routing.Models;

namespace Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute("Privacy", "{privacy}", new { controller = "Home", action = "Privacy" });

            routes.MapRoute("ServiceHistory", "{ServiceHistory}", new { controller = "Home", action = "ListServiceHistory" });


            routes.MapRoute("ServiceHistoryStopCode", "ServiceHistory/{id}", new { controller = "Home", action = "ServiceHistory", id = UrlParameter.Optional }, new{id = @"^\d{2}.*" });

            routes.MapRoute("StopTrack", "ServiceHistory/{id}/Stop", new { controller = "Home", action = "CreateStop", id = UrlParameter.Optional }, new { httpMethod = new HttpMethodConstraint("POST") });

            routes.MapRoute("ServiceHistoryStopCodeAction", "ServiceHistory/{*catchall}", new { controller = "Home", action = "ServiceHistory" });

            routes.MapRoute("Error", "{Error}", new { controller = "Home", action = "Error"});

            routes.IgnoreRoute("Home/admin");

           //Я не понимаю как эту фигню делать...

            Route newRoute = new Route("CreateStop/{id}", new MyRouteHandler());
            routes.Add(newRoute);



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "ListStops" }
            );
        }
    }
}
