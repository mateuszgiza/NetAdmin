namespace NetAdmin.Infrastructure
{
    public class CommonDbRequest : IDbRequest
    {
        public string CommandText { get; set; }
        public ConnectionInfo Connection { get; set; }
    }
}