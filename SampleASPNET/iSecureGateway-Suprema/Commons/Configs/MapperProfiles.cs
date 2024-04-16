﻿using AutoMapper;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Commons.Config
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() 
        {   
            CreateMap<AccessGroup, AccessGroupDto>().ReverseMap();
            
            CreateMap<AccessLevel, AccessLevelDto>().ReverseMap();

        }
    }
}
