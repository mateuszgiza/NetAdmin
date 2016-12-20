using NetAdmin.DataAccess;

namespace NetAdmin.Application
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectionRepository _connectionRepository;

        public ConnectionService(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public void AddConnection(ConnectionAddRequest request)
        {
            var dbConnection = new DbConnection
            {
                Host = request.Hostname,
                Port = request.Port,
                Username = request.Username,
                Password = request.Password,
                User = new User {Id = request.UserId}
            };

            _connectionRepository.Add(dbConnection);
        }
    }
}