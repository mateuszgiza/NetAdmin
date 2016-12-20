using Microsoft.EntityFrameworkCore;

namespace NetAdmin.Log.Contexts
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> contextOptions)
            : base(contextOptions)
        {
            
        }

        public DbSet<Log> Logs { get; set; }
    }
}