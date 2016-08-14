using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avilox.Data.Contexts;
using Avilox.Data.Models;
using Avilox.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avilox.Data.Repositories
{
    public class IssuesRepository : IIssuesRepository
    {
        private readonly IAviloxDbContext _aviloxDb;

        public IssuesRepository(IAviloxDbContext aviloxDbContext) 
        {
            _aviloxDb = aviloxDbContext;
        }

        public void Add(Issue issue)
        {
            _aviloxDb.Issues.Add(issue);
        }

        public IEnumerable<Issue> GetAll()
        {
            return _aviloxDb.Issues;
        }

        public Issue GetById(int id)
        {
            return _aviloxDb.Issues.SingleOrDefault(i => i.Id.Equals(id));
        }

        public int CommitChanges()
        {
            return _aviloxDb.CommitChanges();
        }

        public bool Update(Issue issue)
        {
            issue.ModificationCount++;

            _aviloxDb.Entry(issue).State = EntityState.Modified;
            var result = _aviloxDb.Issues.Update(issue);

            return result != null;
        }

        public void Delete(int id)
        {
            var issue = new Issue {Id = id};
            _aviloxDb.Issues.Attach(issue);
            _aviloxDb.Entry(issue).State = EntityState.Deleted;
        }

        public async Task AddAsync(Issue issue)
        {
            await Task.Run(() => Add(issue));
        }

        public async Task<Issue> GetByIdAsync(int id)
        {
            return await _aviloxDb.Issues.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Issue>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task<bool> UpdateAsync(Issue issue)
        {
            return await Task.Run(() => Update(issue));
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() => Delete(id));
        }

        public async Task<int> CommitChangesAsync()
        {
            return await Task.Run(() => CommitChanges());
        }
    }
}