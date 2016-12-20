namespace NetAdmin.Common.Abstractions
{
    public interface IObtainable<out TEntity> : IRepository
    {
        TEntity GetById(long id);
    }
}