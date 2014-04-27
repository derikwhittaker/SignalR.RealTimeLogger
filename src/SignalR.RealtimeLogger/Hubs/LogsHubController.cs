using Microsoft.AspNet.SignalR;

namespace SignalR.RealTimeLogger.Hubs
{
    public class LogsHubController : Hub
    {
        public LogsHubController()
        {
            
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}