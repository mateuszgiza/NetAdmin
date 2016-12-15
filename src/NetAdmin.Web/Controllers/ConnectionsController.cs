using System;
using Microsoft.AspNetCore.Mvc;

namespace NetAdmin.Web.Controllers
{
    public class ConnectionsController : Controller
    {
        public ConnectionsController()
        {

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
            throw new NotImplementedException();
        }

        public JsonResult Update()
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete([FromBody] ConnectionDeleteRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public class ConnectionAddRequest
    {
        public UserDbConnection Connection { get; set; }
    }

    public class ConnectionDeleteRequest
    {
        public string Id { get; set; }
    }
}