namespace NetAdmin.Infrastructure
{
    public class GetDatabasesRequest : IRequest
    {
        public ConnectionInfo Connection { get; set; }
        public string Query { get; set; }
    }
}
