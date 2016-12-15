namespace NetAdmin.DataAccess
{
    public interface IUpdatable<in TEntity> : IRepository
    {
        void Update(TEntity entity);
    }
}