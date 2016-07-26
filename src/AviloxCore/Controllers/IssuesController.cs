using AviloxCore.DataAccess.Models;
using AviloxCore.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AviloxCore.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesRepository _issuesRepo;

        public IssuesController(IIssuesRepository issuesRepository) 
        {
            _issuesRepo = issuesRepository;
        }

        public JsonResult All() 
        {
            var issues = _issuesRepo.GetAll();

            return Json(new { issues = issues });
        }

        public JsonResult Add(Issue issue)
        {
            _issuesRepo.Add(issue);
            var result = _issuesRepo.CommitChanges();

            return Json(new { status = "Added issue", result = result, newIssue = issue });
        }

        public JsonResult Update(Issue issue) 
        {
            var result = _issuesRepo.Update(issue);

            return Json(new { result = result });
        }
    }
}