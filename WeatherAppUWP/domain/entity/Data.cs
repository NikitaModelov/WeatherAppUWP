using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace WeatherAppUWP
{
    public class Data
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("state_code")]
        public string StateCode { get; set; }
        [JsonProperty("city_name")]
        public string CityName { get; set; }
        [JsonProperty("wind_spd")]
        public int WindSpd { get; set; }
        [JsonProperty("temp")]
        public int Temp { get; set; } 
    }

    public class Root
    {

        /// <summary>
        /// 
        /// </summary>
        public List<Data> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
    }

    public class Weather
    {

        /// <summary>
        /// 
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
    }
}
