using System.Threading.Tasks;
using Newtonsoft.Json;
using SignalR.RealtimeLogger.Domain.Models.Logs;

namespace SignalR.RealtimeLogger.Domain.Services
{
    public interface ILogService
    {
        Task<Log> Log(string logAsJson);
        bool SessionExists(int sessionId);
    }

    public class LogService : ILogService
    {
        public async Task<Log> Log(string logAsJson)
        {
            var log = JsonConvert.DeserializeObject<Models.Logs.Log>(logAsJson);

            return log;
        }

        public bool SessionExists(int sessionId)
        {
            return true;
        }
    }
}
