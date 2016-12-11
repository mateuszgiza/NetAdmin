using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetAdmin.Web
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return new JsonResult(new { scope = "Index", text = "Elo xD" });
        }

        public IActionResult About()
        {
            return new JsonResult(new { scope = "About", text = "Elo xD" });
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
