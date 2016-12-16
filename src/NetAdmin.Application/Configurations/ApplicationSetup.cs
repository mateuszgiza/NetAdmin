using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetAdmin.DataAccess;

namespace NetAdmin.Application
{
    public static class ApplicationSetup
    {
        public static void SetupApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupDbContext(configuration);
        }
    }
}