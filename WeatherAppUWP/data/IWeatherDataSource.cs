using System.Threading.Tasks;
using WeatherAppUWP.Domain.Entity;
using WeatherAppUWP.Utill;

namespace WeatherAppUWP.data
{
    public interface IWeatherDataSource
    {
        Task<DataResponse> GetForecastWeather(Coordinates city, int limited);
    }
}