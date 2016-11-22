using NetAdmin.Domain.Responses;
using System.Threading.Tasks;

namespace NetAdmin.Domain.Services.Interfaces
{
    public interface ICommandService
    {
        Task<DatabaseListResponse> GetDatabasesAsync();
        Task<TableListResponse> GetTablesAsync();
    }
}
