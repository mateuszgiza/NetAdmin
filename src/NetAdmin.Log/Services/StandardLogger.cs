using System;

namespace NetAdmin.Log
{
    internal class StandardLogger : LoggerBase, ILogger
    {
        public StandardLogger(ILogRepository logRepository)
            : base(logRepository)
        {
        }
        
        public void Info(string message)
        {
            var info = new Info
            {
                Message = message
            };

            LogRepository.Add(info);
        }

        public void Warning(string message)
        {
            var warning = new Warning
            {
                Message = message
            };

            LogRepository.Add(warning);
        }

        public void Error(string message, Exception exception)
        {
            var error = new Error()
            {
                Message = message,
                Exception = exception
            };

            LogRepository.Add(error);
        }
    }
}