using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetModel.ViewComponents 
{
    public class DatabaseMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO: Implement getting databases from the real SQL Server
            var databases = new[] { "Database 1", "Database 2", "Database 3", "Database 4", "Database 5" };

            return View("~/Views/Command/Partials/DatabaseMenuViewComponent.cshtml", databases);
        }
    }
}