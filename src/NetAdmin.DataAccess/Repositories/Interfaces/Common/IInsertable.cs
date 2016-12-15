namespace NetAdmin.DataAccess
{
    public interface IInsertable<in TEntity> : IRepository
    {
        void Add(TEntity entity);
    }
}