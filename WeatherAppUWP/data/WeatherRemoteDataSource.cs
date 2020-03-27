using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppUWP.data
{
    public static class WeatherRemoteDataSource
    {
        public static async Task<DataResponse> GetCurrentWeather(string city)
        {
            return await WeatherService.GetInstance().weatherApi.GetCurrentWeather(city);
        }
    }
}
