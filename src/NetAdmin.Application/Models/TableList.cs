using System.Collections.Generic;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.Application
{
    public class TableList : IResponse
    {
        public IList<string> Tables { get; internal set; }
    }
}