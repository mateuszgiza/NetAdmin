using NetAdmin.Domain.Responses;

namespace NetAdmin.Domain.Services.Interfaces
{
    public interface ICommandService
    {
        DatabaseListResponse GetDatabases();
    }
}
