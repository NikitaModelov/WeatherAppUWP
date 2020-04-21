using System.Threading.Tasks;
using WeatherAppUWP.Domain.Entity;
using WeatherAppUWP.Utill;

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