namespace NetAdmin.Common.Abstractions
{
    public interface IInsertable<in TEntity> : IRepository
    {
        void Add(TEntity entity);
    }
}