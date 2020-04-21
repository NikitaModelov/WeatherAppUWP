using System.Threading.Tasks;
using WeatherAppUWP.data;
using WeatherAppUWP.Domain.Entity;
using WeatherAppUWP.Utill;

namespace WeatherAppUWP.Domain
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
