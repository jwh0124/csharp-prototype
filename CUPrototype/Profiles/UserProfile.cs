using AutoMapper;
using CUPrototype.DTO;
using CUPrototype.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CUPrototype.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
