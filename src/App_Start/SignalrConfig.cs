using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR.RealTimeLogger.App_Start.SignalrConfig))]
namespace SignalR.RealTimeLogger.App_Start
{
    public class SignalrConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}