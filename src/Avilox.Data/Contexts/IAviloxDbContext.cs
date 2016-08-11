using Avilox.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Avilox.Data.Contexts
{
    public interface IAviloxDbContext
    {
        DbSet<Issue> Issues { get; set; }

        int CommitChanges();
        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity: class;
    }
}