using Avilox.Data.Models;
using Avilox.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Avilox.Core.Controllers
{
    [Route("[controller]")]
    public class IssuesController : Controller
    {
        private readonly IIssuesRepository _issuesRepo;

        public IssuesController(IIssuesRepository issuesRepository)
        {
            _issuesRepo = issuesRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var issues = _issuesRepo.GetAll();

            return Json(new { issues = issues });
        }

        [HttpGet("{id:int}")]
        public JsonResult Get(int id)
        {
            var issue = _issuesRepo.GetById(id);

            return Json(new { exist = issue != null,  issue = issue });
        }

        [HttpPost]
        public JsonResult Add([FromBody] Issue issue)
        {
            _issuesRepo.Add(issue);
            var result = _issuesRepo.CommitChanges();

            return Json(new { status = "Added issue", result = result, newIssue = issue });
        }

        [HttpPut]
        public JsonResult Update([FromBody] Issue issue)
        {
            var result = _issuesRepo.Update(issue);
            _issuesRepo.CommitChanges();

            return Json(new { result = result });
        }

        [HttpDelete("{id:int}")]
        public JsonResult Delete(int id)
        {
            _issuesRepo.Delete(id);
            _issuesRepo.CommitChanges();

            return Json(new { result = "Deletion proceeded" });
        }
    }
}