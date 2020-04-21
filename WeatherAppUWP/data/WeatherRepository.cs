using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAppUWP.Domain;
using WeatherAppUWP.Domain.Entity;
using WeatherAppUWP.Utill;

namespace WeatherAppUWP.data
{
    class WeatherRepository : IWeatherRepository
    {
        // еслли по умолчанию будет 1, то вернет прогноз на 7 дней ¯\_(ツ)_/¯
        const int limitForecast = 2;
        private readonly IWeatherDataSource remoteDataSource;

        public WeatherRepository()
        {
            remoteDataSource = new WeatherRemoteDataSource();
        }

        public async Task<CurrentWeather> GetCurrentWeather(Coordinates cityCoord)
        {
            var response = await remoteDataSource.GetForecastWeather(cityCoord, limitForecast);
            return response.CurrentWeather;
        }

        public async Task<List<Forecast>> GetForecast(Coordinates cityCoord, int limit)
        {
            var response = await remoteDataSource.GetForecastWeather(cityCoord, limit);
            return response.Forecasts;
        }
    } 
}