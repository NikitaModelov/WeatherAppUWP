using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppUWP.domain
{
    public interface IWeatherRepository
    {
        Task<List<Data>> GetCurrentWeather(string city);
    }
}
