using System.Collections.Generic;

namespace NetAdmin.Business
{
    public class TableListResponse : BaseResponse
    {
        public IEnumerable<string> Tables { get; set; }
    }
}
