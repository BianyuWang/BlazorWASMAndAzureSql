using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWASMAndAzureSql.Shared.SWAPIModels;
using BlazorWASMAndAzureSql.Server.databases.models;

namespace BlazorWASMAndAzureSql.Server.AutomapperConfig
{
    public class SpeciesProfile :Profile
    {
        public SpeciesProfile()
        {
            CreateMap<SWSpecies, Species>()
                 .ForMember(dest => dest.AverageHeight, opts => opts.MapFrom(src => src.average_height))
              .ForMember(dest => dest.AverageLifespan, opts => opts.MapFrom(src => src.average_lifespan))
                .ForMember(dest => dest.Designation, opts => opts.MapFrom(src => src.designation))
            ;
        }
       
    }
}
