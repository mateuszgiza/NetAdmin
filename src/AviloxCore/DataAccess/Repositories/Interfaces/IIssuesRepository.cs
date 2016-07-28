using System.Collections.Generic;
using System.Threading.Tasks;
using AviloxCore.DataAccess.Models;

namespace AviloxCore.DataAccess.Repositories.Interfaces
{
    public interface IIssuesRepository
    {
        void Add(Issue issue);
        
        Issue GetById(int id);
        IEnumerable<Issue> GetAll();
        bool Update(Issue issue);

        int CommitChanges();

        Task AddAsync(Issue issue);
        Task<Issue> GetByIdAsync(int id);
        Task<IEnumerable<Issue>> GetAllAsync();
        Task<bool> UpdateAsync(Issue issue);
        Task<int> CommitChangesAsync();
    }
}