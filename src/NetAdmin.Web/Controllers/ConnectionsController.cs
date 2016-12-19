using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Application;

namespace NetAdmin.Web.Controllers
{
    [Authorize]
    public class ConnectionsController : Controller
    {
        private readonly IConnectionService _connectionService;

        public ConnectionsController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public JsonResult Get()
        {
            throw new NotImplementedException();
        }

        public JsonResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public JsonResult Add([FromBody] ConnectionAddRequest request)
        {
            _connectionService.AddConnection(request);
            return Json("OK");
        }

        public JsonResult Update()
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete([FromBody] int id)
        {
            throw new NotImplementedException();
        }
    }
}