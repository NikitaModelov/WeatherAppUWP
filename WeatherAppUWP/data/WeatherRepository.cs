using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.domain;

namespace WeatherAppUWP.data
{
    class WeatherRepository : IWeatherRepository
    {

        // TODO: Реализовать безопасный вызов
        public async Task<List<Data>> GetCurrentWeather(string city)
        {
            // TODO: Сделать безопасный вызов
            var response = await WeatherRemoteDataSource.GetCurrentWeather(city);
            return response.data;
        }
    }
}
