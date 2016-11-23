using System.Collections.Generic;

namespace NetAdmin.Common.Responses
{
    public class TableListResponse : BaseResponse
    {
        public IEnumerable<string> Tables { get; set; }
    }
}
