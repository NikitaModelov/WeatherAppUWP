using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAppUWP.domain.entity
{
    public class HourWeather
    {
        [JsonProperty("hour")]
        public string Hour { get; set; }
        [JsonProperty("temp")]
        public string Temperature { get; set; }
    }
}
