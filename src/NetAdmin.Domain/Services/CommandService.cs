using NetAdmin.Domain.Responses;
using NetAdmin.Domain.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace NetAdmin.Domain.Services
{
    public class CommandService : ICommandService
    {
        public async Task<DatabaseListResponse> GetDatabasesAsync()
        {
            var databaseResponse = new DatabaseListResponse()
            {
                Databases = await Task.FromResult(new[] { "Database 1", "Database 2", "Database 3" })
            };

            return databaseResponse;
        }

        public async Task<TableListResponse> GetTablesAsync()
        {
            var tableResponse = new TableListResponse()
            {
                Tables = await Task.FromResult(new[] { "Table 1", "Table 2", "Table 3" })
            };

            return tableResponse;
        }
    }
}
