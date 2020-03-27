using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Refit;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WeatherAppUWP
{
    public class WeatherService
    {
        private const string BASE_URL = "https://api.weatherbit.io";

        private static readonly Lazy<WeatherService> lazy =
            new Lazy<WeatherService>(() => new WeatherService());

        private readonly HttpClient httpClient;
        public IWeatherApi weatherApi { get; private set; }

        [Obsolete]
        protected WeatherService()
        {
            httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = new Uri(BASE_URL) };
            var refitSettings = new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                }
            };
            weatherApi = RestService.For<IWeatherApi>(httpClient, refitSettings);
        }

        public static WeatherService GetInstance()
        {
            return lazy.Value;
        }
    }
}
