using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetAdmin.DataAccess
{
    public static class DbContextSetup
    {
        public static void SetupDbContext(this IServiceCollection services, IConfiguration configuration, Assembly migrationAssembly)
        {
            services.AddDbContext<NetAdminDbContext>(
                options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultDb"),
                        builder => builder.MigrationsAssembly(migrationAssembly.FullName)));
        }
    }
}