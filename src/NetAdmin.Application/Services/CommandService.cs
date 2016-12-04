using System.Threading.Tasks;
using System.Collections.Generic;
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

        public async Task<DatabaseListResponse> GetDatabasesAsync(ConnectionInfo connectionInfo)
        {
            return null;
        }

        public async Task<TableListResponse> GetTablesAsync(ConnectionInfo connectionInfo)
        {
            const string tableQuery = "SELECT name FROM sys.tables;";

            return await SqlHelper.DoCommandOperationAsync<TableListResponse>(connectionInfo, tableQuery, (response, reader) =>
            {
                var tableList = new List<string>();

                while (reader.Read())
                {
                    var name = reader.GetValue(0).ToString();
                    tableList.Add(name);
                }

                response.Tables = tableList;
                response.State = ResponseState.Success;
            });
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
