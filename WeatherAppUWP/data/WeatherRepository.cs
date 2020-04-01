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

        // TODO: Реализовать безопасный вызов
        public async Task<CurrentWeather> GetCurrentWeather(Coordinates cityCoord, int limit)
        {
            // TODO: Сделать безопасный вызов
            var response = await WeatherRemoteDataSource.GetCurrentWeather(cityCoord, limit);
            return response.CurrentWeather;
        }
    } 
}
