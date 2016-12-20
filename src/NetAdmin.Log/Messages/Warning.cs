using NetAdmin.Common.Abstractions;

namespace NetAdmin.Log
{
    public class Warning : ILog
    {
        public string Message { get; set; }
        public LogType Type => LogType.Warning;
    }
}