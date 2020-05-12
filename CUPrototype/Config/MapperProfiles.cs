using AutoMapper;
using CUPrototype.DTO;
using CUPrototype.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CUPrototype.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
