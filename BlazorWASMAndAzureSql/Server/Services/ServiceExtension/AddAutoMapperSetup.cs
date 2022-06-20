using BlazorWASMAndAzureSql.Server.AutomapperConfig;

using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWASMAndAzureSql.Server.Services.ServiceExtension
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapperConfig));
        }
    }
}
