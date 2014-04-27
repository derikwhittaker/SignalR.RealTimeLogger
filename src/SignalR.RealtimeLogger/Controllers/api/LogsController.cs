using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SignalR.RealtimeLogger.Domain.Services;
using SignalR.RealTimeLogger.Hubs;

namespace SignalR.RealTimeLogger.Controllers.api
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
            
        }

        [Route("api/logs/{sessionId}/listen")]
        [HttpPost]
        public HttpResponseMessage Listen(int sessionId)
        {
            var queryStrings = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            if (!queryStrings.ContainsKey("contextId"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No Context Id Provided");
            }

            if (_logService.SessionExists(sessionId))
            {
                //_logService.ListenToSession(sessionId)
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
