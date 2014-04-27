using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using SignalR.RealtimeLogger.Domain.Services;

namespace SignalR.RealTimeLogger
{
    public static class IoCBootstrapper
    {
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            var webAssembly = Assembly.GetExecutingAssembly();
            var domainAssembly = Assembly.GetAssembly(typeof (ILogService));

            builder.RegisterApiControllers(webAssembly);

            builder.RegisterAssemblyTypes(webAssembly, domainAssembly)
                .AsImplementedInterfaces();


            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            httpConfiguration.DependencyResolver = resolver;
        }
    }
}