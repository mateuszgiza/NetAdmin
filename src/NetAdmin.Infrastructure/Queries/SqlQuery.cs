using System;
using System.Collections.Generic;
using System.Text;

namespace NetAdmin.Infrastructure
{
    public class SqlQuery : IQuery
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Query { get; set; }
    }
}
