using System;
using System.Reflection;
using NetAdmin.Log.Repositories.Interfaces;

namespace NetAdmin.Log
{
    internal class LoggerBase
    {
        protected ILogRepository LogRepository;

        protected Assembly CurrentAssembly => GetType().GetTypeInfo().Assembly;

        [Obsolete("Not implemented yet!")]
        protected string MachineName => null;
    }
}