using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppUWP.domain.entity
{
    public class Day
    {
        [JsonProperty("temp_avg")]
        public int TempAvg { get; set; }
    }
}
