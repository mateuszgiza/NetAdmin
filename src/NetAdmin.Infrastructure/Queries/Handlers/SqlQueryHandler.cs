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

            // TODO: handle mapping by AutoMapper or similar framework
            var request = new GetDatabasesRequest
            {
                Connection = new ConnectionInfo
                {
                    Hostname = query.Hostname,
                    Port = query.Port,
                    Database = query.Database,
                    Username = query.Username,
                    Password = query.Password
                },
                //Query = query.Query
            };
            
            var response = _commandService.GetDatabasesAsync(request);
            result.Data = string.Join(",", response.Databases);

            return result;
        }
    }
}
