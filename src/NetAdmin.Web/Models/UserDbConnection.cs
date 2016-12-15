using Microsoft.AspNetCore.Mvc;

namespace NetAdmin.Web
{
    public class UserDbConnection
    {
        public long Id { get; set; }
        public string Owner { get; set; }

        public string Host { get; set; }
        public int Port { get; set; } = 6379;
        public string Username { get; set; }
        public string Password { get; set; }
    }
}