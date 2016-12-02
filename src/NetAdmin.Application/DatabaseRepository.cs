using NetAdmin.Application.Models;
using NetAdmin.Infrastructure;
using System.Collections.Generic;

namespace NetAdmin.Application
{
    public class DatabaseRepository
    {
        public DatabaseList GetDatabaseList(GetDatabasesRequest request)
        {
            const string query = "SELECT name FROM sys.databases;";

            return SqlHelper.DoCommandOperation<DatabaseList>(request.Connection, query, (response, reader) => {
                var databaseList = new List<string>();

                while (reader.Read())
                {
                    var name = reader.GetValue(0).ToString();
                    databaseList.Add(name);
                }

                response.Databases = databaseList;
                //response.State = ResponseState.Success;
            });
        }
    }
}
