using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Domain.Services.Interfaces;

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
            var databaseListResponse = await _commandService.GetDatabasesAsync();

            return View("~/Views/Command/Partials/DatabaseMenuViewComponent.cshtml", databaseListResponse);
        }
    }
}