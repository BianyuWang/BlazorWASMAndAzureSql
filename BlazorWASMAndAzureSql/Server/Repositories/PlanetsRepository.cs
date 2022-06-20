using BlazorWASMAndAzureSql.Server.databases.DbContexts;
using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IRepositories;
using BlazorWASMAndAzureSql.Server.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Repositories
{
    public class PlanetsRepository : BaseRepository<Planets>, IPlanetsRepository
    {
        public PlanetsRepository(SuperheroContext context) : base(context)
        {

        }
    }
}
