using NetAdmin.Common.Abstractions;

namespace NetAdmin.Infrastructure
{
    public abstract class BaseResponse : IResponse
    {
        public ResponseState State { get; set; }
        public string Message { get; set; }
    }
}