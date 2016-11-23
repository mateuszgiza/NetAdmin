using System.Collections.Generic;

namespace NetAdmin.Common.Responses
{
    public class DatabaseListResponse : BaseResponse
    {
        public IEnumerable<string> Databases { get; set; }
    }
}
