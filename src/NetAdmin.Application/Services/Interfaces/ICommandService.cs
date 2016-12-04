using System.Threading.Tasks;
using NetAdmin.Infrastructure;

namespace NetAdmin.Application
{
    public interface ICommandService
    {
        Task<DatabaseListResponse> GetDatabasesAsync(ConnectionInfo connectionInfo);
        Task<TableListResponse> GetTablesAsync(ConnectionInfo connectionInfo);

        DatabaseList GetDatabases(ConnectionInfo connection);
        TableList GetTables(ConnectionInfo connection, string database);
    }
}
