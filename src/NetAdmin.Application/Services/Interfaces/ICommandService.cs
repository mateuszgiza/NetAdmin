using NetAdmin.Infrastructure;
using NetAdmin.Common.Abstractions;

namespace NetAdmin.Application
{
    public interface ICommandService : IService
    {
        DatabaseList GetDatabases(ConnectionInfo connection);
        TableList GetTables(ConnectionInfo connection, string database);
    }
}