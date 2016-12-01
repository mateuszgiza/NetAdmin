using System.Threading.Tasks;
using System.Collections.Generic;
using NetAdmin.Infrastructure;

namespace NetAdmin.Application
{
    public class CommandService : ICommandService
    {
        public async Task<DatabaseListResponse> GetDatabasesAsync(ConnectionInfo connectionInfo)
        {
            const string databaseQuery = "SELECT name FROM sys.databases;";

            return await SqlHelper.DoCommandOperationAsync<DatabaseListResponse>(connectionInfo, databaseQuery, (response, reader) =>
            {
                var databaseList = new List<string>();

                while (reader.Read())
                {
                    var name = reader.GetValue(0).ToString();
                    databaseList.Add(name);
                }

                response.Databases = databaseList;
                response.State = ResponseState.Success;
            });
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
    }
}
