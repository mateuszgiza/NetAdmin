#region --- Header ---
// File: AviloxDbContextFactory.cs
// Original Project: Avilox.Data
// Original Solution: AviloxCore
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/08/14
#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Avilox.Data.Contexts.Factories
{
    public class AviloxDbContextFactory : IDbContextFactory<AviloxDbContext>
    {
        public AviloxDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<AviloxDbContext>();

            var host = Program.ENV["Avilox_DB_HOST"];
            var catalog = Program.ENV["Avilox_DB_CATALOG"];
            var user = Program.ENV["Avilox_DB_USER"];
            var pass = Program.ENV["Avilox_DB_PASS"];
            var connection = $"Data Source={host};Initial Catalog={catalog};User Id={user};Password={pass}";

            builder.UseSqlServer(connection);
            return new AviloxDbContext(builder.Options);
        }
    }
}