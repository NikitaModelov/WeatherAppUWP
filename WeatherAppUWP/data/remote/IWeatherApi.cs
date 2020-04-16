using System.Threading.Tasks;
using Refit;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP
{
    [Headers("X-Yandex-API-Key: bbdad52d-e9f4-4cb3-bd2d-2a8107525ae6")]
    public interface IWeatherApi
    {
        [Get("/v1/forecast?extra=false")]
        Task<DataResponse> GetForecastWeather([Query] Coordinates cityCoord, [Query("limit")] int limit);
    }
}
