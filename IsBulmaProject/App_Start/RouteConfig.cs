using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IsBulmaProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //    name: "Default-2",
           //    url: "{controller}/{action}/{id}&{PozisyonSeviyeId}",
           //    defaults: new { controller = "Home", action = "Index", id=UrlParameter.Optional, PozisyonSeviyeId = UrlParameter.Optional }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Anasayfa", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}
