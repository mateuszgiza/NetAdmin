using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Domain.Services.Interfaces;
using NetAdmin.Domain.Models;
using NetAdmin.Domain.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace NetModel.ViewComponents 
{
    public class TableMenuViewComponent : ViewComponent
    {
        private IMemoryCache _memoryCache;
        private readonly ICommandService _commandService;

        public TableMenuViewComponent(IMemoryCache memoryCache, ICommandService commandService)
        {
            _memoryCache = memoryCache;
            _commandService = commandService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string database)
        {
            var conn = _memoryCache.Get("connection") as ConnectionInfo;
            
            if (conn == null) {
                return View("~/Views/Command/Partials/TableMenuViewComponent.cshtml", new TableListResponse());
            }

            var tableListResponse = await _commandService.GetTablesAsync(conn);
            
            return View("~/Views/Command/Partials/TableMenuViewComponent.cshtml", tableListResponse);
        }
    }
}