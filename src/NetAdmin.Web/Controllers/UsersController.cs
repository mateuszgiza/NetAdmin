using System;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.DataAccess;

namespace NetAdmin.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public JsonResult Add([FromBody] User user)
        {
            try
            {
                _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

            return Json("OK");
        }
    }
}