using AutoMapper;
using CUPrototype.DTO;
using CUPrototype.Models;
using CUPrototype.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CUPrototype.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUserList()
        {
            var userList = _userRepository.GetUserList();

            if (userList.Count == 0)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<UserDto>>(userList));
        }

        [HttpGet("{Id}", Name = "getUser")]
        public ActionResult<UserDto> GetUser(int Id)
        {
            var user = _userRepository.GetUser(Id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public ActionResult<UserDto> PostUser(UserDto user)
        {
            var userModel = _mapper.Map<User>(user);
            _userRepository.InsertUser(userModel);

            return CreatedAtRoute(nameof(GetUser), new { userModel.Id }, userModel);
        }

        [HttpPut("{id}")]
        public ActionResult PutUser(int id, UserDto user)
        {
            var sourceUser = _userRepository.GetUser(id);
            if (sourceUser == null)
            {
                return NotFound();
            }

            _mapper.Map(user, sourceUser);

            _userRepository.UpdateUser(sourceUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var sourceUser = _userRepository.GetUser(id);
            if (sourceUser == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(sourceUser);

            return NoContent();
        }
    }
}