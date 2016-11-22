using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Domain.Services.Interfaces;

namespace NetModel.ViewComponents 
{
    public class TableMenuViewComponent : ViewComponent
    {
        private readonly ICommandService _commandService;

        public TableMenuViewComponent(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tableListResponse = await _commandService.GetTablesAsync();
            
            return View("~/Views/Command/Partials/TableMenuViewComponent.cshtml", tableListResponse);
        }
    }
}