using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CUPrototype.Models;
using CUPrototype.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CUPrototype.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser userService;

        public UserController(IUser userService)
        {
            this.userService = userService;
        }

        [HttpGet("{Id}")]
        public ActionResult<User> getUser(int Id)
        {
            var user = userService.GetUser(Id);
            if(user == null)
            {
                return NotFound();
            }
            return userService.GetUser(Id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> getListUser()
        {
            var userList = userService.GetList();

            if(userList == null)
            {
                return NotFound();
            }

            return userService.GetList();
        }
    }
}