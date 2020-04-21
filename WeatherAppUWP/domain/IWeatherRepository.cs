using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAppUWP.Domain.Entity;
using WeatherAppUWP.Utill;

namespace WeatherAppUWP.Domain
{
    public interface IWeatherRepository
    {
        Task<CurrentWeather> GetCurrentWeather(Coordinates cityCoord);
        Task<List<Forecast>> GetForecast(Coordinates cityCoord, int limit);
    }
}