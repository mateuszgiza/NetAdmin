using System;
using System.Linq;

namespace NetAdmin.DataAccess
{
    internal class UserRepository : IUserRepository
    {
        private readonly NetAdminDbContext _db;

        public UserRepository(NetAdminDbContext context)
        {
            _db = context;
        }

        public void Add(User entity)
        {
            if (_db.Users.Any(u => u.Username.Equals(entity.Username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentNullException(nameof(entity), "Username was already taken!");
            }

            _db.Users.Add(entity);
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}