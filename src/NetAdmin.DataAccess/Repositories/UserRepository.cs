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

        public User GetByName(string name)
        {
            return _db.Users.FirstOrDefault(u => u.Username.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(User entity)
        {
            if (_db.Users.Any(u => u.Username.Equals(entity.Username, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentNullException(nameof(entity), "Username was already taken!");

            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}