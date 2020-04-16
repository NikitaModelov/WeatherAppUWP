using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppUWP.domain.entity
{
    public class Part
    {
        [JsonProperty("day")]
        public Day Day { get; set; }
    }
}
