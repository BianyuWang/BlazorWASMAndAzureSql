using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWASMAndAzureSql.Shared;

namespace BlazorWASMAndAzureSql.Client.Services.WeatherService
{
  public  interface IWeather
    {
        Task <List<WeatherForecast>> GetWeatherList();
        Task<WeatherForecast> GetSingleWeather(int id);
    }
}
