using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetAdmin.Infrastructure
{
    public class CommandService : IService
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
    }
}