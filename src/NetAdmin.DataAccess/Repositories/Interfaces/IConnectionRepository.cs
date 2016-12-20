using System.Collections.Generic;
using NetAdmin.Common.Abstractions;

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