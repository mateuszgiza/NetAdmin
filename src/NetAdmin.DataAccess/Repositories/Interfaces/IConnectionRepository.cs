using System.Collections.Generic;

namespace NetAdmin.DataAccess
{
    public interface IConnectionRepository : 
        IInsertable<DbConnection>,
        IUpdatable<DbConnection>,
        IObtainable<DbConnection>,
        IDeletable<DbConnection>
    {
        IEnumerable<DbConnection> GetByUserId(long userId);
    }
}