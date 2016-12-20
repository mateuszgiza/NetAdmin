namespace NetAdmin.Infrastructure
{
    public class GetTablesRequest : IRequest
    {
        public ConnectionInfo Connection { get; set; }
        public string Database { get; set; }
    }
}