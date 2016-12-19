namespace NetAdmin.Application
{
    public class ConnectionAddRequest
    {
        public long UserId { get; set; }

        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}