using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetAdmin.Log.Contexts;

namespace NetAdmin.Log
{
    public static class DbContextSetup
    {
        public static void SetupDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LogDbContext>(
                options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultDb")));
        }
    }
}