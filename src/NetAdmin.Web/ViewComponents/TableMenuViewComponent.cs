using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Domain.Services.Interfaces;
using NetAdmin.Common.Models;
using NetAdmin.Common.Responses;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

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
                var emptyResponse = new TableListResponse() { Tables = Enumerable.Empty<string>() };
                return View("~/Views/Command/Partials/TableMenuViewComponent.cshtml", emptyResponse);
            }

            conn.Database = database;
            var tableListResponse = await _commandService.GetTablesAsync(conn);
            
            return View("~/Views/Command/Partials/TableMenuViewComponent.cshtml", tableListResponse);
        }
    }
}