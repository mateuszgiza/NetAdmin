using System.Collections.Generic;

namespace NetAdmin.Business
{
    public class DatabaseListResponse : BaseResponse
    {
        public IEnumerable<string> Databases { get; set; }
    }
}
