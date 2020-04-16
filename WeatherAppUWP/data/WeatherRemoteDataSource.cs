using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.data
{
    public class WeatherRemoteDataSource : IWeatherDataSource
    {
        public async Task<DataResponse> GetForecastWeather(Coordinates cityCoord, int limit)
        {
            return await WeatherService.GetInstance().weatherApi.GetForecastWeather(cityCoord, limit);
        }

    }
}
