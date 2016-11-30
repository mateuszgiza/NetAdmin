namespace NetAdmin.Infrastructure
{
    public interface IHandleQuery
    {
    }

    public interface IHandleQuery<TQuery> : IHandleQuery where TQuery : IQuery
    {
        IQueryResult Handle(TQuery query);
    }
}