using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.AutomapperConfig
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {


            return new MapperConfiguration(cfg =>
            {

                cfg.AddProfile(new PeopleProfile());

                cfg.AddProfile(new SpeciesProfile());
            });
        }


    }
}
