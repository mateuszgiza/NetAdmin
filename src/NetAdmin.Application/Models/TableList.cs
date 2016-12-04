using NetAdmin.Infrastructure;
using System.Collections.Generic;

namespace NetAdmin.Application
{
    public class TableList : IResponse
    {
        public IList<string> Tables { get; internal set; }
    }
}
