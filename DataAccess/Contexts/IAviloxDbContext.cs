using AviloxCore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AviloxCore.DataAccess.Contexts
{
    public interface IAviloxDbContext
    {
        DbSet<Issue> Issues { get; set; }

        int CommitChanges();
    }
}