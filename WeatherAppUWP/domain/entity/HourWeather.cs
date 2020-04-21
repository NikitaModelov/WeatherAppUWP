using Newtonsoft.Json;

namespace WeatherAppUWP.Domain.Entity
{
    public class HourWeather
    {
        [JsonProperty("hour")]
        public string Hour { get; set; }
        [JsonProperty("temp")]
        public string Temperature { get; set; }
    }
}