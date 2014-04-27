using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace SignalR.RealTimeLogger.Controllers.api
{
    public abstract class ApiHubController<THub> : ApiController where THub : Hub
    {

        public IHubContext HubContext
        {
            get { return GlobalHost.ConnectionManager.GetHubContext<THub>(); }
        }
    }
}