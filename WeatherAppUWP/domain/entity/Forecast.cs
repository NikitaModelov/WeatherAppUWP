using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAppUWP.domain.entity
{
    public class Forecast
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("hours")]
        public List<HourWeather> HourWeathers { get; set; }
        [JsonProperty("parts")]
        public Part Part { get; set; }

        public string GetTemp()
        {
            return Part.Day.TempAvg + "°С";
        }
    }
}