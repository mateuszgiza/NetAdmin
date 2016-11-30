namespace NetAdmin.Infrastructure
{
    public interface IQueryBus
    {
        IQueryResult SendQuery<TQuery>(TQuery query) where TQuery : IQuery;
    }
}