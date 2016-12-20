using NetAdmin.Common.Abstractions;

namespace NetAdmin.DataAccess
{
    public class DbConnection : IEntity<long>
    {
        public long Id { get; set; }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual User User { get; set; }
    }
}