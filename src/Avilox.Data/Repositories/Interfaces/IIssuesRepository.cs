using System.Collections.Generic;
using System.Threading.Tasks;
using Avilox.Data.Models;

namespace Avilox.Data.Repositories.Interfaces
{
    public interface IIssuesRepository
    {
        void Add(Issue issue);
        Issue GetById(int id);
        IEnumerable<Issue> GetAll();
        bool Update(Issue issue);
        void Delete(int id);
        
        Task AddAsync(Issue issue);
        Task<Issue> GetByIdAsync(int id);
        Task<IEnumerable<Issue>> GetAllAsync();
        Task<bool> UpdateAsync(Issue issue);
        Task DeleteAsync(int id);

        int CommitChanges();
        Task<int> CommitChangesAsync();
    }
}