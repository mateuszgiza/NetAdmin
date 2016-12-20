using NetAdmin.Infrastructure;

namespace NetAdmin.Application
{
    public interface ICommandService : IService
    {
        DatabaseList GetDatabases(ConnectionInfo connection);
        TableList GetTables(ConnectionInfo connection, string database);
    }
}