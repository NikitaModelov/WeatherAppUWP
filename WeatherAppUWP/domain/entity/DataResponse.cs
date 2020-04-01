using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WeatherAppUWP.domain.entity;

namespace WeatherAppUWP
{
    public class DataResponse
    {
        [JsonProperty("fact")]
        public CurrentWeather CurrentWeather { get; set; }
        [JsonProperty("forecast")]
        public List<Forecast> Forecasts { get; set; }
    }
}
