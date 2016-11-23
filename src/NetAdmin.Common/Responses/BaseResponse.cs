using NetAdmin.Common.Enums;

namespace NetAdmin.Common.Responses
{
    public abstract class BaseResponse
    {
        public ResponseState State { get; set; }
        public string Message { get; set; }
    }
}
