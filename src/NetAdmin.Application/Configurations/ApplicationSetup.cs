using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetAdmin.DataAccess;
using DbContextSetup = NetAdmin.Log.DbContextSetup;

namespace NetAdmin.Application
{
    public static class ApplicationSetup
    {
        public static void SetupApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupDbContext(configuration);
            DbContextSetup.SetupDbContext(services, configuration);
        }
    }
}