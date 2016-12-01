using System;
using System.Collections.Generic;
using System.Text;

namespace NetAdmin.Infrastructure
{
    public class SqlQueryHandler : IHandleQuery<SqlQuery>
    {
        private readonly CommandService _commandService;

        public SqlQueryHandler(CommandService commandService)
        {
            _commandService = commandService;
        }

        public IQueryResult Handle(SqlQuery query)
        {
            var result = new SqlQueryResult();

            //_commandService.GetDatabasesAsync();
            result.Data = "No elo data";

            return result;
        }
    }
}
