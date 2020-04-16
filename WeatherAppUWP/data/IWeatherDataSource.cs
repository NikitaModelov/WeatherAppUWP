using System.Threading.Tasks;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.data
{
    public interface IWeatherDataSource
    {
        Task<DataResponse> GetForecastWeather(Coordinates city, int limited);
    }
}