using System.Collections.Generic;
using System.Linq;
using AviloxCore.DataAccess.Contexts;
using AviloxCore.DataAccess.Models;
using AviloxCore.DataAccess.Repositories.Interfaces;

namespace AviloxCore.DataAccess.Repositories
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
            return _aviloxDb.Issues.FirstOrDefault(i => i.Id.Equals(id));
        }

        public int CommitChanges()
        {
            return _aviloxDb.CommitChanges();
        }
    }
}