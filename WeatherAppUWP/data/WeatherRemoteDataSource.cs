using System.Threading.Tasks;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.data
{
    public class WeatherRemoteDataSource : IWeatherDataSource
    {
        public async Task<DataResponse> GetForecastWeather(Coordinates cityCoord, int limit)
        {
            return await WeatherService.GetInstance().WeatherApi.GetForecastWeather(cityCoord, limit);
        }
    }
}