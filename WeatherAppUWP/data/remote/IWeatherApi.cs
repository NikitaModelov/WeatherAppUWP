using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace WeatherAppUWP
{
    public interface IWeatherApi
    {
        [Get("/v2.0/current?city={city}&key=ca59fc1bb5d94217883e9243972acc3d")]
        Task<DataResponse> GetCurrentWeather([AliasAs("city")] string city);
    }
}
