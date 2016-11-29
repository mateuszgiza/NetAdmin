namespace NetAdmin.Business
{
    public abstract class BaseResponse
    {
        public ResponseState State { get; set; }
        public string Message { get; set; }
    }
}
