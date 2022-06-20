using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IRepositories;
using BlazorWASMAndAzureSql.Server.IService;
using BlazorWASMAndAzureSql.Server.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Services
{
    public class SpeciesService : BaseServices<Species>, ISpeciesService
    {
        private readonly ISpeciesRepository _SpeciesRepository;
        public SpeciesService(ISpeciesRepository SpeciesRepository) : base(SpeciesRepository)
        {
            _SpeciesRepository = SpeciesRepository;
        }
     
    }
}
