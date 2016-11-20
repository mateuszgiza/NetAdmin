using System.Collections.Generic;

namespace NetAdmin.Models
{
    public class ConnectionModel
    {
        public string Hostname { get; set; }
        public int Port { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public string Query { get; set; }

        public IEnumerable<string> FieldNames { get; set; }
        public IEnumerable<IEnumerable<string>> Result { get; set; }

        public string Error { get; set; }
    }
}