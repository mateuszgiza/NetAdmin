using System;
using System.Collections.Generic;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.Log
{
    public interface ILogRepository :
        IInsertable<ILog>,
        IObtainable<Log>
    {
        IEnumerable<Log> GetAll();
        IEnumerable<Log> GetAll<TType>();
        IEnumerable<Log> GetAll(Type type);
    }
}