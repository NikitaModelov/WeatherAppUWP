using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAppUWP.domain.entity
{
    public class Forecast
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("hours")]
        public List<HourWeather> HourWeathers { get; set; }
    }
}
