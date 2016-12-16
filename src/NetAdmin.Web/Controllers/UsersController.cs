using System;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Application;

namespace NetAdmin.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public JsonResult Add([FromBody] CreateUserRequest request)
        {
            try
            {
                _userService.Register(request);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

            return Json("OK");
        }
    }
}