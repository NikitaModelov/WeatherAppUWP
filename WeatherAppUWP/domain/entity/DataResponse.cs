using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAppUWP
{
    public class DataResponse
    {
        [JsonProperty("data")]
        public List<Data> data { get; set; }
    }
}
