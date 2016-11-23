using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Domain.Services.Interfaces;
using NetAdmin.Domain.Models;

namespace NetModel.ViewComponents 
{
    public class TableMenuViewComponent : ViewComponent
    {
        private readonly ICommandService _commandService;

        public TableMenuViewComponent(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string database)
        {
            var conn = new ConnectionInfo()
            {
                Hostname = "avilox.database.windows.net",
                Username = "vahaagn",
                Password = "123asd!@#",
                Database = database
            };
            
            var tableListResponse = await _commandService.GetTablesAsync(conn);
            
            return View("~/Views/Command/Partials/TableMenuViewComponent.cshtml", tableListResponse);
        }
    }
}