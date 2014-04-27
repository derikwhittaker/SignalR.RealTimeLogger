using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using SignalR.RealtimeLogger.Domain.Services;

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

    public static class IoCBootstrapper
    {
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<LogService>().As<ILogService>().InstancePerApiRequest();

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);

            httpConfiguration.DependencyResolver = resolver;
        }
    }
}
