using System.Collections.Generic;

namespace NetAdmin.Infrastructure
{
    public class TableListResponse : BaseResponse
    {
        public IEnumerable<string> Tables { get; set; }
    }
}
