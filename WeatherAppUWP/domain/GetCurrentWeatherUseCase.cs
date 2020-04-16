using System.Threading.Tasks;
using WeatherAppUWP.data;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.domain
{
    public class GetCurrentWeatherUseCase
    {

        private readonly IWeatherRepository repository; 

        public GetCurrentWeatherUseCase()
        {
            repository = new WeatherRepository();
        }

        public async Task<CurrentWeather> Get(Coordinates cityCoord)
        {
            return await Task.Run(() => repository.GetCurrentWeather(cityCoord));
        }
    }
}
