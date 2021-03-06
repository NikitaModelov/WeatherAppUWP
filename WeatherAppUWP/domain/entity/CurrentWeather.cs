﻿using Newtonsoft.Json;

namespace WeatherAppUWP.Domain.Entity
{
    public class CurrentWeather
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        /// <summary>
        /// Код расшифровки погодного описания. 
        /// </summary>
        [JsonProperty("feels_like")]
        public double FeelsTemperature { get; set; }
        [JsonProperty("condition")]
        public string Condition { get; set; }
        /// <summary>
        /// Тип осадков.
        /// </summary>
        [JsonProperty("prec_type")]
        public string PrecType { get; set; }

        public string GetTemp => Temperature + "°С";
    }
}