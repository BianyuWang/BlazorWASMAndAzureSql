using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IRepositories;
using BlazorWASMAndAzureSql.Server.IService;
using BlazorWASMAndAzureSql.Server.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Services
{
    public class PlanetsService : BaseServices<Planets>, IPlanetsService
    {
        private readonly IPlanetsRepository _planetsRepository;
        public PlanetsService(IPlanetsRepository planetsRepository) : base(planetsRepository)
        {
            _planetsRepository = planetsRepository;
        }

    }
}
