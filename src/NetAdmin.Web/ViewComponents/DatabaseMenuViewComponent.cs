using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Domain.Services.Interfaces;
using NetAdmin.Domain.Models;
using NetAdmin.Common.Responses;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace NetModel.ViewComponents
{
    public class DatabaseMenuViewComponent : ViewComponent
    {
        private IMemoryCache _memoryCache;
        private ICommandService _commandService;

        public DatabaseMenuViewComponent(IMemoryCache memoryCache, ICommandService commandService)
        {
            _memoryCache = memoryCache;
            _commandService = commandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var conn = _memoryCache.Get("connection") as ConnectionInfo;

            if (conn == null) {
                var emptyResponse = new DatabaseListResponse() { Databases = Enumerable.Empty<string>() };
                return View("~/Views/Command/Partials/DatabaseMenuViewComponent.cshtml", emptyResponse);
            }

            var databaseListResponse = await _commandService.GetDatabasesAsync(conn);

            return View("~/Views/Command/Partials/DatabaseMenuViewComponent.cshtml", databaseListResponse);
        }
    }
}