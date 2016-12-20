using System.Collections.Generic;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.DataAccess
{
    public sealed class User : IEntity<long>
    {
        public User()
        {
            DbConnections = new HashSet<DbConnection>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

        public ICollection<DbConnection> DbConnections { get; set; }
    }
}