using System;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.Log
{
    public interface ILogger : IService
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message, Exception exception);
    }
}