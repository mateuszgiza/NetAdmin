namespace NetAdmin.DataAccess
{
    public interface IDeletable<in TEntity> : IRepository
    {
        void Delete(TEntity entity);
    }
}