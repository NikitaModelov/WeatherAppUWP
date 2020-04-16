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
    public class GetForecastUseCase
    {
        private IWeatherRepository repository;

        public GetForecastUseCase()
        {
            repository = new WeatherRepository();
        }

        public async Task<List<Forecast>> Get(Coordinates cityCoord, int limit)
        {
            return await Task.Run(() => repository.GetForecast(cityCoord, limit));
        }
    }
}
