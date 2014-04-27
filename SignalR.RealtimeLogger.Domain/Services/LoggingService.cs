using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalR.RealtimeLogger.Domain.Services
{
    public interface ILogService
    {
        Task Log(string logAsJson);
    }

    public class LogService : ILogService
    {
        public async Task Log(string logAsJson)
        {
            var log = JsonConvert.DeserializeObject<Models.Logs.Log>(logAsJson);
        }
    }
}
