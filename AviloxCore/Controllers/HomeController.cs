using AviloxCore.DataAccess.Models;
using AviloxCore.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AviloxCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIssuesRepository _issuesRepo;

        public HomeController(IIssuesRepository issuesRepository) 
        {
            _issuesRepo = issuesRepository;
        }

        public IActionResult Index() => View();

        public IActionResult NewIssue() => View();

        public JsonResult AddIssue(Issue issue)
        {
            _issuesRepo.Add(issue);
            var result = _issuesRepo.CommitChanges();

            return Json(new { status = "Added issue", result = result, newIssue = issue });
        }

        public JsonResult AllIssues() 
        {
            var issues = _issuesRepo.GetAll();

            return Json(new { issues = issues });
        }
    }
}