using System.Collections.Generic;

namespace NetAdmin.Domain.Responses
{
    public class TableListResponse : BaseResponse
    {
        public IEnumerable<string> Tables { get; set; }
    }
}
