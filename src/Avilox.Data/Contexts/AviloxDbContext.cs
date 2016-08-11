using Avilox.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Avilox.Data.Contexts
{
    public class AviloxDbContext : DbContext, IAviloxDbContext
    {
        public AviloxDbContext(DbContextOptions<AviloxDbContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }

        public int CommitChanges()
        {
            return base.SaveChanges();
        }
    }
}