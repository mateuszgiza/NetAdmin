using System;
using NetAdmin.Domain.Responses;
using NetAdmin.Domain.Services.Interfaces;

namespace NetAdmin.Domain.Services
{
    public class CommandService : ICommandService
    {
        public DatabaseListResponse GetDatabases()
        {
            var databaseResponse = new DatabaseListResponse();

            databaseResponse.Databases = new[] { "Database 1", "Database 2", "Database 3" };

            return databaseResponse;
        }
    }
}
