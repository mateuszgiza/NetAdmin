namespace Avilox.Models
{
    public class ConnectionModel
    {
        public string HostName { get; set; }
        public int Port { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public string Query { get; set; }
        public string Result { get; set; }
    }
}