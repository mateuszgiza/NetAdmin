namespace NetAdmin.Domain.Models
{
    public class ConnectionModel
    {
        public string Hostname { get; set; }
        public int Port { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public string Query { get; set; }
    }
}