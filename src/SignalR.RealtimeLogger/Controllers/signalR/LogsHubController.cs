using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.RealTimeLogger.Controllers.signalR
{
    public class LogsHubController : Hub
    {
        public LogsHubController()
        {
            
        }

        public void Register()
        {
            Clients.All.hello();
            HubCallerContext hubCallerContext = Context;
        }
    }
}