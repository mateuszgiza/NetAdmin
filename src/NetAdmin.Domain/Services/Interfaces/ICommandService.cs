using NetAdmin.Common.Responses;
using System.Threading.Tasks;
using NetAdmin.Common.Models;

namespace NetAdmin.Domain.Services.Interfaces
{
    public interface ICommandService
    {
        Task<DatabaseListResponse> GetDatabasesAsync(ConnectionInfo connectionInfo);
        Task<TableListResponse> GetTablesAsync(ConnectionInfo connectionInfo);
    }
}
