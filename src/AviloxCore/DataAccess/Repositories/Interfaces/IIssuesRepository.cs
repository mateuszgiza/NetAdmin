using System.Collections.Generic;
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
    }
}