using System.Collections.Generic;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.Application
{
    public class DatabaseList : IResponse
    {
        public IList<string> Databases { get; internal set; }
    }
}