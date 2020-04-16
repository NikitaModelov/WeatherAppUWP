using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAppUWP.data;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.domain
{
    public class GetForecastUseCase
    {
        private readonly IWeatherRepository repository;

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
