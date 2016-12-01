namespace NetAdmin.Infrastructure
{
    public class SqlQueryResult : IQueryResult
    {
        public string Data { get; set; }
        public int RowsAffected { get; set; }
    }
}