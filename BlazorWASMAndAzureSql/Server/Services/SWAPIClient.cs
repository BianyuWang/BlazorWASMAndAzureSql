using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Services
{
    public class SWAPIClient
    {
        public string CallSWAPI(string con)
        {
           // var addr = "https:///swapi.dev//api//";
            var client = new RestClient("https://swapi.dev/api/"+con);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode is System.Net.HttpStatusCode.OK)
                return response.Content;
            else
                return null;
        }
    }
}
