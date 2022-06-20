using AutoMapper;
using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Shared.SWAPIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.AutomapperConfig
{
    public class PlanetsProfile : Profile
    {
        public PlanetsProfile()
        {
            CreateMap<SWPlanet, Planets>()
                 .ForMember(dest => dest.OrbitalPeriod, opts => opts.MapFrom(src => src.orbital_period))
              .ForMember(dest => dest.RotationPeriod, opts => opts.MapFrom(src => src.rotation_period))
                .ForMember(dest => dest.SurfaceWater, opts => opts.MapFrom(src => src.surface_water))
             
            ;
        }
    }
}
