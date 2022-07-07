using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Client.Services.SWService
{
    interface ISuperheroService
    {
        public Task<List<Peoples>> GetPeoplesListAsync();
        public Task<List<Species>> GetSpeciesListAsync();
        public Task<List<Planets>> GetPlanetsListAsync();

        public Task<List<Peoples>> GetPeoplesListAsync(string linqStr);

        public Task<int> DeletePeopleAsync(int id);
        public Task<SuperheroEntity> InsertAsync(SuperheroEntity entity);
       
    }
}
