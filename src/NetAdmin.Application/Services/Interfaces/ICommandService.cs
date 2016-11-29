using NetAdmin.Business;
using System.Threading.Tasks;

namespace NetAdmin.Application
{
    public interface ICommandService
    {
        Task<DatabaseListResponse> GetDatabasesAsync(ConnectionInfo connectionInfo);
        Task<TableListResponse> GetTablesAsync(ConnectionInfo connectionInfo);
    }
}
