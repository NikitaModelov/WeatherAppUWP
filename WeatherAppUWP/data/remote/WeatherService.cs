using System;
using System.Net.Http;
using Refit;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WeatherAppUWP
{
    public class WeatherService
    {
        private const string BaseUrl = "https://api.weather.yandex.ru";

        private static readonly Lazy<WeatherService> lazy =
            new Lazy<WeatherService>(() => new WeatherService());

        public IWeatherApi WeatherApi { get; }

        [Obsolete]
        protected WeatherService()
        {
            var httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = new Uri(BaseUrl) };
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
            WeatherApi = RestService.For<IWeatherApi>(httpClient, refitSettings);
        }

        public static WeatherService GetInstance()
        {
            return lazy.Value;
        }
    }
}