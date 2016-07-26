using AviloxCore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AviloxCore.DataAccess.Contexts
{
    public interface IAviloxDbContext
    {
        DbSet<Issue> Issues { get; set; }

        int CommitChanges();
        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity: class;
    }
}