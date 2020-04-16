using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WeatherAppUWP.domain.entity;

namespace WeatherAppUWP
{
    public class DataResponse
    {
        /// <summary>
        /// Объект содержит информацию о погоде на данный момент.
        /// </summary>
        [JsonProperty("fact")]
        public CurrentWeather CurrentWeather { get; set; }
        /// <summary>
        /// Объект содержит данные прогноза погоды.
        /// </summary>
        [JsonProperty("forecasts")]
        public List<Forecast> Forecasts { get; set; }
    }
}
