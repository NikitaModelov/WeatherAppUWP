using Newtonsoft.Json;

namespace WeatherAppUWP.domain.entity
{
    public class Part
    {
        [JsonProperty("day")]
        public Day Day { get; set; }
    }
}
