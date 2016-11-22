using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetModel.ViewComponents 
{
    public class TableMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO: Implement getting tables from the real SQL Server
            var databases = new[] { "Hehe Table 1", "Table 2", "Table 3", "Table 4", "Table 5" };
            
            return View("~/Views/Command/Partials/TableMenuViewComponent.cshtml", databases);
        }
    }
}