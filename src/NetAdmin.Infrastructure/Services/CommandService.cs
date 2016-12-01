using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetAdmin.Infrastructure
{
    public class CommandService : IService
    {
        public GetDatabasesResponse GetDatabasesAsync(GetDatabasesRequest request)
        {
            //const string databaseQuery = "SELECT name FROM sys.databases;";

            return SqlHelper.DoCommandOperation<GetDatabasesResponse>(request.Connection, request.Query, (response, reader) =>
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