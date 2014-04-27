namespace SignalR.RealtimeLogger.Domain.Models.Logs
{
    public class Log
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string Platform { get; set; }
        public LogBody Body { get; set; }
    }

    public class LogBody
    {
        public string Severity { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
    }
}