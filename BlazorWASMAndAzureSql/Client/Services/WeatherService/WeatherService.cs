using BlazorWASMAndAzureSql.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Client.Services.WeatherService
{
    public class WeatherService : IWeather
    {
        private readonly HttpClient _httpClient;
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<WeatherForecast> GetSingleWeather(int id)
        {
           return await _httpClient.GetFromJsonAsync<WeatherForecast>($"WeatherForecast/{id}");
        }

        public async Task<List<WeatherForecast>> GetWeatherList()
        {
           return await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast");
        }
    }
}
