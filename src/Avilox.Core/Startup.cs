using System;
using System.Collections;
using Avilox.Data.Contexts;
using Avilox.Data.Repositories;
using Avilox.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Avilox.Core
{
    public class Startup
    {
        public static readonly IDictionary ENV = Environment.GetEnvironmentVariables();

        public void ConfigureServices(IServiceCollection services)
        {            
            var host = ENV["Avilox_DB_HOST"];
            var catalog = ENV["Avilox_DB_CATALOG"];
            var user = ENV["Avilox_DB_USER"];
            var pass = ENV["Avilox_DB_PASS"];
            var connection = $"Data Source={host};Initial Catalog={catalog};User Id={user};Password={pass}";

            services.AddDbContext<AviloxDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IAviloxDbContext, AviloxDbContext>();
            services.AddTransient<IIssuesRepository, IssuesRepository>();

            services.AddCors();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseCors(p =>
            {
                p.AllowAnyOrigin();
                p.AllowAnyHeader();
                p.AllowAnyMethod();
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}