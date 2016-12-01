using System.Collections.Generic;

namespace NetAdmin.Infrastructure
{
    public class DatabaseListResponse : BaseResponse
    {
        public IEnumerable<string> Databases { get; set; }
    }
}
