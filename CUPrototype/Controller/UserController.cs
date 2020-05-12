using AutoMapper;
using CUPrototype.DTO;
using CUPrototype.Models;
using CUPrototype.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using System.Collections.Generic;

namespace CUPrototype.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{Id}", Name ="getUser")]
        public ActionResult<UserDto> getUser(int Id)
        {
            var user = _userRepository.GetUser(Id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> getListUser()
        {
            var userList = _userRepository.GetList();

            if(userList == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<UserDto>>(userList));
        }

        [HttpPost]
        public ActionResult<UserDto> setUser(UserDto user)
        {
            var userModel = _mapper.Map<User>(user);
            _userRepository.SetUser(userModel);

            return CreatedAtRoute(nameof(getUser), new {Id = userModel.Id}, userModel);
        }
    }
}