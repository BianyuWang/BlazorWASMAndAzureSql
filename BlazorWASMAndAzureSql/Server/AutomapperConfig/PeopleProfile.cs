using AutoMapper;
using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Shared.SWAPIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.AutomapperConfig
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<SWPeople, Peoples>()
                 .ForMember(dest => dest.HairColor, opts => opts.MapFrom(src => src.hair_color))
              .ForMember(dest => dest.SkinColor, opts => opts.MapFrom(src => src.skin_color))
                .ForMember(dest => dest.BirthYear, opts => opts.MapFrom(src => src.birth_year))
                .ForMember(dest => dest.EyeColor, opts => opts.MapFrom(src => src.eye_color))
            ;
        }
    }
}
