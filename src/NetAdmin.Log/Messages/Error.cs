using System;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.Log
{
    public class Error : ILog
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public LogType Type => LogType.Error;
    }
}