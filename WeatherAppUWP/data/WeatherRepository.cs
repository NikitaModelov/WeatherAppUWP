using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.domain;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.data
{
    class WeatherRepository : IWeatherRepository
    {
        // еслли по умолчанию будет 1, то вернет прогноз на 7 дней ¯\_(ツ)_/¯
        const int limit = 2;
        IWeatherDataSource remoteDataSource;

        public WeatherRepository()
        {
            remoteDataSource = new WeatherRemoteDataSource();
        }

        public async Task<CurrentWeather> GetCurrentWeather(Coordinates cityCoord)
        {
            var response = await remoteDataSource.GetForecastWeather(cityCoord, limit);
            return response.CurrentWeather;
        }

        public async Task<List<Forecast>> GetForecast(Coordinates cityCoord, int limit)
        {
            var response = await remoteDataSource.GetForecastWeather(cityCoord, limit);
            return response.Forecasts;
        }
    } 
}
