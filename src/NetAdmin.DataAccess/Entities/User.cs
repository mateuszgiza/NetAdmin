using System.Collections.Generic;

namespace NetAdmin.DataAccess
{
    public sealed class User : IEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

        public ICollection<DbConnection> DbConnections { get; set; }

        public User()
        {
            DbConnections = new HashSet<DbConnection>();
        }
    }
}