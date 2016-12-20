using System;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.Log
{
    public class Log : IEntity<long>
    {
        public long Id { get; set; }

        public string LogObject { get; set; }
        public LogType Type { get; set; }
    }
}