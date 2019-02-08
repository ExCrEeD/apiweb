using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiMails
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200/", headers: "*", methods: ""));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action=RouteParameter.Optional  }

            );

            //config.Routes.MapHttpRoute(
            //name: "Getfile",
            //routeTemplate: "api/SendMails/{action}/{id}",
            //defaults: new { controller = "SendMails", id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //name: "GetReportFilter",
            //routeTemplate: "api/SendMails/{action}",
            //defaults: new { controller = "SendMails", action = RouteParameter.Optional }
            //);
        }
    }
}
