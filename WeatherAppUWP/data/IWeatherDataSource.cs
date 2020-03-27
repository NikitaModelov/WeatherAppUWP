using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppUWP.data
{
    public interface IWeatherDataSource
    {
        Task<DataResponse> GetCurrentWeather(string city);
    }
}
