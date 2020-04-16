using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.domain
{
    public interface IWeatherRepository
    {
        Task<CurrentWeather> GetCurrentWeather(Coordinates cityCoord);
        Task<List<Forecast>> GetForecast(Coordinates cityCoord, int limit);
    }
}
