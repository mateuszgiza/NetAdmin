namespace NetAdmin.Application
{
    public class CreateUserRequest : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}