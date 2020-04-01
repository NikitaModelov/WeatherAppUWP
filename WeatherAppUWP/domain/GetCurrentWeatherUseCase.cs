using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.data;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.domain
{
    public class GetCurrentWeatherUseCase
    {

        private IWeatherRepository repository; 

        public GetCurrentWeatherUseCase()
        {
            this.repository = new WeatherRepository();
        }

        public async Task<CurrentWeather> Get(Coordinates cityCoord, int limit)
        {
            return await Task.Run(() => repository.GetCurrentWeather(cityCoord, limit));
        }
    }
}
