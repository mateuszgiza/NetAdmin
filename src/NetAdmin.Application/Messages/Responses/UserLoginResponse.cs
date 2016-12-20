using NetAdmin.Common.Abstractions;

namespace NetAdmin.Application
{
    public class UserLoginResponse : IResponse
    {
        public bool Successfull { get; set; }
    }
}