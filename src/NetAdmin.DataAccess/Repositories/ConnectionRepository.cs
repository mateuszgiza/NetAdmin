using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NetAdmin.DataAccess
{
    internal class ConnectionRepository : IConnectionRepository
    {
        private readonly NetAdminDbContext _db;

        public ConnectionRepository(NetAdminDbContext context)
        {
            _db = context;
        }

        public void Add(DbConnection entity)
        {
            _db.DbConnections.Add(entity);
            _db.Entry(entity.User).State = EntityState.Detached;
            _db.SaveChanges();
        }

        public void Update(DbConnection entity)
        {
            throw new System.NotImplementedException();
        }

        public DbConnection GetById(long id)
        {
            return _db.DbConnections.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<DbConnection> GetByUserId(long userId)
        {
            return _db.DbConnections.Where(c => c.User.Id == userId);
        }

        public void Delete(DbConnection entity)
        {
            throw new System.NotImplementedException();
        }
    }
}