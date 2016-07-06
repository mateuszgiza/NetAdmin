using AviloxCore.DataAccess.Contexts;
using AviloxCore.DataAccess.Repositories;
using AviloxCore.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AviloxCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=mssql4.webio.pl,2401;Database=vahaagn_aspnet;Uid=vahaagn_aspnet;Password=!@#derbyPhoenix3;";
            services.AddDbContext<AviloxDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IAviloxDbContext, AviloxDbContext>();
            services.AddTransient<IIssuesRepository, IssuesRepository>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}