namespace NetAdmin.Common.Abstractions
{
    public interface IDeletable<in TEntity> : IRepository
    {
        void Delete(TEntity entity);
    }
}