namespace NetAdmin.DataAccess
{
    public interface IObtainable<out TEntity> : IRepository
    {
        TEntity GetById(long id);
    }
}