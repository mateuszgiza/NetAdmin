namespace NetAdmin.Common.Abstractions
{
    public interface IUpdatable<in TEntity> : IRepository
    {
        void Update(TEntity entity);
    }
}