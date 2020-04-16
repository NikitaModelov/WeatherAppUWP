using Newtonsoft.Json;

namespace WeatherAppUWP.domain.entity
{
    public class Day
    {
        [JsonProperty("temp_avg")]
        public int TempAvg { get; set; }
    }
}