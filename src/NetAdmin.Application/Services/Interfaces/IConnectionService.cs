using NetAdmin.Infrastructure;

namespace NetAdmin.Application
{
    public interface IConnectionService : IService
    {
        void AddConnection(ConnectionAddRequest request);
    }
}