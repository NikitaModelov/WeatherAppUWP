using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.data;

namespace WeatherAppUWP.domain
{
    public class GetCurrentWeatherUseCase
    {

        private IWeatherRepository repository; 

        public GetCurrentWeatherUseCase()
        {
            this.repository = new WeatherRepository();
        }

        public async Task<List<Data>> Get(string city)
        {
            return await repository.GetCurrentWeather(city);
        }
    }
}
