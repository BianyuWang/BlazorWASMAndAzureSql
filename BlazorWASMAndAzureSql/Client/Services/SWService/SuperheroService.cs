using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Client.Services.SWService
{

    public class SuperheroService: ISuperheroService
    {
        private readonly HttpClient _httpClient;
        public SuperheroService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<int> DeletePeopleAsync(int  id)
        {
            
            var rsp = await _httpClient.DeleteAsync($"api/Peoples/{id}");
            if (rsp.StatusCode is System.Net.HttpStatusCode.OK)
                return id;
             return 0;
        }
        public async Task<List<Peoples>> GetPeoplesListAsync()
        {
            
            var rsp = await _httpClient.GetFromJsonAsync < List < Peoples>> ("api/Peoples");
    //       var s = await rsp.Content.ReadAsStringAsync();
            return rsp;
        }

        public async Task<List<Planets>> GetPlanetsListAsync()
        {
            var rsp = await _httpClient.GetFromJsonAsync<List<Planets>>("api/Planets");
           
            return rsp;
        }

        public async Task<List<Species>> GetSpeciesListAsync()
        {
            var rsp = await _httpClient.GetFromJsonAsync<List<Species>>("api/species");

            return rsp;
        }

        public async Task<SuperheroEntity> InsertAsync(SuperheroEntity entity)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            switch (entity.tableName)
            {
                case "people":
                     response = await _httpClient.PostAsJsonAsync("api/Peoples", entity);                  
                    break;
                case "species":
                    response = await _httpClient.PostAsJsonAsync("api/Species", entity);
                    break;
                case "planets":
                    response = await _httpClient.PostAsJsonAsync("api/Planets", entity);
                    break;
                default:
                  
                    break;
            }

            if (response.StatusCode is System.Net.HttpStatusCode.OK)
            {
                entity.jsonStr = await response.Content.ReadAsStringAsync();
                return entity;
            }
            return null;
       
           
        }

        
    }
}
