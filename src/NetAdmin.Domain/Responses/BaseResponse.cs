using NetAdmin.Domain.Enums;

namespace NetAdmin.Domain.Responses
{
    public abstract class BaseResponse
    {
        public ResponseState State { get; set; }
        public string Message { get; set; }
    }
}
