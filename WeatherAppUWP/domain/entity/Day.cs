using Newtonsoft.Json;

namespace WeatherAppUWP.Domain.Entity
{
    public class Day
    {
        [JsonProperty("temp_avg")]
        public int TempAvg { get; set; }
    }
}