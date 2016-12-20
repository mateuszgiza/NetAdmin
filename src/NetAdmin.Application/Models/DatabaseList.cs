using System.Collections.Generic;

namespace NetAdmin.Application
{
    public class DatabaseList : IResponse
    {
        public IList<string> Databases { get; internal set; }
    }
}