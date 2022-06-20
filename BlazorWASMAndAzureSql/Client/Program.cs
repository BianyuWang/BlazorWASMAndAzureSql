using BlazorWASMAndAzureSql.Client.Services.SWService;
using BlazorWASMAndAzureSql.Client.Services.WeatherService;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Radzen;

namespace BlazorWASMAndAzureSql.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IWeather, WeatherService>();
            builder.Services.AddScoped<ISWAPIService, SWAPIService>();
            builder.Services.AddScoped<ISuperheroService, SuperheroService>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            await builder.Build().RunAsync();
        }
    }
}
