using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Domain.Services.Interfaces;
using NetAdmin.Domain.Models;

namespace NetModel.ViewComponents
{
    public class DatabaseMenuViewComponent : ViewComponent
    {
        private ICommandService _commandService;

        public DatabaseMenuViewComponent(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var conn = new ConnectionInfo()
            {
                Hostname = "avilox.database.windows.net",
                Username = "vahaagn",
                Password = "123asd!@#"
            };

            var databaseListResponse = await _commandService.GetDatabasesAsync(conn);

            return View("~/Views/Command/Partials/DatabaseMenuViewComponent.cshtml", databaseListResponse);
        }
    }
}