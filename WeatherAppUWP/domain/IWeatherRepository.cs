using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.domain
{
    public interface IWeatherRepository
    {
        Task<CurrentWeather> GetCurrentWeather(Coordinates cityCoord, int limit);
    }
}
