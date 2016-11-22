using System.Collections.Generic;

namespace NetAdmin.Domain.Responses
{
    public class DatabaseListResponse : BaseResponse
    {
        public IEnumerable<string> Databases { get; set; }
    }
}
