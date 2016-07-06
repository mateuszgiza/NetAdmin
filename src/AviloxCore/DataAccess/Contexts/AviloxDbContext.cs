using System;
using AviloxCore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AviloxCore.DataAccess.Contexts
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