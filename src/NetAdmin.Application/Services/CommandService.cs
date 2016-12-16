using NetAdmin.Infrastructure;

namespace NetAdmin.Application
{
    public class CommandService : ICommandService
    {
        private readonly DatabaseRepository _databaseRepository;

        public CommandService(DatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        
        public DatabaseList GetDatabases(ConnectionInfo connection)
        {
            var request = new GetDatabasesRequest { Connection = connection };
            var response = _databaseRepository.GetDatabaseList(request);
            return response;
        }

        public TableList GetTables(ConnectionInfo connection, string database)
        {
            var request = new GetTablesRequest { Connection = connection, Database = database };
            var response = _databaseRepository.GetTableList(request);
            return response;
        }
    }
}
