using Newtonsoft.Json;

namespace WeatherAppUWP.Domain.Entity
{
    public class Part
    {
        [JsonProperty("day")]
        public Day Day { get; set; }
    }
}
