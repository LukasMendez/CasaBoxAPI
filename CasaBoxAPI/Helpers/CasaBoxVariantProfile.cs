using System;
using AutoMapper;
using CasaBoxAPI.Dto;
using CasaBoxAPI.Models;

namespace CasaBoxAPI.Helpers
{
    public class CasaBoxVariantProfile : Profile
    {
        public CasaBoxVariantProfile()
        {
            CreateMap<CasaBoxVariant, CasaBoxVariantDto>()
                .ForMember(dest => dest.M2, act => act.MapFrom(src => src.M2))
                .ForMember(dest => dest.M3, act => act.MapFrom(src => src.M3))
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.Type))
                .ForMember(dest => dest.Pris, act => act.MapFrom(src => src.Pris))
                .ForMember(dest => dest.Beskrivelse, act => act.MapFrom(src => src.Beskrivelse));
        }
    }
}
