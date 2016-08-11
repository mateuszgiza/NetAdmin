using Avilox.Data.Models;
using Avilox.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Avilox.Core.Controllers
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

        public JsonResult Add([FromBody] Issue issue)
        {
            _issuesRepo.Add(issue);
            var result = _issuesRepo.CommitChanges();

            return Json(new { status = "Added issue", result = result, newIssue = issue });
        }

        public JsonResult Update([FromBody] Issue issue)
        {
            var result = _issuesRepo.Update(issue);
            _issuesRepo.CommitChanges();

            return Json(new { result = result });
        }

        public JsonResult Delete([FromBody] int id)
        {
            _issuesRepo.Delete(id);
            _issuesRepo.CommitChanges();

            return Json(new {result = "Deletion proceeded"});
        }
    }
}