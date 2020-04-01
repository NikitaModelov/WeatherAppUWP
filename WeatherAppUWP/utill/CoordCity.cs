using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace WeatherAppUWP.utill
{
    public class Coordinates
    {
        [AliasAs("lat")]
        public double Latitude { get; }
        [AliasAs("lon")]
        public double Longitude { get; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
    public static class CoordCity
    {
        public static Dictionary<String, Coordinates> Cities =
            new Dictionary<string, Coordinates>
            {
                { "Новосибирск", new Coordinates(55.0415, 82.9346)},
                { "Москва", new Coordinates(55.7522, 37.6156)},
                { "Анапа", new Coordinates(44.8908, 37.3239)},
                { "Санкт-Петербург", new Coordinates(59.9386, 30.3141)},
            };
    }
}
