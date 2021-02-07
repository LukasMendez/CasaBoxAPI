using System;
using AutoMapper;
using CasaBoxAPI.Dto;
using CasaBoxAPI.Models;

namespace CasaBoxAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bruger, BrugerDto>();
            CreateMap<RegistrerDto, Bruger>();
            CreateMap<OpdaterDto, Bruger>();
        }
    }
}
