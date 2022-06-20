using BlazorWASMAndAzureSql.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Client.Services.SWService
{
   
    public class SWAPIService : ISWAPIService
    {
        private readonly HttpClient _httpClient;
        public SWAPIService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        
        public async Task<string> CallSWAPI(string URLPassed)
        {
       

            hero th = new hero();
            th.id = 1;
            th.request = URLPassed;
            var result = await _httpClient.PostAsJsonAsync("SWAPI", th);
        if(result.StatusCode is System.Net.HttpStatusCode.OK)
          return   await result.Content.ReadAsStringAsync();

            return null;
        }
    }
}
