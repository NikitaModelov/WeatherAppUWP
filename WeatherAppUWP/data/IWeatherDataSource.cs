using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.data
{
    public interface IWeatherDataSource
    {
        Task<DataResponse> GetForecastWeather(Coordinates city, int limited);
    }
}
