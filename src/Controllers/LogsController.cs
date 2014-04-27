using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR.Infrastructure;
using Newtonsoft.Json;
using SignalR.RealtimeLogger.Domain.Services;
using SignalR.RealTimeLogger.Hubs;

namespace SignalR.RealTimeLogger.Controllers
{
    public class LogsController : ApiHubController<LogsHubController>
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [Route("api/logs")]
        [HttpPost]
        public async Task Log()
        {
            var logString = await Request.Content.ReadAsStringAsync();
            

            await _logService.Log(logString);


            var hubContext = HubContext;
        }
    }
}
