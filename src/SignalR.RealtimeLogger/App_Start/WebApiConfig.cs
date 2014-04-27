using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SignalR.RealTimeLogger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IoCBootstrapper.Configure( GlobalConfiguration.Configuration );

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
