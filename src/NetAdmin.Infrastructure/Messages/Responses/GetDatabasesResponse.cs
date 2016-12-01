using System.Collections.Generic;

namespace NetAdmin.Infrastructure
{
    public class GetDatabasesResponse : BaseResponse
    {
        public IEnumerable<string> Databases { get; set; }
    }
}
