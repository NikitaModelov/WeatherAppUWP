using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.data
{
    public static class WeatherRemoteDataSource
    {
        public static async Task<DataResponse> GetCurrentWeather(Coordinates cityCoord, int limit)
        {
            return await WeatherService.GetInstance().weatherApi.GetCurrentWeather(cityCoord, limit);
        }
    }
}
