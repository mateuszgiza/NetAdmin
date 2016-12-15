using Microsoft.EntityFrameworkCore;

namespace NetAdmin.DataAccess
{
    internal class NetAdminDbContext : DbContext
    {
        public NetAdminDbContext(DbContextOptions<NetAdminDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}