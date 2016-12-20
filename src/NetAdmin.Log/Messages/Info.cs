using NetAdmin.Common.Abstractions;

namespace NetAdmin.Log
{
    public class Info : ILog
    {
        public string Message { get; set; }
        public LogType Type => LogType.Info;
    }
}