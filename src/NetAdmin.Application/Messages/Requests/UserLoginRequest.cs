namespace NetAdmin.Application
{
    public class UserLoginRequest : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}